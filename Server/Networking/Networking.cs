using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster___Server.Networking
{
    static class Networking {

	    public static async Task<string> GetLocalIPAddressAsync() {
		    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) {
				socket.Connect("8.8.8.8", 65530);
			    var endPoint = socket.LocalEndPoint as IPEndPoint;
			    return endPoint?.Address.ToString();
		    }
	    }

    }
}
