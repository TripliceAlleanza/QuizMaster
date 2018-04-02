﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuizMaster___Server.Networking;

namespace QuizMaster___Server {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

	    private CommunicationsManager manager;

        public MainWindow() {
            InitializeComponent();
			manager = new CommunicationsManager();
			manager.Start();
        }

		private void AvviaPaginaQuiz(object sender, RoutedEventArgs e) {

			Views.AvviaQuiz avvia_quiz = new Views.AvviaQuiz();
			avvia_quiz.ShowDialog();
		
		}

		private void PaginaQuizEditor(object sender, RoutedEventArgs e) {

			Views.QuizEditor quiz_editor = new Views.QuizEditor();
			quiz_editor.ShowDialog();
		}
	}
}
