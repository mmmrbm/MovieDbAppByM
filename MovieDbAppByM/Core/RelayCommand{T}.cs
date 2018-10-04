using System;
using System.Windows.Input;

namespace MovieDbAppByM.Core
{
    /// <summary>
    /// An entity encapsulating <see cref="ICommand"/> functionaliry
    /// with use of generic type. T represents the parameter for the
    /// actualt method wrapped inside the command object.
    /// </summary>
    /// <typeparam name="T">Type of the parameter used in the method.</typeparam>
    public sealed class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// A varaible to hold the actual method which needs to be executed via Command.
        /// </summary>
        private Action<T> targetExecuteMethod;

        /// <summary>
        /// A varaible to hold indicator which indicate whether the method can be executed.
        /// </summary>
        private Func<T, bool> targetCanExecuteMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="executeMethod">The method that will be executed.</param>
        public RelayCommand(Action<T> executeMethod)
        {
            this.targetExecuteMethod = executeMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="executeMethod">The actual method that will be executed.</param>
        /// <param name="canExecuteMethod">Indicator which indicate whether the method can be executed</param>
        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
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
                T tparm = (T)parameter;
                return this.targetCanExecuteMethod(tparm);
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
                this.targetExecuteMethod((T)parameter);
            }
        }
    }
}
