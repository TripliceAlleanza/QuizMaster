using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuizMaster___Server.ViewModels;

namespace QuizMaster___Server.Views {
	/// <summary>
	/// Logica di interazione per GameWindow.xaml
	/// </summary>
	public partial class GameWindow : Window {
		public GameWindow(IOptionsViewModel options) {
			InitializeComponent();
			this.DataContext = new GameViewModel(options);
		}

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

		}
	}
}