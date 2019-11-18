using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using SimpleJSON;
using ROSBridgeLib.std_msgs;

public class CommandPublisher : ROSBridgePublisher
{

    public new static string GetMessageTopic()
    {
        return "/unity/control/command";
    }

    public new static string GetMessageType()
    {
        return "drone_control/ControlCommand";
    }

    public static string ToYAMLString(StringMsg msg)
    {
        return msg.ToYAMLString();
    }
}
