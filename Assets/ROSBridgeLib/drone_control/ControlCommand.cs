using System.Collections;
using System.Text;
using SimpleJSON;
using UnityEngine;

/*
		Constructeur du message pour le topic des commandes du drone
 */

namespace ROSBridgeLib
{
    namespace drone_control
    {
        public class ControlCommand : ROSBridgeMsg
        {
            public int _command;
            public double[] _params;

            public ControlCommand()
            {
                _command = 0;
                _params = new double[] { };
            }

            public ControlCommand(JSONNode msg)
            {
                _command = msg["command"].AsInt;
                for (int i = 0; i < msg["params"].Count; i++)
                {
                    _params[i] = double.Parse(msg["params"][i]);
                }
            }

            public ControlCommand(int command, double[] param)
            {
                _command = command;
                _params = param;

            }

            public int GetCommand()
            {
                return _command;
            }

            public double[] GetParams()
            {
                return _params;
            }


            public void setOperation_mode(double op_mode)
            {
                _command = 0;
                _params = new double[] { op_mode };
            }

            public void arm()
            {
                _command = 1;
            }

            public void disarm()
            {
                _command = 2;
            }

            public void takeoff(double altitude)
            {
                _command = 3;
                _params = new double[] { altitude };
            }

            public void land(double altitude)
            {
                _command = 4;
                _params = new double[] { altitude };
            }

            public void setPointPosition(double x, double y, double z, double yaw)
            {
                _command = 5;
                _params = new double[] { x, y, z, yaw };
            }

            public static string GetMessageType()
            {
                return "drone_control/ControlCommand";
            }

            public override string ToString()
            {
                string array = "[";
                for (int i = 0; i < _params.Length; i++)
                {
                    array = array + _params[i].ToString();
                    if (_params.Length - i > 1) array += ",";
                }
                array += "]";
                return "ControlCommand [command=" + _command +
                        ", params=" + array + "]";
            }

            // Structure de la commande à envoyer à ROS (just like YAML file)
            public override string ToYAMLString()
            {
                string array = "[";
                for (int i = 0; i < _params.Length; i++)
                {
                    array = array + _params[i].ToString();
                    if (_params.Length - i > 1) array += ",";
                }
                array += "]";
                return "{\"command\" :" + _command +
                        ", \"params\" :" + array + "}";
            }
        }
    }
}

