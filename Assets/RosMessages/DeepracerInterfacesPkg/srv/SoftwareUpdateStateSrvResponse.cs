//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class SoftwareUpdateStateSrvResponse : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/SoftwareUpdateStateSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Identifier with the current software update state details.
        public int update_state;

        public SoftwareUpdateStateSrvResponse()
        {
            this.update_state = 0;
        }

        public SoftwareUpdateStateSrvResponse(int update_state)
        {
            this.update_state = update_state;
        }

        public static SoftwareUpdateStateSrvResponse Deserialize(MessageDeserializer deserializer) => new SoftwareUpdateStateSrvResponse(deserializer);

        private SoftwareUpdateStateSrvResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.update_state);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.update_state);
        }

        public override string ToString()
        {
            return "SoftwareUpdateStateSrvResponse: " +
            "\nupdate_state: " + update_state.ToString();
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
