using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using SimpleJSON;
using ROSBridgeLib.sensor_msgs;

public class SubscriberTest : ROSBridgeSubscriber
{
    // These two are important
    public new static string GetMessageTopic()
    {
        return "/unity/data/pointcloud";
    }

    public new static string GetMessageType()
    {
        return "sensor_msgs/PointCloud2";
    }

    public new static ROSBridgeMsg ParseMessage(JSONNode msg)
    {
        PointCloudMsg pointCloud = new PointCloudMsg(msg);
        return pointCloud;
    }

    // This function should fire on each ros message
    public new static void CallBack(ROSBridgeMsg msg)
    {
        Debug.Log("Received: " + msg.ToYAMLString());
    }
}
