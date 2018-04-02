using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster___Server.ViewModels {
	interface IMainWindowViewModel {
		bool AllowReturn { get;}
		string CurrentIP { get; }
		int NumberOfPCs { get; }
	}

	class MainWindowViewModel : IMainWindowViewModel {
		public bool AllowReturn { get; set; }
		public string CurrentIP { get; private set; }
		public int NumberOfPCs { get; set; }


		public RelayCommand StartGame { get; private set; }


		public MainWindowViewModel() {
			// get current IP and show it
			Networking.Networking.GetLocalIPAddressAsync().ContinueWith(t => CurrentIP = t.Result);
			StartGame = new RelayCommand(StartGameMethod, o => CurrentIP != null);

		}

		private void StartGameMethod(object obj) {
			
		}
	}
}