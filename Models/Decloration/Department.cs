using System.ComponentModel.DataAnnotations.Schema;

namespace MotivTest.Models.Decloration
{
    [Table("Department")]
    public class Department : BasicDataType
    {
        public ICollection<Request>? Requests { get; set; }
    }
}
