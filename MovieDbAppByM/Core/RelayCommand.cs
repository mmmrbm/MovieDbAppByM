using System;
using System.Windows.Input;

namespace MovieDbAppByM.Core
{
    /// <summary>
    /// An entity encapsulating <see cref="ICommand"/> functionaliry
    /// </summary>
    public sealed class RelayCommand : ICommand
    {
        /// <summary>
        /// A varaible to hold the actual method which needs to be executed via Command.
        /// </summary>
        private Action targetExecuteMethod;

        /// <summary>
        /// A varaible to hold indicator which indicate whether the method can be executed.
        /// </summary>
        private Func<bool> targetCanExecuteMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">The method that will be executed.</param>
        public RelayCommand(Action executeMethod)
        {
            this.targetExecuteMethod = executeMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeMethod">The actual method that will be executed.</param>
        /// <param name="canExecuteMethod">Indicator which indicate whether the method can be executed</param>
        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.targetExecuteMethod = executeMethod;
            this.targetCanExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        /// CanExecuteChanged event inhertited from <see cref="ICommand"/>
        /// </summary>
        public event EventHandler CanExecuteChanged = (obj, eventArgs) => { };

        /// <summary>
        /// Event which raised to indicate whether the method can be executed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Investigates whether the method can be executed within current context
        /// </summary>
        /// <param name="parameter">The method that will be excuted.</param>
        /// <returns>A boolean indicating whether the method can be executed.</returns>
        bool ICommand.CanExecute(object parameter)
        {
            if (this.targetCanExecuteMethod != null)
            {
                return this.targetCanExecuteMethod();
            }

            if (this.targetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Executes the actual method wrapped inside the command object.
        /// </summary>
        /// <param name="parameter">The method that will be excuted</param>
        void ICommand.Execute(object parameter)
        {
            if (this.targetExecuteMethod != null)
            {
                this.targetExecuteMethod();
            }
        }
    }
}
