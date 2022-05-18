using goodtrip.Models;
using goodtrip.Storage.Entity;

namespace goodtrip.Managers
{
    public interface IProfileManager
    {
        DocumentsModel DocumentsInfo(string username);
        Task ChangeDocumentsAsync(string username, DocumentsModel profile);
        void CreateTour(string username, NewTourModel newTourModel, IFormFileCollection files);
        List<Tour> AllTours(string username);
        void RemoveTour(string id);
        List<RequestModel> AllRequests(string username); EditTourModel TourEdit(Guid guid);
        void EditTour(Tour tour);
        void AcceptRequest(Guid guid);
        void RejectRequest(Guid guid);
        List<RequestModel> CustomerRequests(string username);
    }
}
