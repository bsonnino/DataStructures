using System.Windows;

namespace DataStructures.View
{
    /// <summary>
    /// Interaction logic for StackElement.xaml
    /// </summary>
    public partial class StackElement
    {
        public StackElement()
        {
            InitializeComponent();
        }
        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(string), typeof(StackElement), new UIPropertyMetadata(null));

    }
}
