using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster___Server.Models {

	public enum ClientState {
		Waiting, Testing, Finished
	}
	public class Client {
		public IPAddress IPAddress { get; }
		public string Name { get; }
		public string Surname { get; }
		public string Class { get; }
		public ClientState ClientState { get; set; }

	}
}