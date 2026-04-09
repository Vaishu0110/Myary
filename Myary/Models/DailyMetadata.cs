using SQLite;

namespace Myary.Models
{
    public class DailyMetadata
    {
        [PrimaryKey]
        public string DateId { get; set; }

        public string BackgroundConfig { get; set; }
    }
}