using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using SimpleJSON;
using ROSBridgeLib.std_msgs;

public class VelocityPublisher : ROSBridgePublisher
{
    public new static string GetMessageTopic()
    {
        return "/unity/control/velocity";
    }

    public new static string GetMessageType()
    {
        return "drone_control/ControlVelocity";
    }

    public static string ToYAMLString(StringMsg msg)
    {
        return msg.ToYAMLString();
    }
}



