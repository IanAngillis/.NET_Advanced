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

namespace Oefening_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<President> presidents = new List<President>();

            presidents.Add(new President("George Washington", ".\\images\\gw1.jpg"));
            presidents.Add(new President("John Adams", ".\\images\\ja2.jpg"));
            presidents.Add(new President("Thomas Jefferson", ".\\images\\tj3.jpg"));
            presidents.Add(new President("James Madison", ".\\images\\jm4.jpg"));
            presidents.Add(new President("James Monroe", ".\\images\\jm5.jpg"));
            presidents.Add(new President("John Quincy Adams", ".\\images\\ja6.jpg"));
            presidents.Add(new President("Andrew Jackson", ".\\images\\aj7.jpg"));
            presidents.Add(new President("Martin Van Buren", ".\\images\\mv8.jpg"));
            presidents.Add(new President("William H. Harrison", ".\\images\\wh9.jpg"));
            presidents.Add(new President("John Tyler", ".\\images\\jt10.jpg"));
            presidents.Add(new President("James K. Polk", ".\\images\\jp11.jpg"));
            presidents.Add(new President("Zachary Taylor", ".\\images\\zt12.jpg"));
            presidents.Add(new President("Millard Fillmore", ".\\images\\mf13.jpg"));
            presidents.Add(new President("Franklin Pierce", ".\\images\\fp14.jpg"));
            presidents.Add(new President("James Buchanan", ".\\images\\jp15.jpg"));
            presidents.Add(new President("Abraham Lincoln", ".\\images\\al16.jpg"));
            presidents.Add(new President("Andrew Johnson", ".\\images\\aj17.jpg"));
            presidents.Add(new President("Ulysses S. Grant", ".\\images\\ug18.jpg"));
            presidents.Add(new President("Rutherford B. Hayes", ".\\images\\rb19.jpg"));
            presidents.Add(new President("James Garfield", ".\\images\\jg20.jpg"));


            PresidentsListBox.ItemsSource = presidents;

        }

        private void PresidentsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PresidentsListBox.SelectedIndex == -1)
            {
                return;
            }

            President currentPresident = (President) PresidentsListBox.SelectedItem;
            this.Title = currentPresident.Name;
        }
    }
}
