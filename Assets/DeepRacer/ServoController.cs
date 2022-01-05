using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.DeepracerInterfacesPkg;

public class ServoController : MonoBehaviour
{
    private ROSConnection ros;
    private string servoTopic = "ctrl_pkg/servo_msg";

    public float publishFrequency = 0.5f;
    private float timeElapsed = 0.0f;

    void Start()
    {
        // Grab the ROS Connection singleton
        ros = ROSConnection.GetOrCreateInstance();

        // Register the servo publisher
        ros.RegisterPublisher<ServoCtrlMsgMsg>(servoTopic);
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
            ros.Publish(servoTopic, servoCtrlMsg);

            timeElapsed = 0.0f;
        }
    }
}
