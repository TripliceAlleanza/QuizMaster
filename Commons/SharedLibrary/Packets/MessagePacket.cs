using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizMaster___SharedLibrary.Packets {
	public class MessagePacket : ISerializablePacket {

		public string Message { get; set; }
		public Dictionary<string, object> Data { get; set; }

		public MessagePacket(string message, Dictionary<string, object> data) {
			Message = message;
			Data = data;
		}

		public MessagePacket(string message) : this(message, new Dictionary<string, object>()) {

		}

		public MessagePacket() : this("") {
			
		}
		public string Serialize() {
			return JsonConvert.SerializeObject(this, RequestPacket.SerializerSettings);
		}
	}
}
