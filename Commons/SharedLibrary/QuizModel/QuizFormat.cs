using System.Collections.Generic;
using Newtonsoft.Json;
namespace QuizMaster___SharedLibrary.QuizModel {
	public class QuizFormat {
		public int Id { get; set; }
		public string QuizName { get; set; } = "NO NAME";
		public bool Randomize { get; set; } = false;
		public string QuizTimeLimit { get; set; } = "NO TIME LIMIT";
		public virtual int HashCode { get; set; } = 0;
		public List<QuestionFormat> Questions { get; set; }

		public QuizFormat() {

		}

		public QuizFormat(string quizName, bool randomize, string quizTimeLimit) {
			QuizName = quizName ?? "NO NAME";
			Randomize = randomize;
			QuizTimeLimit = quizTimeLimit ?? "NO TIME LIMIT";
		}

		public QuizFormat(string quizName, bool randomize, string quizTimeLimit, List<QuestionFormat> questions) : this(quizName, randomize, quizTimeLimit) {
			Questions = questions;
		}

		public override string ToString() => QuizName;

		public override bool Equals(object obj) {
			var format = obj as QuizFormat;
			return format != null &&
				   QuizName == format.QuizName &&
				   Randomize == format.Randomize &&
				   QuizTimeLimit == format.QuizTimeLimit;
		}

		public override int GetHashCode() {
			int hashCode = 16243256;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QuizName);
			hashCode = hashCode * -1521134295 + Randomize.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QuizTimeLimit);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<QuestionFormat>>.Default.GetHashCode(Questions);
			HashCode = hashCode;
			return hashCode;
		}

		public static bool operator ==(QuizFormat format1, QuizFormat format2) {
			return EqualityComparer<QuizFormat>.Default.Equals(format1, format2);
		}

		public static bool operator !=(QuizFormat format1, QuizFormat format2) {

			return !(format1 == format2);

		}

		public static string ConvertToJson(ref QuizFormat quiz) {
			return JsonConvert.SerializeObject(quiz);
		}
	}
}
