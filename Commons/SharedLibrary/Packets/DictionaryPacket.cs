using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QuizMaster___SharedLibrary.Packets {
	public class DictionaryPacket : Dictionary<string, object>, ISerializablePacket {

		public string Serialize() {
			return JsonConvert.SerializeObject(this);
		}

	}
}
