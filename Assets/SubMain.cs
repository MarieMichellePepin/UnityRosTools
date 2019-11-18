using UnityEngine;
using UnityEngine.UI;

using ROSBridgeLib;
using ROSBridgeLib.drone_control;

public class SubMain : MonoBehaviour
{
    public Text ConnectionStatus;
    private ROSBridgeWebSocketConnection ros = null;
    private bool started;
    void Start()
    {
        Application.runInBackground = true;
        Screen.fullScreen = false;
        ConnectionStatus.text = "Press START to connect";
    }

    // Extremely important to disconnect from ROS. Otherwise packets continue to flow
    void OnApplicationQuit()
    {
        if (ros != null)
        {
            ros.Disconnect();
        }
    }
    // Update is called once per frame in Unity
    void Update()
    {
        
        if (!started && Input.GetButtonDown("Start"))
        {
            ConnectionStatus.text = "Connected";
          	started = true;
            ros = new ROSBridgeWebSocketConnection("ws://localhost", 8080);

            ros.AddPublisher(typeof(CommandPublisher));
			ros.AddPublisher(typeof(VelocityPublisher));

            // Fire up the subscriber(s) and publisher(s)
            ros.Connect(); 
        }

        ControlCommand command_msg = GetControlCommand();
        Debug.Log("Sending: " + command_msg.ToYAMLString());
        ControlVelocity velocity_msg = new ControlVelocity(GetPitch(), GetRoll(), GetThrottle(), GetYaw());
        Debug.Log("Sending: " + velocity_msg.ToYAMLString());

        // Publish it (ros is the object defined in the first class)
        ros.Publish(CommandPublisher.GetMessageTopic(), command_msg);
		ros.Publish(VelocityPublisher.GetMessageTopic(), velocity_msg);

        ros.Render();
    }

    double GetThrottle()
    {
        return Input.GetAxisRaw("RT") - Input.GetAxisRaw("LT");
    }

    double GetYaw()
    {
        return Input.GetAxisRaw("RB") - Input.GetAxisRaw("LB");
    }

    double GetPitch()
    {
        return - Input.GetAxisRaw("LS_v");
    }

    double GetRoll()
    {
        return Input.GetAxisRaw("LS_h");
    }

    ControlCommand GetControlCommand()
    {
        ControlCommand command_msg = new ControlCommand();

        if(Input.GetButtonDown("A"))
        {
            command_msg.arm();
        }
        else if(Input.GetButtonDown("B"))
        {
            command_msg.disarm();
        }
        else if(Input.GetButtonDown("X"))
        {
            command_msg.takeoff(0);
        }
        else if(Input.GetButtonDown("Y"))
        {
            command_msg.land(0);
        }

        return command_msg;
    }
}




