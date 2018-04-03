using System;
using System.Collections.Generic;
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

	}
}
