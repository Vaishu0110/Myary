using SQLite;

namespace Myary.Models
{
    public class MediaAttachment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int DiaryEntryId { get; set; }

        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}