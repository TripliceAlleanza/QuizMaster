using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using QuizMaster___Server.Models;
using static System.Diagnostics.Debug;
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

		private void CommunicationsManagerOnMessageReceived(IPAddress clientIP, string message) {
			var o = JObject.Parse(message);
			var client = Clients.FirstOrDefault(c => c.IPAddress == clientIP) ?? new Client() {IPAddress = clientIP};


			ParseJSONCommand(client, o["command"].Value<string>(), o["data"] as JObject);		
		}

		private void ParseJSONCommand(Client client, string command, JObject data) {
			if (command == "connect") {
				WriteLine($"{client.IPAddress} sending command {command} and data {data}");
			}
		}

	}
}
