using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace QuizMaster___Server.WorkInProgress {
	enum Components {
		NOTDEFINED,TextBox, ComboBox, RadioButton, Match, Image
	}

	class QuestionFormat {
		public int QuestionNumber { get; set; } = 0;
		public string Question { get; set; } = "NO QUESTION";
		public AnswerOption[] AnswerOptions { get; set; }

		public QuestionFormat() {
			
		}

	}

	[JsonObject(MemberSerialization.OptOut)]
	class AnswerOption {
		public Byte AnswerNumber { get; set; } = 0;
		public Components ComponentName { get; set; } = Components.NOTDEFINED;
		public string Text { get; set; } = "NOT DEFINED YET!";
		[JsonIgnore]public bool RightAnswer { get; set; } = false;

		public AnswerOption() {
		}

	}
}
		
