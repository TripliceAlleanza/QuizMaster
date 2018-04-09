using System.Collections.Generic;

namespace QuizMaster___SharedLibrary.QuizModel {
	public class QuizFormat {
		public int Id { get; set; }
		public string QuizName { get; set; } = "NO NAME";
		public string Class { get; set; } = "NO CLASS"; // what the fuck is this? -> I'll explain it to you tomorrow ;-)
		public bool Randomize { get; set; } = false;
		public string QuizTimeLimit { get; set; } = "NO TIME LIMIT";
		public List<QuestionFormat> Questions { get; set; }

		public QuizFormat() {
			
		}

		public QuizFormat(string quizName, string @class, bool randomize, string quizTimeLimit) {
			QuizName = quizName ?? "NO NAME";
			Class = @class ?? "NO CLASS";
			Randomize = randomize;
			QuizTimeLimit = quizTimeLimit ?? "NO TIME LIMIT";
		}
		public QuizFormat(string quizName, string @class, bool randomize, string quizTimeLimit, List<QuestionFormat> questions) : this(quizName, @class, randomize, quizTimeLimit) {
			Questions = questions;
		}

		public override string ToString() => QuizName + " " + Class;

		public override bool Equals(object obj) {
			var format = obj as QuizFormat;
			return format != null &&
				   QuizName == format.QuizName &&
				   Class == format.Class &&
				   Randomize == format.Randomize &&
				   QuizTimeLimit == format.QuizTimeLimit;
		}

		public override int GetHashCode() {
			int hashCode = 16243256;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QuizName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Class);
			hashCode = hashCode * -1521134295 + Randomize.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(QuizTimeLimit);
			hashCode = hashCode * -1521134295 + EqualityComparer<List<QuestionFormat>>.Default.GetHashCode(Questions);
			return hashCode;
		}

		public static bool operator ==(QuizFormat format1, QuizFormat format2) {
			return EqualityComparer<QuizFormat>.Default.Equals(format1, format2);
		}

		public static bool operator !=(QuizFormat format1, QuizFormat format2) {
			return !(format1 == format2);
		}


	}
}
