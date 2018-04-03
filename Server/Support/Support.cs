using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaster___Server.Support {
	public static class Support {

		public static string CapitalizeFirstLetter(this string s) {
			var chars = s.ToCharArray();
			chars[0] = char.ToUpper(chars[0]);
			return new string(chars);
		}

		public static bool TryReadExact(this Stream stream, byte[] buffer, int offset, int count) {
			int bytesRead;
			while (count > 0 && ((bytesRead = stream.Read(buffer, offset, count)) > 0)) {
				offset += bytesRead;
				count -= bytesRead;
			}

			return count == 0;
		}

	}
}
