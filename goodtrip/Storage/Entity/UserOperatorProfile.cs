using goodtrip.Storage.Enums;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Storage.Entity
{
    public class UserOperatorProfile : UserProfile
    {
        //public BussinessInfo BussinessInfo {get; set;}
        public List<Tour> CreatedTours { get; set; }
    }
}
