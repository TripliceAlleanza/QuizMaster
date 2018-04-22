using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace QuizMaster___SharedLibrary.QuizModel {
	public class DeployedQuizFormat {
		public string Name { get; set; } = "NO NAME";
		public string Surname { get; set; } = "NO SURNAME";
		public string QuizDate { get; set; } = "DD/MM/YYYY";
		public string Class { get; set; } = "NO CLASS"; //example: 4G-inf2
		public QuizFormat QuizData { get; set; }





		public static string ConvertToJson(ref DeployedQuizFormat quiz) {
			var serializersettings = new JsonSerializerSettings();
			//TODO: conditional serialization
			return JsonConvert.SerializeObject(quiz,serializersettings);
		}
	}
}
