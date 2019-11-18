using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using SimpleJSON;
using ROSBridgeLib.std_msgs;

public class PublisherTest : ROSBridgePublisher
{
    public new static string GetMessageTopic()
    {
        return "/unity/string_receive";
    }

    public new static string GetMessageType()
    {
        return "std_msgs/String";
    }

    public new static string ToYAMLString(StringMsg msg)
    {
        return msg.ToYAMLString();
    }
}



