using MotivTest.Data.Enums;

namespace MotivTest.Models
{
    public class RequestSearchViewModel
    {
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? Locality { get; set; }
        public string? Number { get; set; }
        public string? Reason { get; set; }
        public DepartmentEnum? Department { get; set; }
        public DateTime? Date { get; set; }
    }
}
