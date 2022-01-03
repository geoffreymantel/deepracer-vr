//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class SetLedCtrlSrvResponse : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/SetLedCtrlSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Error flag indicating successful/failed service call.
        public int error;

        public SetLedCtrlSrvResponse()
        {
            this.error = 0;
        }

        public SetLedCtrlSrvResponse(int error)
        {
            this.error = error;
        }

        public static SetLedCtrlSrvResponse Deserialize(MessageDeserializer deserializer) => new SetLedCtrlSrvResponse(deserializer);

        private SetLedCtrlSrvResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.error);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.error);
        }

        public override string ToString()
        {
            return "SetLedCtrlSrvResponse: " +
            "\nerror: " + error.ToString();
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
