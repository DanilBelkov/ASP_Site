using MotivTest.Models.Decloration;

namespace MotivTest.Models
{
    public class RequestRegisterViewModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Locality { get; set; }
        public string Number { get; set; }
        public string Reason { get; set; }
        public string Department { get; set; }
        public DateTime Date { get; set; }

        public static IQueryable<RequestRegisterViewModel> GetProjection(IQueryable<Request> query)
        {
            return query.Select(x => new RequestRegisterViewModel
            {
                Id = x.Id,
                Country = x.User.Locality.Region.Country.Name, 
                Region = x.User.Locality.Region.Name,
                Locality = x.User.Locality.Name,
                Number = x.User.Number,
                Reason = x.Reason,
                Department = x.Department.Name,
                Date = x.Date
            });
        }

    }
}
