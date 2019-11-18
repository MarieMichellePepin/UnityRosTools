using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;
using UnityEngine;

/*
 On va avoir besoin de créer l'objet Velocity dans sensor_msgs
 */

namespace ROSBridgeLib {
	namespace sensor_msgs {
		public class VelocityMsg : ROSBridgeMsg {
			public HeaderMsg _header;
			public Float64Msg _axis_x;
			public Float64Msg _axis_y;
			public Float64Msg _axis_z;
			public Float64Msg _yaw;

			public VelocityMsg(JSONNode msg) {
				//Debug.Log("VelocityMsg with " + msg.ToString());

               	//_header = new HeaderMsg(msg["header"]);
				//_axis_x = new double(msg["axis_x"]);
				//_axis_y = new double(msg["axis_y"]);
				//_axis_z = new double(msg["axis_z"]);
				//_yaw = new double(msg["yaw"]);
				//Debug.Log("VelocityMsg done and it looks like " + this.ToString());
            }

			public VelocityMsg(HeaderMsg header, double axis_x, double axis_y, double axis_z, double yaw) {
             	_header = header;
                _axis_x = new Float64Msg(axis_x);
				_axis_y = new Float64Msg(axis_y);
                _axis_z = new Float64Msg(axis_z);
                _yaw = new Float64Msg(yaw);
            }
			

		    public HeaderMsg GetHeader() {
				return _header;
		    }

			public double GetAxisX(){
				return _axis_x.GetData();
		    }

			public double GetAxisY(){
				return _axis_y.GetData();
		    }
			
			public double GetAxisZ(){
				return _axis_z.GetData();
		    }

			public double GetYaw(){
				return _yaw.GetData();
		    }


            public static string GetMessageType() {
				return "drone_control/ControlVelocity";
			}

			public override string ToString() {
				return "VelocityMsg [header=" + _header.ToString() +
						"axis_x=" + _axis_x +
						"axis_y=" + _axis_y +
						"axis_z=" + _axis_z +
						"yaw=" + _yaw + "]";
			}

			public override string ToYAMLString() {
				return "{\"header\" :" + _header.ToYAMLString() +
						"\"axis_x\" :" + _axis_x +
						"\"axis_y\" :" + _axis_y +
						"\"axis_z\" :" + _axis_z +
						"\"yaw\" :" + _yaw + "}";
			}
		}
	}
}
