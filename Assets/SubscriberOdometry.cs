using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using SimpleJSON;
using ROSBridgeLib.nav_msgs;

public class SubscriberOdometry : ROSBridgeSubscriber
{
    // These two are important
    public new static string GetMessageTopic()
    {
        return "/unity/data/odometry";
        //return "/unity_odometry";
    }

    public new static string GetMessageType()
    {
        return "nav_msgs/Odometry";
    }

    public new static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        OdometryMsg odometry = new OdometryMsg(msg);
        return odometry;
    }

    public new static void CallBack(ROSBridgeMsg msg)
    {
        Debug.Log("Received: " + msg.ToYAMLString());
    }
}
