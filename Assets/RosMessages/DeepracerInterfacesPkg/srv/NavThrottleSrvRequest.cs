//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class NavThrottleSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/NavThrottleSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Throttle percentage scale value.
        public float throttle;

        public NavThrottleSrvRequest()
        {
            this.throttle = 0.0f;
        }

        public NavThrottleSrvRequest(float throttle)
        {
            this.throttle = throttle;
        }

        public static NavThrottleSrvRequest Deserialize(MessageDeserializer deserializer) => new NavThrottleSrvRequest(deserializer);

        private NavThrottleSrvRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.throttle);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.throttle);
        }

        public override string ToString()
        {
            return "NavThrottleSrvRequest: " +
            "\nthrottle: " + throttle.ToString();
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
