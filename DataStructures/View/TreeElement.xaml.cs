using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DataStructures.View
{
    /// <summary>
    /// Interaction logic for TreeElement.xaml
    /// </summary>
    public partial class TreeElement
    {
        public TreeElement()
        {
            InitializeComponent();
        }

        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(string), typeof(TreeElement), new UIPropertyMetadata(null));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImagemProperty); }
            set { SetValue(ImagemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagemProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(TreeElement), new UIPropertyMetadata(null));

        public Line Conector { get; set; }

    }
}
