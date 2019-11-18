using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;
using UnityEngine;

/*
 On va avoir besoin de créer l'objet command dans sensor_msgs
 */

namespace ROSBridgeLib {
	namespace sensor_msgs {
		public class CommandMsg : ROSBridgeMsg {
			public HeaderMsg _header;
			public Int32Msg _command;
			public Float64Msg[] _params;

			public CommandMsg(JSONNode msg) {
				//Debug.Log("CommandMsg with " + msg.ToString());

               	_header = new HeaderMsg(msg["header"]);
				_command = new Int32Msg(msg["command"]);
				_params = new Float64Msg[msg["params"].Count];
                for (int i = 0; i < _params.Length; i++) {
                    _params[i] = new Float64Msg(msg["params"][i]);
                }
				//Debug.Log("CommandMsg done and it looks like " + this.ToString());
            }

			public CommandMsg(HeaderMsg header, Int32Msg command, Float64Msg[] param) {
                		_header = header;
               		 	_command = command;
						_params = param;
            }
			
		    public HeaderMsg GetHeader() {
				return _header;
		    }

			public Int32Msg GetCommand()
		    {
				return _command;
		    }

			public Float64Msg[] GetParams()
            {
                return _params;
            }


            public static string GetMessageType() {
				return "sensor_msgs/Command";
			}

			public override string ToString() {
				return "CommandMsg [header=" + _header.ToString() +
						"command=" + _command.ToString() +
						"params=" + _params + "]";
			}

			public override string ToYAMLString() {
				return "{\"header\" :" + _header.ToYAMLString() +
						"\"command\" :" + _command.ToYAMLString() + "}";
			}
		}
	}
}
