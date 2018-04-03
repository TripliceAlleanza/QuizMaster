using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using QuizMaster___Server.Models;
using QuizMaster___Server.Networking;

namespace QuizMaster___Server.ViewModels {

	interface IGameViewModel {
		ObservableCollection<Client> Clients { get; }
	}

	class GameViewModel : IGameViewModel, INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<Client> Clients { get; private set; }

		private IOptionsViewModel optionsViewModel;
		private CommunicationsManager communicationsManager;

		public GameViewModel(IOptionsViewModel optionsViewModel) {
			this.optionsViewModel = optionsViewModel;
			communicationsManager = new CommunicationsManager();
			communicationsManager.MessageReceived += CommunicationsManagerOnMessageReceived;
		}

		private void CommunicationsManagerOnMessageReceived(Client client, string message) {
			var o = JObject.Parse(message);

			
		}

		private void ParseJSONCommand(Client client, string command, JObject data) {

		}

	}
}
