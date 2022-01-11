using UnityEngine;
using UnityEngine.UI;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.DeepracerInterfacesPkg;
using RosMessageTypes.Sensor;

// Currently only has support for a single camera - donations of code or camera are welcome!
public class CameraController : MonoBehaviour
{
    public RawImage cameraImage;

    private ROSConnection ros;
    private string mediaStateService = "camera_pkg/media_state";
    private string cameraTopic = "camera_pkg/video_mjpeg";

    void Start()
    {
        // Grab the ROS Connection singleton
        ros = ROSConnection.GetOrCreateInstance();

        // Activate the camera and have it start publishing images
        ros.RegisterRosService<VideoStateSrvRequest, VideoStateSrvResponse>(mediaStateService);

        VideoStateSrvRequest videoStateSrvRequest = new VideoStateSrvRequest(1);
        ros.SendServiceMessage<VideoStateSrvResponse>(mediaStateService, videoStateSrvRequest, VideoStateCallback);
    }

    void OnApplicationQuit()
    {
        Debug.Log("Deactivating DeepRacer Camera");
        VideoStateSrvRequest videoStateSrvRequest = new VideoStateSrvRequest(0);
        ros.SendServiceMessage<VideoStateSrvResponse>(mediaStateService, videoStateSrvRequest);
    }

    private void VideoStateCallback(VideoStateSrvResponse response)
    {
        if ( response.error != 0 ) {
            Debug.LogError("Error activating DeepRacer Camera: " + response.error);
        } else {
            Debug.Log("Subscribing to DeepRacer camera topic");
            ros.Subscribe<CameraMsgMsg>(cameraTopic, CameraTopicCallback);
        }
    }

    private void CameraTopicCallback(CameraMsgMsg cameraMsg)
    {
        ImageMsg image = cameraMsg.images[0];

        // Create the texture if it doesn't already exist
        if (cameraImage.texture == null) {
            cameraImage.texture = new Texture2D((int)image.width, (int)image.height, TextureFormat.BGRA32, false);
        }

        // Must add the alpha byte to each pixel manually. Seems like a pain, but should be fast
        int sourceIndex = 0;
        int targetIndex = 0;
        var targetData = ((Texture2D)cameraImage.texture).GetRawTextureData<byte>();
        for (int y = 0; y < image.height; y++)
        {
            for (int x = 0; x < image.width; x++)
            {
                targetData[targetIndex++] = image.data[sourceIndex++]; // Blue
                targetData[targetIndex++] = image.data[sourceIndex++]; // Green
                targetData[targetIndex++] = image.data[sourceIndex++]; // Red
                targetData[targetIndex++] = 255; // Alpha
            }
        }
        ((Texture2D)cameraImage.texture).Apply();
    }

}