//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class SensorStatusCheckSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/SensorStatusCheckSrv";
        public override string RosMessageName => k_RosMessageName;


        public SensorStatusCheckSrvRequest()
        {
        }
        public static SensorStatusCheckSrvRequest Deserialize(MessageDeserializer deserializer) => new SensorStatusCheckSrvRequest(deserializer);

        private SensorStatusCheckSrvRequest(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "SensorStatusCheckSrvRequest: ";
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
