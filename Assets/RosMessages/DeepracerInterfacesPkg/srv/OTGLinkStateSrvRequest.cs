//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class OTGLinkStateSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/OTGLinkStateSrv";
        public override string RosMessageName => k_RosMessageName;


        public OTGLinkStateSrvRequest()
        {
        }
        public static OTGLinkStateSrvRequest Deserialize(MessageDeserializer deserializer) => new OTGLinkStateSrvRequest(deserializer);

        private OTGLinkStateSrvRequest(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "OTGLinkStateSrvRequest: ";
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
