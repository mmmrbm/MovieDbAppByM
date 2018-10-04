using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MovieDbAppByM.Core
{
    /// <summary>
    /// An entity which is used to encapsualte INPC functionality.
    /// All ViewModels will be inherit  from this class.
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged event inhertied from INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (obj, eventArgs) => { };

        /// <summary>
        /// Uses reflection to raise the PropertyChanged event when a property
        /// of the ViewModel gets changed.
        /// </summary>
        /// <typeparam name="T">Type of the callee. I.e. ViewModel</typeparam>
        /// <param name="member">Property which has been changed</param>
        /// <param name="val">New value of the property.</param>
        /// <param name="propertyName">Name of the property changed. Obtained via compiler properties.</param>
        protected virtual void SetProperty<T>(
            ref T member,
            T val,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val))
            {
                return;
            }

            member = val;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Event handled for PropertyChanged event
        /// </summary>
        /// <param name="propertyName">Name of the changed property</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
