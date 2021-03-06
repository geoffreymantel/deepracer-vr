//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class BatteryLevelSrvResponse : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/BatteryLevelSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Current vehicle battery level information.
        public int level;

        public BatteryLevelSrvResponse()
        {
            this.level = 0;
        }

        public BatteryLevelSrvResponse(int level)
        {
            this.level = level;
        }

        public static BatteryLevelSrvResponse Deserialize(MessageDeserializer deserializer) => new BatteryLevelSrvResponse(deserializer);

        private BatteryLevelSrvResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.level);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.level);
        }

        public override string ToString()
        {
            return "BatteryLevelSrvResponse: " +
            "\nlevel: " + level.ToString();
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
