using System.Collections;
using System.Text;
using SimpleJSON;
using UnityEngine;

/*
		Constructeur du message pour le topic des contrôles de vélocité du drone
 */

namespace ROSBridgeLib
{
    namespace drone_control
    {
        public class ControlVelocity : ROSBridgeMsg
        {
            public double _axis_x;
            public double _axis_y;
            public double _axis_z;
            public double _yaw;

            public ControlVelocity(JSONNode msg)
            {
                _axis_x = double.Parse(msg["axis_x"]);
                _axis_y = double.Parse(msg["axis_y"]);
                _axis_z = double.Parse(msg["axis_z"]);
                _yaw = double.Parse(msg["yaw"]);
            }

            public ControlVelocity(double axis_x, double axis_y, double axis_z, double yaw)
            {
                _axis_x = axis_x;
                _axis_y = axis_y;
                _axis_z = axis_z;
                _yaw = yaw;
            }

            public double GetAxisX()
            {
                return _axis_x;
            }

            public double GetAxisY()
            {
                return _axis_y;
            }

            public double GetAxisZ()
            {
                return _axis_z;
            }

            public double GetYaw()
            {
                return _yaw;
            }

            public static string GetMessageType()
            {
                return "drone_control/ControlVelocity";
            }

            public override string ToString()
            {
                return "ControlVelocity [axis_x=" + _axis_x +
                                "axis_y=" + _axis_y +
                                "axis_z=" + _axis_z +
                                "yaw=" + _yaw + "]";
            }

            // Structure de la commande à envoyer à ROS (just like YAML file)
            public override string ToYAMLString()
            {
                return "{\"axis_x\" :" + _axis_x +
                                ", \"axis_y\" :" + _axis_y +
                                ", \"axis_z\" :" + _axis_z +
                                ", \"yaw\" :" + _yaw + "}";
            }
        }
    }
}

