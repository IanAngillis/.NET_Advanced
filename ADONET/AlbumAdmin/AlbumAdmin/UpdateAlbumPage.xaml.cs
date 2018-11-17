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
    /// Interaction logic for UpdateAlbumPage.xaml
    /// </summary>
    public partial class UpdateAlbumPage : Page
    {
        public UpdateAlbumPage()
        {
            InitializeComponent();

            genreComboBox.ItemsSource = GenreRepository.GetAllGenres();
            artistComboBox.ItemsSource = ArtistRepository.GetAllArtists();
            
        }

        private void getAlbumButton_Click(object sender, RoutedEventArgs e)
        {


            int albumId;

            try
            {
                albumId = Convert.ToInt32(albumIdTextBox.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Geef een correct album ID in");
                return;
            }

            AlbumDetails albumDetails = AlbumService.GetAlbumById(albumId);

            if (albumDetails.Title == null)
            {
                MessageBox.Show("Album with ID: " + albumId + " could not be found.");
                return;
            }
            mainGrid.DataContext = AlbumRepository.GetAlbumById(albumId);
            setCorrectGenre(AlbumRepository.GetAlbumById(albumId).GenreId);
            setCorrectArtist(AlbumRepository.GetAlbumById(albumId).ArtistId);
            EnableInputForms();
        }


        private void updateAlbumButton_Click(object sender, RoutedEventArgs e)
        {

            Album updatedAlbum = GetUpdatedAlbum();
            AlbumRepository.UpdateAlbumByAlbumId(updatedAlbum); 
 
        }

        private Album GetUpdatedAlbum()
        {
            Album album = (Album)mainGrid.DataContext;
            Genre genre = (Genre)genreComboBox.Items.GetItemAt(genreComboBox.SelectedIndex);
            Artist artist = (Artist)artistComboBox.Items.GetItemAt(artistComboBox.SelectedIndex);

            album.GenreId = genre.GenreId;
            album.ArtistId = artist.ArtistId;

            return album;
        }

        private void setCorrectGenre(int genreId)
        {
            for (int i = 0; i < genreComboBox.Items.Count; i++)
            {
                Genre genre = (Genre) genreComboBox.Items.GetItemAt(i);

                if (genre.GenreId == genreId)
                {
                    genreComboBox.SelectedIndex = i;
                }
            }
        }

        private void setCorrectArtist(int artistId)
        {
            for (int i = 0; i < artistComboBox.Items.Count; i++)
            {
                Artist artist = (Artist)artistComboBox.Items.GetItemAt(i);

                if (artist.ArtistId == artistId)
                {
                    artistComboBox.SelectedIndex = i;
                }
            }
        }

        private void DisableInputForms()
        {
            for (int i = 0; i < mainGrid.Children.Count; i++)
            {
                if (mainGrid.Children[i] is ComboBox)
                {
                    ComboBox selectedComboBox = (ComboBox)mainGrid.Children[i];
                    selectedComboBox.IsEnabled = false;
                }
                else if (mainGrid.Children[i] is TextBox)
                {
                    TextBox selectedTextBox = (TextBox)mainGrid.Children[i];
                    selectedTextBox.IsEnabled = false;
                }
               
            }

            MessageBox.Show("Input disabled");
        }

        private void EnableInputForms()
        {
            for (int i = 0; i < mainGrid.Children.Count; i++)
            {
                if (mainGrid.Children[i] is ComboBox)
                {
                    ComboBox selectedComboBox = (ComboBox)mainGrid.Children[i];
                    selectedComboBox.IsEnabled = true;
                }
                else if (mainGrid.Children[i] is TextBox)
                {
                    TextBox selectedTextBox = (TextBox)mainGrid.Children[i];
                    selectedTextBox.IsEnabled = true;
                }

            }

            updateAlbumButton.IsEnabled = true;
        }
    }
}
