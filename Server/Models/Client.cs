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
		public int Id { get; set; }
		public IPAddress IPAddress { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Class { get; set; }
		public ClientState ClientState { get; set; }

		public string NameAndState => $"{Name} {Surname} - {ClientState}";
	}
}