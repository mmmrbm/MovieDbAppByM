using System.Windows.Controls;

namespace MovieDbAppByM.CustomControl
{
    public class SelectedFocusingListBox : ListBox
    {
        public SelectedFocusingListBox() : base()
        {
            SelectionChanged += new SelectionChangedEventHandler(ListBoxScroll_SelectionChanged);
        }

        void ListBoxScroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollIntoView(SelectedItem);
        }
    }
}
