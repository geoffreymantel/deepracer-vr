//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.DeepracerInterfacesPkg
{
    [Serializable]
    public class SetCalibrationSrvRequest : Message
    {
        public const string k_RosMessageName = "deepracer_interfaces_pkg/SetCalibrationSrv";
        public override string RosMessageName => k_RosMessageName;

        //  Calibration type (steering/speed)
        public int cal_type;
        //  Maximum PWM value to be set as caibration.
        public int max;
        //  Mid PWM value to be set as caibration.
        public int mid;
        //  Minimum PWM value to be set as caibration.
        public int min;
        //  Polarity value to be set as caibration.
        public int polarity;

        public SetCalibrationSrvRequest()
        {
            this.cal_type = 0;
            this.max = 0;
            this.mid = 0;
            this.min = 0;
            this.polarity = 0;
        }

        public SetCalibrationSrvRequest(int cal_type, int max, int mid, int min, int polarity)
        {
            this.cal_type = cal_type;
            this.max = max;
            this.mid = mid;
            this.min = min;
            this.polarity = polarity;
        }

        public static SetCalibrationSrvRequest Deserialize(MessageDeserializer deserializer) => new SetCalibrationSrvRequest(deserializer);

        private SetCalibrationSrvRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.cal_type);
            deserializer.Read(out this.max);
            deserializer.Read(out this.mid);
            deserializer.Read(out this.min);
            deserializer.Read(out this.polarity);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.cal_type);
            serializer.Write(this.max);
            serializer.Write(this.mid);
            serializer.Write(this.min);
            serializer.Write(this.polarity);
        }

        public override string ToString()
        {
            return "SetCalibrationSrvRequest: " +
            "\ncal_type: " + cal_type.ToString() +
            "\nmax: " + max.ToString() +
            "\nmid: " + mid.ToString() +
            "\nmin: " + min.ToString() +
            "\npolarity: " + polarity.ToString();
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
