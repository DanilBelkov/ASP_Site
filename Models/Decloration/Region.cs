using System.ComponentModel.DataAnnotations.Schema;

namespace MotivTest.Models.Decloration
{
    [Table("Region")]
    public class Region : BasicDataType
    {
        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public ICollection<Locality>? Localities { get; set; }
    }
}
