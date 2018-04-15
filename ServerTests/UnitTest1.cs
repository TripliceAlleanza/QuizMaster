using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuizMaster___SharedLibrary.Packets;
using PacketDataDictionary = System.Collections.Generic.Dictionary<string, object>;

namespace ServerTests {
	[TestClass]
	public class SerializationTests {
		[TestMethod]
		public void TestConnect() {
			var packet = new RequestPacket("connect");
			packet.DataPacket["name"] = "Edoardo";
			packet.DataPacket["surname"] = "Fullin";
			packet.DataPacket["pcname"] = "EDO-PC";

			Debug.WriteLine(packet.Serialize());
			Assert.IsTrue(packet.Serialize() == "{\"request\":\"connect\",\"dataPacket\":{\"name\":\"Edoardo\",\"surname\":\"Fullin\",\"pcname\":\"EDO-PC\"}}");
		}
	}
}
