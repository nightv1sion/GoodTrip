using goodtrip.Storage.Enums;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class UserCustomerProfile : UserProfile
    {
        public List<Request> SendedRequests { get; set; }
        
    }
}
