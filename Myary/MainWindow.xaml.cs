using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Myary.ViewModels;
using Myary.Services;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Myary.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Myary
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        private bool _isCalendarUpdating = false;

        public MainWindow()
        {
            this.InitializeComponent();

            ViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(ViewModel.ActiveEntry))
                    LoadActiveNoteIntoEditor();
            };

            this.Activated += MainWindow_Activated;
        }

        private bool _isInitialized = false;

        private async void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            if (_isInitialized) return;
            _isInitialized = true;

            await InitializeAppAsync();
        }

        private async Task InitializeAppAsync()
        {
            await DatabaseService.InitAsync();
            DayCalendar.SelectedDates.Clear();
            DayCalendar.SelectedDates.Add(new DateTimeOffset(DateTime.Today));
            
            var todayNotes = await DatabaseService.GetEntriesForDateAsync(DateTime.Today);

            ViewModel.CurrentDayEntries.Clear();
            foreach (var note in todayNotes)
            {
                ViewModel.CurrentDayEntries.Add(note);
            }

            if (ViewModel.CurrentDayEntries.Count == 0)
                await ViewModel.AddEntryCommand.ExecuteAsync(null);
            else
                ViewModel.ActiveEntry = ViewModel.CurrentDayEntries[0];
        }

        private void ToggleRightPane_Click(object sender, RoutedEventArgs e)
        {
            RightSidebarContent.Visibility = ToggleRightPaneButton.IsChecked == true
                ? Visibility.Visible : Visibility.Collapsed;
        }

        private async void DayCalendar_SelectedDatesChanged(CalendarView sender,
            CalendarViewSelectedDatesChangedEventArgs args)
        {
            if (_isCalendarUpdating) return;

            if(args.AddedDates.Count > 0)
            {
                _isCalendarUpdating = true;

                DateTime clickedDate = args.AddedDates[0].DateTime.Date;
                ViewModel.SelectedDate = clickedDate;

                DayCalendar.SelectedDates.Clear();
                DayCalendar.SelectedDates.Add(new DateTimeOffset(clickedDate));

                // sender.SelectedDates.Clear();
                // sender.SelectedDates.Add(new DateTimeOffset(clickedDate))

                var loadedNotes = await DatabaseService.GetEntriesForDateAsync(clickedDate);

                ViewModel.CurrentDayEntries.Clear();
                
                foreach (var note in loadedNotes)
                {
                    ViewModel.CurrentDayEntries.Add(note);
                }

                if (ViewModel.CurrentDayEntries.Count > 0)
                {
                    ViewModel.ActiveEntry = ViewModel.CurrentDayEntries[0];
                }
                else
                {
                    await ViewModel.AddEntryCommand.ExecuteAsync(null);
                }

                DayCalendar.SetDisplayDate(new DateTimeOffset(clickedDate));

                _isCalendarUpdating = false;
            }
        }

        private void DiaryEditor_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
        }

        private void NoteTab_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn && btn.DataContext is DiaryEntry entry)
            {
                ViewModel.ActiveEntry = entry;
            }
        }

        private void DiaryEditor_Drop(object sender, DragEventArgs e)
        {
            // todo
        }

        private async void DiaryEditor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ActiveEntry == null) return;

            DiaryEditor.Document.GetText(TextGetOptions.FormatRtf, out string rtfData);
            
            ViewModel.ActiveEntry.RichTextContent = rtfData;
            ViewModel.ActiveEntry.UpdatedAt = DateTime.Now;

            await DatabaseService.SaveEntryAsync(ViewModel.ActiveEntry);
        }

        private void LoadActiveNoteIntoEditor()
        {
            if (ViewModel.ActiveEntry == null ||
                string.IsNullOrEmpty(ViewModel.ActiveEntry.RichTextContent))
                DiaryEditor.Document.SetText(TextSetOptions.FormatRtf, "");

            else
                DiaryEditor.Document.SetText(TextSetOptions.FormatRtf, ViewModel.ActiveEntry.RichTextContent);

            UpdateFavoriteIcon();
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e) =>
            DiaryEditor.Document.Selection.CharacterFormat.Bold = FormatEffect.Toggle;

        private void ItalicButton_Click(object sender, RoutedEventArgs e) =>
            DiaryEditor.Document.Selection.CharacterFormat.Italic = FormatEffect.Toggle;

        private void UnderlineButton_Click(object sender, RoutedEventArgs e) =>
            DiaryEditor.Document.Selection.CharacterFormat.Underline = UnderlineType.Single;

        private void FontBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox cb && cb.SelectedItem is ComboBoxItem item)
                DiaryEditor.Document.Selection.CharacterFormat.Name = item.Content.ToString();
        }

        private void FontSizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox cb && cb.SelectedItem is ComboBoxItem item)
            {
                if (float.TryParse(item.Content.ToString(), out float size))
                    DiaryEditor.Document.Selection.CharacterFormat.Size = size;
            }
        }

        private async void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem menuItem && menuItem.DataContext is DiaryEntry entry)
            {
                await ViewModel.DeleteEntryCommand.ExecuteAsync(entry);
            }
        }

        private async void FavoriteToggle_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ActiveEntry == null) return;

            ViewModel.ActiveEntry.IsBookmarked = !ViewModel.ActiveEntry.IsBookmarked;
            ViewModel.ActiveEntry.UpdatedAt = DateTime.Now;

            FavoriteIcon.Glyph = ViewModel.ActiveEntry.IsBookmarked ? "\uEB52" : "\uEB51";

            await DatabaseService.SaveEntryAsync(ViewModel.ActiveEntry);
        }

        private void UpdateFavoriteIcon()
        {
            if (ViewModel.ActiveEntry == null)
            {
                FavoriteIcon.Glyph = "\uEB51";
                return;
            }
            FavoriteIcon.Glyph = ViewModel.ActiveEntry.IsBookmarked ? "\uEB52" : "\uEB51";
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem item)
            {
                var color = HexToColor(item.Tag.ToString());
                DiaryEditor.Document.Selection.CharacterFormat.ForegroundColor = color;
            }
        }

        private void Highlight_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuFlyoutItem item)
            {
                var color = HexToColor(item.Tag.ToString());
                DiaryEditor.Document.Selection.CharacterFormat.BackgroundColor = color;
            }
        }

        private Windows.UI.Color HexToColor(string hex)
        {
            if (hex == "Transparent")
                return Windows.UI.Color.FromArgb(0, 0, 0, 0);

            hex = hex.TrimStart('#');

            byte r = System.Convert.ToByte(hex.Substring(0, 2), 16);
            byte g = System.Convert.ToByte(hex.Substring(2, 2), 16);
            byte b = System.Convert.ToByte(hex.Substring(4, 2), 16);

            return Windows.UI.Color.FromArgb(255, r, g, b);
        }
    }
}






