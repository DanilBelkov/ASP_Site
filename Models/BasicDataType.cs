using System.ComponentModel.DataAnnotations;

namespace MotivTest.Models
{
    public class BasicDataType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
