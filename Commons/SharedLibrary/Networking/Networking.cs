using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace QuizMaster___SharedLibrary.Networking
{
    public static class Networking {

	    public static async Task<string> GetLocalIPAddressAsync() {
		    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0)) {
				socket.Connect("8.8.8.8", 65530);
			    var endPoint = socket.LocalEndPoint as IPEndPoint;
			    return endPoint?.Address.ToString();
		    }
	    }

	    public static IPAddress GetBroadcastAddress(UnicastIPAddressInformation unicastAddress) {
		    return GetBroadcastAddress(unicastAddress.Address, unicastAddress.IPv4Mask);
	    }

	    public static IPAddress GetBroadcastAddress(IPAddress address, IPAddress mask) {
		    uint ipAddress = BitConverter.ToUInt32(address.GetAddressBytes(), 0);
		    uint ipMaskV4 = BitConverter.ToUInt32(mask.GetAddressBytes(), 0);
		    uint broadCastIpAddress = ipAddress | ~ipMaskV4;

		    return new IPAddress(BitConverter.GetBytes(broadCastIpAddress));
	    }

	}
}
