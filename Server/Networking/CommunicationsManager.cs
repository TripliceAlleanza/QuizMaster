using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuizMaster___Server.Models;
using QuizMaster___Server.Support;
using ThreadState = System.Threading.ThreadState;

namespace QuizMaster___Server.Networking {
    public class CommunicationsManager {

	    public const int SERVER_PORT = 19999;

	    private readonly TcpListener listener;
	    private readonly TcpClient tcpClient;

	    private readonly Thread listenThread;

		/// <param name="client">The tcpClient from which the connection is received</param>
		/// <param name="message">The message (usually a message)</param>
	    public delegate void MessageReceivedEventArgs(IPAddress client, string message);

		/// <summary>
		/// Raised when a message is received from a tcpClient
		/// </summary>
	    public event MessageReceivedEventArgs MessageReceived;

		/// <summary>
		/// Main Constructor
		/// </summary>
	    public CommunicationsManager() {
		    listener = new TcpListener(IPAddress.Any, SERVER_PORT);
			tcpClient = new TcpClient();
		    listenThread = new Thread(ListenForData);
		}

		/// <summary>
		/// Start the server
		/// </summary>
	    public void Start() {
		    listenThread.Start();
		}

		/// <summary>
		/// Stop the server
		/// </summary>
	    public void Stop() {
			listenThread.Abort();
	    }

		/// <summary>
		/// Sends data to client and does not wait for a response
		/// </summary>
		/// <param name="client">Client to send data to</param>
		/// <param name="data">the JSON-formatted data you want to send</param>
	    public async Task SendData(IPAddress client, string data) {
			await tcpClient.ConnectAsync(client, SERVER_PORT);
		    var stream = tcpClient.GetStream();
		    var bytes = Encoding.UTF8.GetBytes(data);
			stream.Write(bytes,0, bytes.Length);
	    }

		/// <summary>
		/// Sends data to client and does wait for a response
		/// </summary>
		///<param name="client">Client to send data to</param>
		/// <param name="data">the JSON-formatted data you want to send</param>
		/// <returns>The JSON-formatted response</returns>
		public async Task<string> GetResponse(IPAddress client, string data) {
		    await SendData(client, data);
		    return ReceiveJson(tcpClient);
	    }


	    private void ListenForData() {
		    listener.Start();

		    while (listenThread.ThreadState != ThreadState.AbortRequested) {
			    var client = listener.AcceptTcpClient();
			    string message = ReceiveJson(client);
			    if (string.IsNullOrEmpty(message)) Debugger.Break();
				var task = new Task(() => {			    
					MessageReceived?.Invoke((client.Client.LocalEndPoint as IPEndPoint).Address, message);
			    });
			    task.Start();
		    }

		    listener.Stop();
	    }

	    private string ReceiveJson(TcpClient tcpClient) {
			var stream = tcpClient.GetStream();
		    if (tcpClient.ReceiveBufferSize > 0) {
			    var bytes = new byte[tcpClient.ReceiveBufferSize];
			    stream.Read(bytes, 0, tcpClient.ReceiveBufferSize);
			    return Encoding.UTF8.GetString(bytes);
		    }

		    return "";
	    }

	}
}