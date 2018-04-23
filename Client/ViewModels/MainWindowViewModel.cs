using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuizMaster___Client.Models;
using QuizMaster___SharedLibrary.MVVM;
using QuizMaster___SharedLibrary.Networking;
using QuizMaster___SharedLibrary.Packets;

namespace QuizMaster___Client.ViewModels {
	public class MainWindowViewModel {
		public Client MeClient { get; set; }

		public string StateText { get; private set; }

		private string serverIP;

		public RelayCommand AvviaTestCommand { get; private set; }

		public MainWindowViewModel() {
			MeClient = new Client();
			this.StateText = "Cercando il server...";
			AvviaTestCommand = new RelayCommand(AvviaTest, o => true);
			SearchServer();
		}

		private void AvviaTest(object obj) {
			Debug.WriteLine("Avviato test");
		}

		private async Task SearchServer() {

			foreach (var _interface in NetworkInterface.GetAllNetworkInterfaces()) {

				foreach (var address in _interface.GetIPProperties().UnicastAddresses) {

					var broadcast = Networking.GetBroadcastAddress(address);
					var client = new UdpClient();

					var bytes = Encoding.UTF8.GetBytes(new RequestPacket("getserverinfo").Serialize());

					await client.SendAsync(bytes, bytes.Length, new IPEndPoint(broadcast, 19999));

					client.ReceiveAsync().ContinueWith((task => {
						var packet = JsonConvert.DeserializeObject<DictionaryPacket>(Encoding.UTF8.GetString(task.Result.Buffer));
						Debug.WriteLine(packet.Serialize());
						serverIP = packet["serverIP"] as string;
					}));


				}

			}


		}
	}
}