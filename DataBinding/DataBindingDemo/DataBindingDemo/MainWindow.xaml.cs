using System.Windows;


namespace DataBindingDemo
{
    public partial class MainWindow : Window
    {
        private Employee _employee;

        public MainWindow()
        {
            InitializeComponent();

            _employee = Employee.CreateSomeEmployee();
            this.DataContext = _employee;
        }

        private void PromoteButton_OnClick(object sender, RoutedEventArgs e)
        {
            _employee.Title = "Manager";
            
        }
    }
}
