using goodtrip.Models;

namespace goodtrip.Managers
{
    public interface ISearchManager
    {
        List<TourModel> AllTours();
        List<TourModel> Filter(SearchModel searchModel);
    }
}
