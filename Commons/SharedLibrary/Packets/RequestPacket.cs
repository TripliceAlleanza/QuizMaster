using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace QuizMaster___SharedLibrary.Packets {
	public class RequestPacket : ISerializablePacket {

		public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
			{ContractResolver = new CamelCasePropertyNamesContractResolver()};


		public string Request { get; }
		public Dictionary<string, object> Data { get; set; }

		public RequestPacket(string request) {
			this.Request = request;
			this.Data = new Dictionary<string, object>();
		}

		public string Serialize() {
			return JsonConvert.SerializeObject(this, SerializerSettings);
		}
	}

	public interface ISerializablePacket {
		string Serialize();
	}
}
