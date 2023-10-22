using System.ComponentModel.DataAnnotations.Schema;

namespace MotivTest.Models.Decloration
{
    [Table("Request")]
    public class Request : BasicDataType
    {
        public int UserId { get; set; }
        public string? Reason { get; set; }
        public int DepartmentId { get; set; }
        public DateTime Date { get; set; }

        public virtual User? User { get; set; }
        public virtual Department? Department { get; set; }

    }
}
