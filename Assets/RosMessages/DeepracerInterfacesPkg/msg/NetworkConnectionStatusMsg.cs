//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class NetworkConnectionStatusMsg : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/NetworkConnectionStatus";
        public override string RosMessageName => k_RosMessageName;

        //  Custom message with network connection details.
        // 
        //  This message is used to communicate if the device is currently
        //  connected to network. 
        public bool network_connected;
        //  True if connected to the network else False.

        public NetworkConnectionStatusMsg()
        {
            this.network_connected = false;
        }

        public NetworkConnectionStatusMsg(bool network_connected)
        {
            this.network_connected = network_connected;
        }

        public static NetworkConnectionStatusMsg Deserialize(MessageDeserializer deserializer) => new NetworkConnectionStatusMsg(deserializer);

        private NetworkConnectionStatusMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.network_connected);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.network_connected);
        }

        public override string ToString()
        {
            return "NetworkConnectionStatusMsg: " +
            "\nnetwork_connected: " + network_connected.ToString();
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
