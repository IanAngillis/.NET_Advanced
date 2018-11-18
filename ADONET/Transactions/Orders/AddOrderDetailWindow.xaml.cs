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
using System.Windows.Shapes;
using Orders.Data.DataClasses;
using Orders.Data.Repositories;

namespace Orders
{
    /// <summary>
    /// Interaction logic for AddOrderDetailWindow.xaml
    /// </summary>
    public partial class AddOrderDetailWindow : Window
    {
        private Order _newOrder;
        private OrderDetail _newOrderDetail;

        public AddOrderDetailWindow(Order newOrder)
        {
            InitializeComponent();
            _newOrder = newOrder;
            CreateOrderDetail();
            albumComboBox.ItemsSource = AlbumRepository.GetAlbums();
            mainGrid.DataContext = _newOrderDetail;
        }

        private void CreateOrderDetail()
        {
            _newOrderDetail = new OrderDetail
            {
                OrderId = _newOrder.OrderId
            };
        }

        private void AlbumComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (albumComboBox.SelectedIndex == -1)
            {
                return;
            }

            Album currentAlbum = (Album) albumComboBox.Items.GetItemAt(albumComboBox.SelectedIndex);

            _newOrderDetail.AlbumId = currentAlbum.AlbumId;

            unitPriceTextBox.Text = Convert.ToString(currentAlbum.Price);
        }

        private void saveOrderAndOrderDetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (albumComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an album");
            }

            CalculateTotalPrice();

            if (DataInserter.UpdateOrderAndOrderDetail(_newOrder, _newOrderDetail) > 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again");
            }
        }

        private void CalculateTotalPrice()
        {
            double totalPrice = 0;
            Album currentAlbum = (Album)albumComboBox.Items.GetItemAt(albumComboBox.SelectedIndex);

            try
            {
                totalPrice = currentAlbum.Price * _newOrderDetail.Quantity;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Tis van datte");
                return;
            }

            _newOrder.Total = totalPrice;
        }
    }
}
