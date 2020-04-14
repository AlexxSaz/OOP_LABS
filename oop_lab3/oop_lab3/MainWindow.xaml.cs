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
using ShapeLib;

namespace oop_lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckForRightData()
        {
            if (!double.TryParse(HeightOfShape.Text, out double height) &&
                !double.TryParse(Square.Text, out double square) ||
                !double.TryParse(Radius.Text, out double radius))
            {
                throw new ArgumentException("Введите параметры фигур!");
            }
        }

        /// <summary>
        /// Расчет объема при нажатии
        /// </summary>
        /// <param name="sender">Ссылка на кнопку расчета</param>
        /// <param name="e">Информация о состоянии кнопки</param>
        private void Button_Calc(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckForRightData();

                if (PyramidCheck.IsChecked == true)
                {
                    var pyramid = new Pyramid();

                    pyramid.Height = double.Parse(HeightOfShape.Text);
                    pyramid.SquareOfBase = double.Parse(Square.Text);
                    Answer.Text = pyramid.Volume.ToString();
                }
                else if (SphereChek.IsChecked == true)
                {
                    var sphere = new Sphere();

                    sphere.Radius = double.Parse(Radius.Text);
                    Answer.Text = sphere.Volume.ToString();
                }
                else if (ParallCheck.IsChecked == true)
                {
                    var parall = new Parallelepiped();

                    parall.Height = double.Parse(HeightOfShape.Text);
                    parall.SquareOfBase = double.Parse(Square.Text);
                    Answer.Text = parall.Volume.ToString();
                }
                else
                {
                    throw new ArgumentException("Выберите фигуру!");
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        /// <summary>
        /// Выбор пирамиды для расчета
        /// </summary>
        /// <param name="sender">Ссылка на выбор пирамиды</param>
        /// <param name="e">Информация о состоянии кнопки</param>
        private void PyramidCheck_Checked(object sender, RoutedEventArgs e)
        {
            TextSquare.Visibility = Visibility.Visible;
            Square.Visibility = Visibility.Visible;
            TextHeight.Visibility = Visibility.Visible;
            HeightOfShape.Visibility = Visibility.Visible;
            TextRadius.Visibility = Visibility.Hidden;
            Radius.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Выбор сферы для расчета
        /// </summary>
        /// <param name="sender">Ссылка на выбор сферы</param>
        /// <param name="e">Информация о состоянии кнопки</param>
        private void SphereChek_Checked(object sender, RoutedEventArgs e)
        {
            TextSquare.Visibility = Visibility.Hidden;
            Square.Visibility = Visibility.Hidden;
            TextHeight.Visibility = Visibility.Hidden;
            HeightOfShape.Visibility = Visibility.Hidden;
            TextRadius.Visibility = Visibility.Visible;
            Radius.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Выбор параллелепипеда для расчета
        /// </summary>
        /// <param name="sender">Ссылка на выбор параллелепипеда</param>
        /// <param name="e">Информация о состоянии кнопки</param>
        private void ParallelepipedCheck_Checked(object sender, RoutedEventArgs e)
        {
            TextSquare.Visibility = Visibility.Visible;
            Square.Visibility = Visibility.Visible;
            TextHeight.Visibility = Visibility.Visible;
            HeightOfShape.Visibility = Visibility.Visible;
            TextRadius.Visibility = Visibility.Hidden;
            Radius.Visibility = Visibility.Hidden;
        }
    }
}
