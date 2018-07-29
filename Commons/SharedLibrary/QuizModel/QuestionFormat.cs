using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace QuizMaster___SharedLibrary.QuizModel {
	public enum Components {
		NOTDEFINED,TextBox, ComboBox, RadioButton, Match, Image
	}

	 public class QuestionFormat {
		public int QuestionNumber { get; set; } = 0;
		public string Question { get; set; } = "NO QUESTION";
		public AnswerOption[] AnswerOptions { get; set; }

		public QuestionFormat() {
			
		}
	}

	[JsonObject(MemberSerialization.OptOut)]
	public class AnswerOption {
		public Byte AnswerNumber { get; set; } = 0;
		public Components ComponentName { get; set; } = Components.NOTDEFINED;
		public string Text { get; set; } = "NOT DEFINED YET!";
		public bool? RightAnswer { get; set; } = null;	

		public AnswerOption() {
			
		}

	}
}
		
