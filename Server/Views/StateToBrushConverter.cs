using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using QuizMaster___Server.Models;
using QuizMaster___Server.Properties;

namespace QuizMaster___Server.Views {
	public class StateToBrushConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (!(value is ClientState)) throw new Exception();

			var vvalue = (ClientState) value;
			var dictionary = Application.Current.Resources;

			switch (vvalue) {
				case ClientState.Waiting: return dictionary["WaitingColor"] as Brush;
				case ClientState.Testing: return dictionary["TestingColor"] as Brush;
				case ClientState.Finished: return dictionary["FinishedColor"] as Brush;
				default: throw new ArgumentOutOfRangeException();
			}


		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}