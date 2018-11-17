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

namespace Oefening_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeColourButton_OnClick(object sender, RoutedEventArgs e)
        {
            Rectangle temp1 = (Rectangle) rectangleGrid.Children[0];
            Rectangle temp2 = (Rectangle) rectangleGrid.Children[1];

            temp1.Fill = temp2.Fill;
        }

        private void ResizeWindowButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Width -= 10;
            this.Height -= 10;

            statusbarTextBlock.Text = "De breedte van het venster is " + Convert.ToString(this.Width);
        }

        private void DeleteRectanglesButton_OnClick(object sender, RoutedEventArgs e)
        {
            rectangleGrid.Children.Clear();
        }


        private void AboutMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by Ian Angillis");
            statusbarTextBlock.Text = "Created by Ian Angillis";
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
