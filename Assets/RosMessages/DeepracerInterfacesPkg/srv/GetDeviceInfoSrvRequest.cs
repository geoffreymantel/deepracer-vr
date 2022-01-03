//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class GetDeviceInfoSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/GetDeviceInfoSrv";
        public override string RosMessageName => k_RosMessageName;


        public GetDeviceInfoSrvRequest()
        {
        }
        public static GetDeviceInfoSrvRequest Deserialize(MessageDeserializer deserializer) => new GetDeviceInfoSrvRequest(deserializer);

        private GetDeviceInfoSrvRequest(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "GetDeviceInfoSrvRequest: ";
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