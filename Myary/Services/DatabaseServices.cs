using System;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;
using Myary.Models;

namespace Myary.Services
{
    public static class DatabaseServices
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
    }
}
