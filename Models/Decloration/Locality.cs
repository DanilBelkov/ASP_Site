using System.ComponentModel.DataAnnotations.Schema;

namespace MotivTest.Models.Decloration
{
    [Table("Locality")]
    public class Locality : BasicDataType
    {
        public int RegionId { get; set; }

        public Region? Region { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
