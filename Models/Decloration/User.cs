using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MotivTest.Models.Decloration
{
    [Table("User")]
    public class User : BasicDataType
    {
        public string? Surname { get; set; }
        public string? MiddleName { get; set; }
        public int LocalityId { get; set; }
        public string? Email { get; set; }

        [Required]
        public string Number { get; set; }
       
        public virtual Locality? Locality { get; set; }
        public ICollection<Request>? Requests { get; set; }
    }
}
