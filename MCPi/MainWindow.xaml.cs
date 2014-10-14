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

namespace MCPi
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private double getMaxSquareLength()
        {
            return Math.Min(canvas.ActualHeight, canvas.ActualWidth); 
        }
        private void initCanvas()
        {
            canvas.Children.Clear();

            double length = getMaxSquareLength();

            Ellipse eclipse = new Ellipse();
            eclipse.Fill = Brushes.LightGray;
            eclipse.StrokeThickness = 2;
            eclipse.Stroke = Brushes.Black;
            eclipse.Height = length;
            eclipse.Width  = length;

            Rectangle rec = new Rectangle();
            rec.Fill = Brushes.LightGray;
            rec.StrokeThickness = 2;
            rec.Stroke = Brushes.Black;
            rec.Height = length;
            rec.Width = length;

            canvas.Children.Add(rec);
            canvas.Children.Add(eclipse);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            initCanvas();
            MC mc = new MC();
            mc.times = Convert.ToInt64(tbTimes.Text);
            double pi = mc.calculate();
            lbResult.Content = pi.ToString();
            drawPoints(mc.pointList);
        }
        private void drawPoints(List<Point> pointList)
        {
            double length = getMaxSquareLength();
            //for coordinates change from (-1,-1)-(1,1)
            double zero = length / 2;

            foreach (Point p in pointList)
            {
                Ellipse myEllipse = new Ellipse();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Color.FromArgb(111, 111, 111, 5);
                myEllipse.Fill = mySolidColorBrush;
                myEllipse.StrokeThickness = 1;
                myEllipse.Stroke = Brushes.Black;
                myEllipse.Width = 1;
                myEllipse.Height = 1;
                double left = p.x * zero + zero;
                double top = p.y * zero + zero;
                Canvas.SetTop(myEllipse, top);
                Canvas.SetLeft(myEllipse, left);
                canvas.Children.Add(myEllipse);
            }
        }
    }
}
