using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Myary.Models;

namespace Myary.Services
{
    public static class DatabaseService
    {
        private static SQLiteAsyncConnection _db;

        public static async Task InitAsync()
        {
            if (_db != null) return;

            string databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "MyaryDB.sqlite3");

            _db = new SQLiteAsyncConnection(databasePath);

            await _db.CreateTableAsync<DiaryEntry>();
            await _db.CreateTableAsync<DailyMetadata>();
            await _db.CreateTableAsync<MediaAttachment>();
        }

        public static async Task<List<DiaryEntry>> GetEntriesForDateAsync(DateTime targetDate)
        {
            await InitAsync();
            DateTime strictDate = targetDate.Date;
            return await _db.Table<DiaryEntry>().Where(e => e.Date == strictDate).ToListAsync();
        }

        public static async Task<int> SaveEntryAsync(DiaryEntry entry)
        {
            await InitAsync();

            if (entry.Id != 0) return await _db.UpdateAsync(entry);
            else return await _db.InsertAsync(entry);
        }

        public static async Task<int> DeleteEntryAsync(DiaryEntry entry)
        {
            await InitAsync();
            return await _db.DeleteAsync(entry);
        }

        public static async Task<DiaryEntry> GetRandomEntryAsync()
        {
            await InitAsync();
            var allEntries = await _db.Table<DiaryEntry>().ToListAsync();

            if (allEntries.Count == 0) return null;

            var random = new Random();
            int randomIndex = random.Next(0, allEntries.Count);
            return allEntries[randomIndex];
        }

        public static async Task<DailyMetadata> GetOrCreateDailyMetadataAsync(string dateId)
        {
            await InitAsync();
            var dayData = await _db.Table<DailyMetadata>().Where(d => d.DateId == dateId).FirstOrDefaultAsync();

            if (dayData == null)
            {
                dayData = new DailyMetadata { DateId = dateId, BackgroundConfig = "" };
                await _db.InsertAsync(dayData);
            }
            return dayData;
        }

        public static async Task<int> SaveDailyMetadataAsync(DailyMetadata metadata)
        {
            await InitAsync();
            return await _db.UpdateAsync(metadata);
        }
    }
}
