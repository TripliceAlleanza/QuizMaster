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
using QuizMaster___Server.Support;

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
			Clients = new ObservableCollection<Client>();
			communicationsManager = new CommunicationsManager();

			communicationsManager.MessageReceived += CommunicationsManagerOnMessageReceived;

			communicationsManager.Start();
		}

		private void CommunicationsManagerOnMessageReceived(IPAddress clientIP, int port, string message) {
			var o = JObject.Parse(message);
			var client = Clients.FirstOrDefault(c => c.IPAddress == clientIP) ?? new Client() {IPAddress = clientIP, Port = port};

			ParseJSONCommand(client, o["command"].Value<string>(), o["data"] as JObject);		
		}

		private void ParseJSONCommand(Client client, string command, JObject data) {
			if (command == "connect") {
				ConnectClient(client, data);
			}
		}

		private void ConnectClient(Client client, JObject data) {
			client.Name = data.Value<string>("name");
			client.Surname = data.Value<string>("surname");
			client.Class = data.Value<string>("class");
			client.ClientState =
				(ClientState) Enum.Parse(typeof(ClientState), data.Value<string>("state").CapitalizeFirstLetter());

			App.Current.Dispatcher.Invoke(() => Clients.Add(client));
		}
	}
}
