using goodtrip.Models;
using goodtrip.Storage.Entity;

namespace goodtrip.Managers
{
    public interface ITourManager
    {
        Tour FindTour(Guid id);
        List<string> FindHotelPhotos(Tour tour);
        List<string> FindExcursionPhotos(Tour tour);
        string FindCommentName(string username);
        Task CommentAsync(TourInfoModel tourInfoModel);
        Task<UserCustomerProfile> TakeProfileInfoAsync(string username);
        Task<Request> CreateRequestAsync(RequestModel requestModel, string username);
    }
}
