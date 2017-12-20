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

namespace DragDrop
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool drag = false;
        Point startPoint;

        public MainWindow()
        {
            InitializeComponent();

            //<Rectangle x:Name="rect" Height="35" Stroke="Black" Width="75" Fill="RoyalBlue" MouseMove="rect_MouseMove" MouseDown="rect_MouseDown" MouseUp="rect_MouseUp" Canvas.Left="20" Canvas.Top="148"/>
            //<Rectangle x:Name="rect1" Height="35" Stroke="Black" Width="75" Fill="RoyalBlue" MouseMove="rect_MouseMove" MouseDown="rect_MouseDown" MouseUp="rect_MouseUp" Canvas.Left="20" Canvas.Top="72"/>
        }

        private void rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // start dragging
            drag = true;
            // save start point of dragging
            startPoint = Mouse.GetPosition(canvas);
        }

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            // if dragging, then adjust rectangle position based on mouse movement
            if (drag)
            {
                Rectangle draggedRectangle = sender as Rectangle;
                Point newPoint = Mouse.GetPosition(canvas);
                double left = Canvas.GetLeft(draggedRectangle);
                double top = Canvas.GetTop(draggedRectangle);
                Canvas.SetLeft(draggedRectangle, left + (newPoint.X - startPoint.X));
                Canvas.SetTop(draggedRectangle, top + (newPoint.Y - startPoint.Y));

                startPoint = newPoint;
            }
        }

        private void rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // stop dragging
            drag = false;

            Rectangle draggedRectangle = sender as Rectangle;
            Point newPoint = Mouse.GetPosition(canvas);
            double posX = newPoint.X;
            double posY = newPoint.Y;

            double left = Canvas.GetLeft(draggedRectangle);
            double top = Canvas.GetTop(draggedRectangle);

            // -> For cyklus, který bude počítat hodnoty kolik řádků a sloupečků. Přidávání hodnot na dynamické snapování
            // -> Vymyslet to, aby každý item měl svoje id (barva, hodnota v tabulce, neviditelná, ...)

            if (posX >= 0 && posX <= 99)
            {
                Canvas.SetLeft(draggedRectangle, 0);

                if (posY >= 0 && posY <= 99)
                {
                    Canvas.SetTop(draggedRectangle, 0);
                }
            }
        }



    }

}
