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
using MusicStoreData;

namespace AlbumAdmin
{
    /// <summary>
    /// Interaction logic for SelectAlbumPage.xaml
    /// </summary>
    public partial class SelectAlbumPage : Page
    {
        public SelectAlbumPage()
        {
            InitializeComponent();
        }

        private void GetAlbumButton_OnClick(object sender, RoutedEventArgs e)
        {
            int albumId;

            try
            {
                albumId = Convert.ToInt32(albumIdTextBox.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter a correct albumId");
                return;
            }

            AlbumDetails albumDetails = AlbumService.GetAlbumById(albumId);

            if (albumDetails.Title == null)
            {
                MessageBox.Show("Album with ID: " + albumId + " could not be found.");
                return;
            }

            mainGrid.DataContext = AlbumService.GetAlbumById(albumId);
        }
    }
}
