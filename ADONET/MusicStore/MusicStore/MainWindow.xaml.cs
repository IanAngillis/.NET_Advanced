using System.Windows;
using System.Windows.Controls;
using MusicStore.Business;
using MusicStore.Data;

namespace MusicStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GenreComboBox.ItemsSource = GenreService.GetGenres();
        }

        private void GenreComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GenreComboBox.SelectedIndex == -1)
            {
                return;
            }

            Genre selectedGenre = (Genre)GenreComboBox.SelectedItem;
            albumDataGrid.ItemsSource = AlbumSummaryService.GetAlbumSummariesByGenre(selectedGenre.ID);
        }
    }
}
