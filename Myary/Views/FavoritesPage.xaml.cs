using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Myary.Models;
using Myary.Services;

namespace Myary.Views
{
    public sealed partial class FavoritesPage : Page
    {
        public FavoritesPage()
        {
            this.InitializeComponent();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var favorites = await DatabaseService.GetBookmarkedEntriesAsync();

            if (favorites.Count == 0)
            {
                FavoritesList.Visibility = Visibility.Collapsed;
                EmptyState.Visibility = Visibility.Visible;
            }
            else
            {
                FavoritesList.ItemsSource = favorites;
                FavoritesList.Visibility = Visibility.Visible;
                EmptyState.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenFavorite_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is DiaryEntry entry)
            {
                var mainWindow = (MainWindow)
                    ((App)Application.Current)._window;
                mainWindow.NavigateToEntry(entry);
            }
        }
    }
}