using System;
using System.Windows.Input;

namespace QuizMaster___SharedLibrary.MVVM {
	public class RelayCommand : ICommand {
		public event EventHandler CanExecuteChanged;

		private Predicate<object> canExecuteMethod;
		private Action<object> executeMethod;

		public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod) {
			this.canExecuteMethod = canExecuteMethod;
			this.executeMethod = executeMethod;
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