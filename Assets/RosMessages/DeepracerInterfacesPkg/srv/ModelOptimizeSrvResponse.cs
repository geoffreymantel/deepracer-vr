//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class ModelOptimizeSrvResponse : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/ModelOptimizeSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Path where the interemediate representation xml file for the model will be created.
        public string artifact_path;
        //  Error flag indicating successful/failed service call.
        public int error;

        public ModelOptimizeSrvResponse()
        {
            this.artifact_path = "";
            this.error = 0;
        }

        public ModelOptimizeSrvResponse(string artifact_path, int error)
        {
            this.artifact_path = artifact_path;
            this.error = error;
        }

        public static ModelOptimizeSrvResponse Deserialize(MessageDeserializer deserializer) => new ModelOptimizeSrvResponse(deserializer);

        private ModelOptimizeSrvResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.artifact_path);
            deserializer.Read(out this.error);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.artifact_path);
            serializer.Write(this.error);
        }

        public override string ToString()
        {
            return "ModelOptimizeSrvResponse: " +
            "\nartifact_path: " + artifact_path.ToString() +
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