//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class BeginSoftwareUpdateSrvResponse : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/BeginSoftwareUpdateSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Flag indicating if the software update is scheduled.
        public bool response_status;

        public BeginSoftwareUpdateSrvResponse()
        {
            this.response_status = false;
        }

        public BeginSoftwareUpdateSrvResponse(bool response_status)
        {
            this.response_status = response_status;
        }

        public static BeginSoftwareUpdateSrvResponse Deserialize(MessageDeserializer deserializer) => new BeginSoftwareUpdateSrvResponse(deserializer);

        private BeginSoftwareUpdateSrvResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.response_status);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.response_status);
        }

        public override string ToString()
        {
            return "BeginSoftwareUpdateSrvResponse: " +
            "\nresponse_status: " + response_status.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}
