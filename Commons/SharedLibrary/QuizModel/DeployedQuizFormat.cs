using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace QuizMaster___SharedLibrary.QuizModel {
	//this model is used by the "client" and on the server to be stored when a "client" has finished the quiz 
	public class DeployedQuizFormat {

		public string Name { get; set; } = "NO NAME";
		public string Surname { get; set; } = "NO SURNAME";
		public string Date { get; set; } = "DD/MM/YYYY";
		public string Class { get; set; } = "NO CLASS"; //example: 4G-inf2

		//TODO: TimeLeft need to be used updeted to recover the quiz after a system crash...
		public string TimeLeft { get; set; } = "NO TIME LIMIT";
		public QuizFormat QuizData { get; set; }

		public DeployedQuizFormat() {
			QuizData = new QuizFormat();
		}

		public DeployedQuizFormat(string name, string surname, string date, string @class) {
			Name = name;
			Surname = surname;
			Date = date;
			Class = @class;
		}

		public DeployedQuizFormat(string name, string surname, string date, string @class, QuizFormat quizData) : this(name, surname, date, @class) {
			QuizData = quizData;
		}


		public override bool Equals(object obj) {
			var format = obj as DeployedQuizFormat;
			return format != null &&
				   Name == format.Name &&
				   Surname == format.Surname &&
				   Date == format.Date &&
				   Class == format.Class;
		}

		public override int GetHashCode() {
			int hashCode = 1037774552;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Date);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Class);
			hashCode = hashCode * -1521134295 + EqualityComparer<QuizFormat>.Default.GetHashCode(QuizData);
			QuizData.HashCode = hashCode;
			return hashCode;
		}

		public static bool operator ==(DeployedQuizFormat format1, DeployedQuizFormat format2) {
			return EqualityComparer<DeployedQuizFormat>.Default.Equals(format1, format2);
		}

		public static bool operator !=(DeployedQuizFormat format1, DeployedQuizFormat format2) {
			return !(format1 == format2);
		}
	}
}
