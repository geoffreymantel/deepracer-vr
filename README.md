# deepracer-vr
Unity-based Oculus VR interface to AWS DeepRacer

#### Setting up ROS TCP Endpoint for Unity on the DeepRacer unit

1. Ensure that the DeepRacer unit is upgraded to ROS2 support, following following the instructions [here](https://docs.aws.amazon.com/deepracer/latest/developerguide/deepracer-ubuntu-update-instructions.html).

2. SSH into the DeepRacer unit as `deepracer`

3. Set up a ROS2 workspace under `/home/deepracer/developer_ws`.

4. Make an `src` directory, and switch to it. Clone the ROS2 branch of the TCP endpoint project into the workspace:

   ```
   git clone https://github.com/Unity-Technologies/ROS-TCP-Endpoint.git -b ROS2
   ```

5. Build the package: `colcon build`.
6. Add the new package to the path: `source /home/deepracer/developer_ws/install/setup.bash`
7. Execute the package: `ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ROS_IP:=0.0.0.0`. This will launch the Unity TCP endpoint server on port 10000, bound to all network interfaces (required for external connection).
8. For permanent operation, the following needs to be added to the `start_ros.sh` script: `roslaunch ros_tcp_endpoint endpoint.launch`
9. Note, DeepRacer is also running Ubuntu's firewall. To enable incoming connections to the ROS Unity TCP endpoint server, you'll need to execute: `sudo ufw allow 10000/tcp`

