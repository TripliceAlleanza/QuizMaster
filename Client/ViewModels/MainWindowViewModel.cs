using System.Diagnostics;
using QuizMaster___Client.Models;
using QuizMaster___SharedLibrary.MVVM;

namespace QuizMaster___Client.ViewModels {
	public class MainWindowViewModel {

		public Client MeClient { get; set; }
		public RelayCommand AvviaTestCommand { get; private set; }

		public MainWindowViewModel() {
			MeClient = new Client();
			AvviaTestCommand = new RelayCommand(AvviaTest, o =>
					true
				//BUG !(string.IsNullOrEmpty(MeClient.Cognome) || string.IsNullOrEmpty(MeClient.Nome))
			);
		}

		private void AvviaTest(object obj) {
			Debug.WriteLine("Avviato test");
		}
	}
}
