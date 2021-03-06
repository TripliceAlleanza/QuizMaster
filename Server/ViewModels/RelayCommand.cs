﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizMaster___Server.ViewModels {
	public class RelayCommand : ICommand {
		public event EventHandler CanExecuteChanged {
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		private Predicate<object> canExecuteMethod;
		private Action<object> executeMethod;

		public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod) {
			this.canExecuteMethod = canExecuteMethod;
			this.executeMethod = executeMethod;

			CanExecuteChanged += (sender, args) => CommandManager.InvalidateRequerySuggested();
		}

		public RelayCommand(Action<object> executeMethod) : this(executeMethod, null) {
		}

		public bool CanExecute(object parameter) {
			return canExecuteMethod?.Invoke(parameter) ?? true;
		}

		public void Execute(object parameter) {
			executeMethod(parameter);
		}
	}
}