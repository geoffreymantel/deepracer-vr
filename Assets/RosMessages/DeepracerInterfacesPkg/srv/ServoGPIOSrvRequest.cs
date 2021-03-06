//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class ServoGPIOSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/ServoGPIOSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Flag to enable/disable the GPIO port for servo/motor.
        public int enable;

        public ServoGPIOSrvRequest()
        {
            this.enable = 0;
        }

        public ServoGPIOSrvRequest(int enable)
        {
            this.enable = enable;
        }

        public static ServoGPIOSrvRequest Deserialize(MessageDeserializer deserializer) => new ServoGPIOSrvRequest(deserializer);

        private ServoGPIOSrvRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.enable);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.enable);
        }

        public override string ToString()
        {
            return "ServoGPIOSrvRequest: " +
            "\nenable: " + enable.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
