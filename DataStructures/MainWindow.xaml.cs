using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DataStructures.View;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DataStructures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Tree<string> _tree = new Tree<string>();
        private readonly Queue<string> _queue = new Queue<string>();
        private readonly LinkedList<string> _list = new LinkedList<string>();
        private readonly Stack<string> _stack = new Stack<string>();


        private void ClearCanvas(Canvas canvas)
        {
            //for (int i = canvas.Children.Count - 1; i >= 0; i--)
            //{
            //    canvas.Children.RemoveAt(i);
            //}
            canvas.Children.Clear();
        }

        #region List functions

        private void CreateListElement(int numElement)
        {
            var el = new ListElement { Data = _list[numElement] };
            Canvas.SetLeft(el, -60);
            canvas1.Children.Add(el);
            var duration = new Duration(TimeSpan.FromSeconds(0.1 * numElement));
            var da1 = new DoubleAnimation(numElement * 58, duration) { DecelerationRatio = 0.5 };
            el.BeginAnimation(Canvas.LeftProperty, da1);
        }

        private void RemoveListElement(int numElement)
        {
            canvas1.Children.RemoveAt(numElement);

            for (int i = numElement; i < canvas1.Children.Count; i++)
            {
                var duration = new Duration(TimeSpan.FromSeconds(0.2));
                var da1 = new DoubleAnimation
                {
                    Duration = duration,
                    By = -58
                };
                canvas1.Children[i].BeginAnimation(Canvas.LeftProperty, da1);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numElement = _list.Insert(textBox1.Text);
                UpdateList();
                CreateListElement(numElement - 1);
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void UpdateList()
        {
            ClearSearch();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numRemove = _list.Find(textBox1.Text);
                if (numRemove >= 0)
                {
                    RemoveListElement(numRemove);
                    _list.Remove(textBox1.Text);
                }
                UpdateList();
            }
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void ClearSearch()
        {
            for (int i = 0; i < canvas1.Children.Count; i++)
                ((ListElement)canvas1.Children[i]).Fill = Brushes.LightSalmon;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int numProcura = _list.Find(textBox1.Text);
                if (numProcura >= 0)
                {
                    for (int i = 0; i < _list.Count; i++)
                    {
                        ((ListElement)canvas1.Children[i]).Fill = i == numProcura ? Brushes.Red : Brushes.LightSalmon;
                    }
                }
                else
                {
                    ClearSearch();
                    MessageBox.Show("Not found!");
                }
            }
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _list.Clear();
            ClearCanvas(canvas1);
            textBox1.Focus();
            textBox1.SelectAll();
        }

        #endregion

        #region Stack functions

        private void CreateStackElement(int numElement)
        {
            var el = new StackElement { Data = textBox2.Text };
            Canvas.SetTop(el, 0);
            Canvas.SetLeft(el, canvas2.ActualWidth / 2 - 40);
            canvas2.Children.Add(el);
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            var da1 = new DoubleAnimation(canvas2.ActualHeight - 20 * numElement - 50, duration);
            da1.DecelerationRatio = 1;
            el.BeginAnimation(Canvas.TopProperty, da1);
        }

        private void RemoveStackElement(int numElement)
        {
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            var da1 = new DoubleAnimation(0, duration) { AccelerationRatio = 0.5 };
            da1.Completed += da1_Completed;
            canvas2.Children[numElement].BeginAnimation(Canvas.TopProperty, da1);
        }

        private void da1_Completed(object sender, EventArgs e)
        {
            canvas2.Children.RemoveAt(canvas2.Children.Count - 1);
        }

        private void btnPush_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "")
            {
                _stack.Push(textBox2.Text);
                int numItens = _stack.Count;
                CreateStackElement(numItens - 1);
            }
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void btnPop_Click(object sender, RoutedEventArgs e)
        {
            if (_stack.Count > 0)
            {
                _stack.Pop();
                RemoveStackElement(_stack.Count);
            }
            else
                MessageBox.Show("The stack is empty");
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void btnPeek_Click(object sender, RoutedEventArgs e)
        {
            if (_stack.Count > 0)
            {
                string item = _stack.Peek();
                MessageBox.Show(string.Format("{0} on top of stack\nCount of stack items: {1}", item,
                                              _stack.Count));
            }
            else
                MessageBox.Show("The stack is empty");
            textBox2.Focus();
            textBox2.SelectAll();
        }

        private void btnClearStack_Click(object sender, RoutedEventArgs e)
        {
            _stack.Clear();
            ClearCanvas(canvas2);
            textBox2.Focus();
            textBox2.SelectAll();
        }

        #endregion

        #region Queue functions

        private void CriaElementoFila(int numElement)
        {
            var el = new QueueElement();
            el.Data = textBox3.Text;
            Canvas.SetLeft(el, canvas3.ActualWidth + 60);
            canvas3.Children.Add(el);
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            var da1 = new DoubleAnimation(numElement * 58, duration);
            da1.DecelerationRatio = 1;
            el.BeginAnimation(Canvas.LeftProperty, da1);
        }

        private void RemoveElementoFila()
        {
            var duration = new Duration(TimeSpan.FromSeconds(0.2));
            canvas3.Children.RemoveAt(0);
            for (int i = 0; i < canvas3.Children.Count; i++)
            {
                var da1 = new DoubleAnimation();
                da1.Duration = duration;
                da1.By = -58;
                canvas3.Children[i].BeginAnimation(Canvas.LeftProperty, da1);
            }
        }

        private void btnEnqueue_Click(object sender, RoutedEventArgs e)
        {
            if (textBox3.Text != "")
            {
                _queue.Enqueue(textBox3.Text);
                CriaElementoFila(_queue.Count - 1);
            }
            textBox3.Focus();
            textBox3.SelectAll();
        }

        private void btnDequeue_Click(object sender, RoutedEventArgs e)
        {
            if (_queue.Count > 0)
            {
                _queue.Dequeue();
                RemoveElementoFila();
            }
            else
                MessageBox.Show("There are no items in the queue");
            textBox3.Focus();
            textBox3.SelectAll();
        }

        private void btnClearQueue_Click(object sender, RoutedEventArgs e)
        {
            _queue.Clear();
            ClearCanvas(canvas3);
            textBox3.Focus();
            textBox3.SelectAll();
        }

        #endregion

        #region Tree functions

        private BitmapImage CreateImage(string imageName)
        {
            return new BitmapImage(new Uri("\\images\\" + imageName, UriKind.Relative));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (textBox4.Text != "")
            {
                try
                {
                    _tree.Add(textBox4.Text);
                    RedrawTree();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            textBox4.Focus();
            textBox4.SelectAll();
        }

        private void btnRemoveTreeItem_Click(object sender, RoutedEventArgs e)
        {

            if (textBox4.Text != "")
            {
                _tree.Remove(textBox4.Text);
                RedrawTree();
            }
            textBox4.Focus();
            textBox4.SelectAll();
        }

        private void DrawNode(string data, double startX, double endX, double posY)
        {
            var currentData = textBox4.Text;
            TreeElement el = new TreeElement
            {
                Data = data,
                Image = CreateImage(currentData == data ? "nodetree2.png" : "nodetree1.png")
            };
            Canvas.SetLeft(el, (endX + startX) / 2 - 15);
            Canvas.SetTop(el, posY);
            canvas4.Children.Add(el);
        }

        private void RedrawTree()
        {
            ClearCanvas(canvas4);
            if (_tree.Count != 0)
            {
                var startPos = 0.0;
                var endPos = canvas4.ActualWidth;
                var posY = 5;
                var node = _tree.Root;
                VisitNode(node, startPos, endPos, posY);
            }
        }

        private void VisitNode(TreeNode<string> node, double startPos, double endPos, int posY)
        {
            DrawNode(node.Data, startPos, endPos, posY);
            if (node.Left != null)
            {
                var newEnd = (startPos + endPos) / 2;
                DrawLine((endPos + startPos) / 2, posY + 15, (newEnd + startPos) / 2, posY + 65);
                VisitNode(node.Left, startPos, newEnd, posY + 50);
            }
            if (node.Right != null)
            {
                var newStart = (endPos + startPos) / 2;
                DrawLine((endPos + startPos) / 2, posY + 15, (endPos + newStart) / 2, posY + 65);
                VisitNode(node.Right, newStart, endPos, posY + 50);
            }
        }

        private void DrawLine(double startX, double startY, double endX, double endY)
        {
            var line = new Line { X1 = startX, Y1 = startY, X2 = endX, Y2 = endY, Stroke = Brushes.Black, StrokeThickness = 1 };
            Panel.SetZIndex(line, -1);
            canvas4.Children.Add(line);
        }

        private void btnSearchTreeItem_Click(object sender, RoutedEventArgs e)
        {
            if (textBox4.Text != "")
                try
                {
                    if (!_tree.Exists(textBox4.Text))
                    {
                        MessageBox.Show("Item does not exist");
                        return;
                    }
                    RedrawTree();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            textBox4.Focus();
            textBox4.SelectAll();

        }

        private void btnClearTree_Click(object sender, RoutedEventArgs e)
        {
            _tree.Clear();
            RedrawTree();
            textBox4.Focus();
            textBox4.SelectAll();
        }

        #endregion
    }
}
