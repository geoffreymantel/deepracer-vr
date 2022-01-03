//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class SetLedCtrlSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/SetLedCtrlSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Tail LED PWM value for RED channel.
        public int red;
        //  Tail LED PWM value for BLUE channel.
        public int green;
        //  Tail LED PWM value for GREEN channel.
        public int blue;

        public SetLedCtrlSrvRequest()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 0;
        }

        public SetLedCtrlSrvRequest(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public static SetLedCtrlSrvRequest Deserialize(MessageDeserializer deserializer) => new SetLedCtrlSrvRequest(deserializer);

        private SetLedCtrlSrvRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.red);
            deserializer.Read(out this.green);
            deserializer.Read(out this.blue);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.red);
            serializer.Write(this.green);
            serializer.Write(this.blue);
        }

        public override string ToString()
        {
            return "SetLedCtrlSrvRequest: " +
            "\nred: " + red.ToString() +
            "\ngreen: " + green.ToString() +
            "\nblue: " + blue.ToString();
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
