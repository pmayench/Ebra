using SQLite;

namespace Ebra.App.Models
{
    public class EntityBase
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public EntityBase() { }
    }
}
