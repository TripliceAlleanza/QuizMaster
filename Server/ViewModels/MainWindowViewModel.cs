using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaster___Server.Views;

namespace QuizMaster___Server.ViewModels {
	interface IOptionsViewModel {
		bool AllowReturn { get;}
		string CurrentIP { get; }
		int NumberOfPCs { get; }
	}

	class MainWindowViewModel : IOptionsViewModel {
		public bool AllowReturn { get; set; }
		public string CurrentIP { get; private set; }
		public int NumberOfPCs { get; set; }


		public RelayCommand StartGameCommand { get; }
		public RelayCommand OpenEditorCommand { get; }


		public MainWindowViewModel() {
			// get current IP and show it
			Networking.Networking.GetLocalIPAddressAsync().ContinueWith(t => CurrentIP = t.Result);
			StartGameCommand = new RelayCommand(StartGameMethod, o => CurrentIP != null);

			// replace with method
			OpenEditorCommand = new RelayCommand(o => {
				var editor = new QuizEditor();
				editor.Show();
			}, o => true);
		}

		private void StartGameMethod(object obj) {
			var quiz = new AvviaQuiz();
			quiz.Show();
		}
	}
}