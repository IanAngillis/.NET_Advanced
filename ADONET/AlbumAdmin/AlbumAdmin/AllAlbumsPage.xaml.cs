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
    /// Interaction logic for AllAlbumsPage.xaml
    /// </summary>
    public partial class AllAlbumsPage : Page
    {
        public AllAlbumsPage()
        {
            InitializeComponent();

            albumDataGrid.ItemsSource = AlbumRepository.GetAlbums();
        }
    }
}
