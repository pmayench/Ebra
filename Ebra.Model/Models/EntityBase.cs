using SQLite;

namespace Ebra.Models.Models
{
    public class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public EntityBase() { }
    }
}
