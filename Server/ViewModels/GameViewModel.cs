using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizMaster___Server.Models;
using QuizMaster___Server.Networking;
using QuizMaster___SharedLibrary.Packets;

namespace QuizMaster___Server.ViewModels {
	interface IGameViewModel {
		ObservableCollection<Client> Clients { get; }
	}

	class GameViewModel : IGameViewModel, INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<Client> Clients { get; private set; }

		private IOptionsViewModel optionsViewModel;
		private CommunicationsManager communicationsManager;
		private Thread broadcastConnectionThread;


		public GameViewModel(IOptionsViewModel optionsViewModel) {
			this.optionsViewModel = optionsViewModel;
			Clients = new ObservableCollection<Client>();
			communicationsManager = new CommunicationsManager();

			communicationsManager.MessageReceived += CommunicationsManagerOnMessageReceived;

			communicationsManager.Start();
		}

		private void CommunicationsManagerOnMessageReceived(IPAddress clientIP, int port, string message) {
			var client = Clients.FirstOrDefault(c => c.IPAddress == clientIP) ?? new Client() {
				IPAddress = clientIP,
				Port = port
			};

			ParseJSONCommand(client, JsonConvert.DeserializeObject<RequestPacket>(message));
		}

		private void ParseJSONCommand(Client client, RequestPacket data) {
			if (data.Request == "connect") {
				ConnectClient(client, data);
			}

			if (data.Request == "ping") {
				communicationsManager.SendData(client.IPAddress, new MessagePacket("ok").Serialize());
			}
		}

		private async Task ConnectClient(Client client, RequestPacket data) {
			client.Name = data.Data["name"] as string;
			client.Surname = data.Data["surname"] as string;
			client.ClientState = ClientState.Waiting;

			var responsePacket = new MessagePacket(Clients.Contains(client) ? "already_connected" : "connected");
			// TODO Add Puzzle Name To Repose Packet

			if (!Clients.Contains(client))
				App.Current.Dispatcher.Invoke(() => Clients.Add(client));

			await communicationsManager.SendData(client.IPAddress, responsePacket.Serialize());
		}
	}
}