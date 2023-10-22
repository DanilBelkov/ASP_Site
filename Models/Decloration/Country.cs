using System.ComponentModel.DataAnnotations.Schema;

namespace MotivTest.Models.Decloration
{
    [Table("Country")]
    public class Country : BasicDataType
    {
        public string? ShortName { get; set; }

        public ICollection<Region>? Regions { get; set; }
    }
}
