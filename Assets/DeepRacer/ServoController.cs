using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.DeepracerInterfacesPkg;

public class ServoController : MonoBehaviour
{
    private ROSConnection ros;
    private string manualDriveTopic = "webserver_pkg/manual_drive";
    private string vehicleStateService = "ctrl_pkg/vehicle_state";
    private string enableStateService = "ctrl_pkg/enable_state";

    public float publishFrequency = 0.1f;
    private float timeElapsed = 0.0f;
    private bool enableVehicle = false;

    // Enums from https://github.com/aws-deepracer/aws-deepracer-ctrl-pkg/blob/main/ctrl_pkg/src/ctrl_node.cpp
    enum CtrState
    {
        manual,
        autonomous,
        calibration,
        numStates
    }

    void Start()
    {
        // Grab the ROS Connection singleton
        ros = ROSConnection.GetOrCreateInstance();

        // Register the servo publisher and the outbound service calls we plan to make
        ros.RegisterPublisher<ServoCtrlMsgMsg>(manualDriveTopic);
        ros.RegisterRosService<ActiveStateSrvRequest, ActiveStateSrvResponse>(vehicleStateService);
        ros.RegisterRosService<EnableStateSrvRequest, EnableStateSrvResponse>(enableStateService);

        // Set the vehicle mode to "Manual Drive"
        ActiveStateSrvRequest vehicleStateSrvRequest = new ActiveStateSrvRequest((sbyte)CtrState.manual);
        ros.SendServiceMessage<ActiveStateSrvResponse>(vehicleStateService, vehicleStateSrvRequest);

        // Enable vehicle throttle
        enableVehicle = true;
        EnableStateSrvRequest enableStateSrvRequest = new EnableStateSrvRequest(enableVehicle);
        ros.SendServiceMessage<EnableStateSrvResponse>(enableStateService, enableStateSrvRequest);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Deactivating Manual Drive Mode");
        EnableStateSrvRequest enableStateSrvRequest = new EnableStateSrvRequest(false);
        ros.SendServiceMessage<EnableStateSrvResponse>(enableStateService, enableStateSrvRequest);
    }

    void Update()
    {
        OVRInput.Update();

        // Enable/disable the vehicle
        if ( OVRInput.GetDown(OVRInput.Button.One) )
        {
            enableVehicle = !enableVehicle;
            EnableStateSrvRequest enableStateSrvRequest = new EnableStateSrvRequest(enableVehicle);
            ros.SendServiceMessage<EnableStateSrvResponse>(enableStateService, enableStateSrvRequest);
        }

        // Update the throttle every 1/10th of a second
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= publishFrequency)
        {
            // Steering and throttle with right controller
            // Oculus coordinates seem reversed, though this might also mean calibration issues on my DeepRacer
            Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            ServoCtrlMsgMsg servoCtrlMsg = new ServoCtrlMsgMsg(-thumbstickInput.x, -thumbstickInput.y);
            ros.Publish(manualDriveTopic, servoCtrlMsg);

            timeElapsed = 0.0f;
        }
    }
}
