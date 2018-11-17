using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace Oefening_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student("Wesley Hendrikx", "Lectorstraat 10", "Hasselt", "Limurg", "3500", "011/775555", "0484/111222"));
            studentList.Add(new Student("Marijke Willems", "Diestersteenweg 10", "Halen", "Limurg", "3545", "011/778888", "0484/666666"));
            studentList.Add(new Student("Kris Hermans", "Haasken 10", "Diest", "Vlaams Brabant", "3290", "011/770000", "0484/999999"));

            LoadComboBoxItems(studentList);

            studentListBox.ItemsSource = studentList;
            studentListBox.SelectedIndex = 0;

        }

        private void LoadComboBoxItems(List<Student> list)
        {
            foreach (Student student in list)
            {
                if (!StateComboBox.Items.Contains(student.State))
                {
                    StateComboBox.Items.Add(student.State);
                }
            }
        }

        private void SelectCorrectState()
        {
            Student currentStudent = (Student) DataContext;

            for (int i = 0; i < StateComboBox.Items.Count; i++)
            {
                if (StateComboBox.Items[i].Equals(currentStudent.State))
                {
                    StateComboBox.SelectedIndex = i;
                }
            }
        }

        private void StudentListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = (Student) studentListBox.Items[studentListBox.SelectedIndex];
            SelectCorrectState();
        }
    }
}
