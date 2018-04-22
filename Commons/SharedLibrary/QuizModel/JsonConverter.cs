using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace QuizMaster___SharedLibrary.QuizModel {
	public class JsonConverter {
		public static string SerializeToJson(ref object quiz) {
			//TODO: Work IN PROGRESS	
			if (quiz is QuizFormat) {
				return JsonConvert.SerializeObject(quiz,new JsonSerializerSettings { ContractResolver = new MyContractResolver("RightAnswer") });
			}
			else return JsonConvert.SerializeObject(quiz);
		}
		public static object DeserializeFromJson(ref string str) {
			//TODO: finish this...
			return JsonConvert.DeserializeObject(str);

		}
	}
	public class MyContractResolver : DefaultContractResolver {
		public string PropertyName { get; set; }

		public MyContractResolver(string name) {
			PropertyName = name;
		}

		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
			IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

			// only serializer properties that start with the specified character
			properties =
				properties.Where(p => p.PropertyName.StartsWith(PropertyName)).ToList();

			return properties;
		}
	}
}
