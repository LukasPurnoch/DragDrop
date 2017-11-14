using System;
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
using FileHelpers;

namespace DAD
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Move> pos = new List<Move>();


        public MainWindow()
        {
            InitializeComponent();
        }

        public void CSVWrite()
        {
            var engine = new FileHelperEngine<Move>();
            engine.WriteFile("save_pos.csv", pos);
        }

        //((Rectangle)sender).CaptureMouse();

        private bool _isRectDragInProg;
        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = true;
            ((Rectangle)sender).CaptureMouse();
        }
        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = false;
            ((Rectangle)sender).CaptureMouse();
        }
        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isRectDragInProg) return;

            var mousePos = e.GetPosition(canvas);

            double left = mousePos.X - (rect.ActualWidth / 2);
            double top = mousePos.Y - (rect.ActualHeight / 2);
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);
        }

        /*private bool _isRectDragInProg1;
        private void rect_MouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg1 = true;
            rect1.CaptureMouse();
        }
        private void rect_MouseLeftButtonUp1(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg1 = false;
            rect1.ReleaseMouseCapture();
        }
        private void rect_MouseMove1(object sender, MouseEventArgs e)
        {
            if (!_isRectDragInProg1) return;

            var mousePos = e.GetPosition(canvas);

            double left = mousePos.X - (rect1.ActualWidth / 2);
            double top = mousePos.Y - (rect1.ActualHeight / 2);
            Canvas.SetLeft(rect1, left);
            Canvas.SetTop(rect1, top);

            Move set = new Move();
            set.LEFT = left;
            set.TOP = top;
            
            pos.Add(set);

            CSVWrite();
        }*/
    }
}
