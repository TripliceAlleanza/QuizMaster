using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadState = System.Threading.ThreadState;

namespace QuizMaster___Server.Networking {
    public class CommunicationsManager {

	    public const int SERVER_PORT = 19999;


	    private readonly TcpListener listener;
	    private readonly Thread listenThread;

		/// <param name="client">The client from which the connection is received</param>
		/// <param name="message">The message (usually a message)</param>
	    public delegate void MessageReceivedEventArgs(Client client, string message);

		/// <summary>
		/// Raised when a message is received from a client
		/// </summary>
	    public event MessageReceivedEventArgs MessageReceived;

	    public CommunicationsManager() {
		    listener = new TcpListener(IPAddress.Any, SERVER_PORT);
		    listenThread = new Thread(ListenForData);
		}

		/// <summary>
		/// Start the server
		/// </summary>
	    public void Start() {
		    listenThread.Start();
		}

	    public void Stop() {
			listenThread.Abort();
	    }

	    private void ListenForData() {
			listener.Start();

		    while (listenThread.ThreadState != ThreadState.AbortRequested) {
			    Socket client = listener.AcceptSocket();
				var task = new Task(() => {
					MessageReceived?.Invoke(null, ReceiveJson(client));			
				});
				task.Start();
		    }

			listener.Stop();
	    }

	    private string ReceiveJson(Socket socket) {
			var buffer = new List<byte>();

		    while (socket.Available > 0) {
			    var currByte = new Byte[1];
			    var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);

			    if (byteCounter.Equals(1)) {
				    buffer.Add(currByte[0]);
			    }
		    }

		    return Encoding.UTF8.GetString(buffer.ToArray());
	    }
    }
}