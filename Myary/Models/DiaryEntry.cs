using Microsoft.UI.Composition;
using SQLite;
using System;

namespace Myary.Models
{
    public class DiaryEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string RichTextContent { get; set; }

        public string BackgroundConfig { get; set; }

        public BooleanKeyFrameAnimation IsBookmarked { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}