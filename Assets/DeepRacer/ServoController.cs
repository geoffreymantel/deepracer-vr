using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.DeepracerInterfacesPkg;

public class ServoController : MonoBehaviour
{
    private ROSConnection ros;
    private string manualDriveTopic = "webserver_pkg/manual_drive";
    private string vehicleStateService = "ctrl_pkg/vehicle_state";
    private string enableStateService = "ctrl_pkg/enable_state";

    public float publishFrequency = 0.5f;
    private float timeElapsed = 0.0f;

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

        // Enable the current vehicle mode
        EnableStateSrvRequest enableStateSrvRequest = new EnableStateSrvRequest(true);
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
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= publishFrequency)
        {
            // Luckily, both the OVR thumbstick and the DeepRacer servo control use float values of [-1, 1]
            Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            Debug.Log("Thumbstick input: x=" + thumbstickInput.x + ", y=" + thumbstickInput.y);
            ServoCtrlMsgMsg servoCtrlMsg = new ServoCtrlMsgMsg(thumbstickInput.y, thumbstickInput.x);
            //ServoCtrlMsgMsg servoCtrlMsg = new ServoCtrlMsgMsg(thumbstickInput.y, 0.8f);
            ros.Publish(manualDriveTopic, servoCtrlMsg);

            timeElapsed = 0.0f;
        }
    }
}
