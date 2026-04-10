using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Myary.Models;
using CommunityToolkit.Mvvm.Input;
using Myary.Services;
using System.Linq;

namespace Myary.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private DateTime _selectedDate = DateTime.Today;

        public string FormattedSelectedDate => SelectedDate.ToString("dd MMM yyyy");

        partial void OnSelectedDateChanged(DateTime value)
        {
            OnPropertyChanged(nameof(FormattedSelectedDate));
        }

        [RelayCommand]
        private async Task AddEntryAsync()
        {
            int noteNumber = CurrentDayEntries.Count + 1;

            var newNote = new DiaryEntry
            {
                Date = SelectedDate.Date,
                Title = $"Daily Note {noteNumber}",
                RichTextContent = "",
                BackgroundConfig = "",
                IsBookmarked = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await DatabaseService.SaveEntryAsync(newNote);

            CurrentDayEntries.Add(newNote);

            ActiveEntry = newNote;
        }

        [RelayCommand]
        private async Task DeleteEntryAsync(DiaryEntry entry)
        {
            if (entry == null) return;
            await DatabaseService.DeleteEntryAsync(entry);
            CurrentDayEntries.Remove(entry);

            if (ActiveEntry == entry)
            {
                ActiveEntry = CurrentDayEntries.Count > 0 ?
                    CurrentDayEntries[0] : null;
            }
        }

        [ObservableProperty]
        private DiaryEntry _activeEntry;

        [ObservableProperty]
        private ObservableCollection<DiaryEntry> _currentDayEntries = new ObservableCollection<DiaryEntry>();

        [RelayCommand]
        private async Task OpenRandomEntryAsync()
        {
            var randomNote = await DatabaseService.GetRandomEntryAsync();
            if (randomNote == null) return;

            SelectedDate = randomNote.Date;

            var dayNotes = await DatabaseService.GetEntriesForDateAsync(randomNote.Date);
            CurrentDayEntries.Clear();
            foreach(var note in dayNotes)
            {
                CurrentDayEntries.Add(note);
            }

            ActiveEntry = CurrentDayEntries.FirstOrDefault(n => n.Id == randomNote.Id);
        }

        public MainViewModel()
        {
            // todo
        }
    }
}