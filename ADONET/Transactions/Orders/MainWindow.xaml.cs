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
using Orders.Data.DataClasses;
using Orders.Data.Repositories;

namespace Orders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Order _newOrder;

        public MainWindow()
        {
            InitializeComponent();
            DisableAllTextBoxes();
            mainGrid.DataContext = OrderRepository.GetLastOrder();
            addOrderDetailButton.IsEnabled = false;
        }

        private void DisableAllTextBoxes()
        {
            for (int i = 0; i < mainGrid.Children.Count; i++)
            {
                if (mainGrid.Children[i] is TextBox)
                {
                    TextBox textBox = (TextBox) mainGrid.Children[i];

                    textBox.IsEnabled = false;
                }
            }
            //TextBox stays enabled. Input is used to retrieve an order
            orderIdTextBox.IsEnabled = true;
        }

        private void EnableAllTextBoxes()
        {
            for (int i = 0; i < mainGrid.Children.Count; i++)
            {
                if (mainGrid.Children[i] is TextBox)
                {
                    TextBox textBox = (TextBox)mainGrid.Children[i];

                    textBox.IsEnabled = true;
                }
            }
            
            //This textbox stays disabled. Input is calculated internally
            totalPriceTextBox.IsEnabled = false;
        }

        private void getOrderButton_Click(object sender, RoutedEventArgs e)
        {

            _newOrder = null;
            DisableAllTextBoxes();
            mainGrid.DataContext = OrderRepository.GetLastOrder();
            addOrderDetailButton.IsEnabled = false;

            if (!InputIsCorrect())
            {
                return;
            }

            if (!OrderExist(Convert.ToInt32(orderIdTextBox.Text)))
            {
                MessageBox.Show("ID does not exist");
                return;
            }

            mainGrid.DataContext = OrderRepository.GetOrderByOrderId(Convert.ToInt32(orderIdTextBox.Text));
           
        }

        private void newOrderButton_Click(object sender, RoutedEventArgs e)
        {
            EnableAllTextBoxes();
            CreateNewOrder();
            mainGrid.DataContext = _newOrder;
            addOrderDetailButton.IsEnabled = true;
            orderIdTextBox.IsEnabled = false;
            showOrderDetailsButton.IsEnabled = false;
            orderIdTextBox.Text = "0";
            showOrderDetailsButton.IsEnabled = false;
        }

        private void CreateNewOrder()
        {
            _newOrder = new Order();
        }

        private void addOrderDetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (!InputIsCorrect())
            {
                return;
            }

            if (OrderExist(Convert.ToInt32(orderIdTextBox.Text)))
            {
                MessageBox.Show("ID already Exists");
                return;
            }

            _newOrder.OrderId = Convert.ToInt32(orderIdTextBox.Text);
            AddOrderDetailWindow addOrderDetailWindow = new AddOrderDetailWindow(_newOrder);
            addOrderDetailWindow.ShowDialog();

            DisableAllTextBoxes();
            mainGrid.DataContext = OrderRepository.GetLastOrder();
            addOrderDetailButton.IsEnabled = false;
            showOrderDetailsButton.IsEnabled = true;

        }

        private Boolean InputIsCorrect()
        {
            int orderId;

            try
            {
                orderId = Convert.ToInt32(orderIdTextBox.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please fill enter a correct order ID");
                return false;
            }

            return true;
        }

        private Boolean OrderExist(int orderId)
        {
            if (orderId < 0 || OrderRepository.OrderExists(orderId))
            {
                return true;
            }

            return false;
        }

        private void showOrderDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Coming soonTM");
        }
    }
}
