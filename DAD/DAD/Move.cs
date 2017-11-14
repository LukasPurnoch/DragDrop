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
    [DelimitedRecord(",")]
    class Move
    {

        public string Name;
        public double LEFT;
        public double TOP;

        private bool _isRectDragInProg;

        public void MBDown(Rectangle rect)
        {
            _isRectDragInProg = true;
            rect.CaptureMouse();
        }
        public void MBUp(Rectangle rect)
        {
            _isRectDragInProg = false;
            rect.ReleaseMouseCapture();
        }
        public void MMove(Rectangle rect, Canvas canvas, MouseEventArgs e)
        {
            if (!_isRectDragInProg) return;

            var mousePos = e.GetPosition(canvas);

            LEFT = mousePos.X - (rect.ActualWidth / 2);
            TOP = mousePos.Y - (rect.ActualHeight / 2);
            Canvas.SetLeft(rect, LEFT);
            Canvas.SetTop(rect, TOP);
        }
    }
}
