using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster___SharedLibrary.QuizModel.Extensions {
	public static class QuizModelExtensions {
		public static string Serialize(this QuizFormat quiz) => JsonConvert.SerializeObject(quiz, new JsonSerializerSettings { ContractResolver = new MyContractResolver("RightAnswer") });
		public static string Serialize(this DeployedQuizFormat quiz) => JsonConvert.SerializeObject(quiz);
		public static void SetHashCode(this QuizFormat quiz) => quiz.HashCode = quiz.GetHashCode();

	}


	//REMEMBER if it ain't broke don't fix it!
	class MyContractResolver : DefaultContractResolver {
		public string PropertyName { get; set; }
		public MyContractResolver(string name) {
			PropertyName = name;
		}
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
			IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
			// only serializer properties that start with the specified character
			properties = properties.Where(p => p.PropertyName.StartsWith(PropertyName)).ToList();
			return properties;
		}
	}
}
