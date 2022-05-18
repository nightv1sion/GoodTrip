using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Managers
{
    public class TourManager : ITourManager
    {
        private readonly GoodTripContext _context;
        public TourManager(GoodTripContext context)
        {
            _context = context;
        }
        public Tour FindTour(string id)
        {
            Guid guid = new Guid(id);
            Tour tour = _context.Tours.Include(t => t.Excurtion).Include(t => t.Hotel).Include(t => t.Review).ToList<Tour>().FirstOrDefault(t => t.Id == guid);
            if (tour != null)
            {
                tour.Hotel.Images = _context.ImagesHotel.Where(i => i.HotelId == tour.Hotel.Id).ToList();
                foreach (var excurtion in tour.Excurtion)
                {
                    excurtion.Images = _context.ImagesExcurtion.Where(i => i.ExcurtionId == excurtion.Id).ToList();
                }
            }
            else
            {
                return null;
            }
            tour.Review = tour.Review.OrderByDescending(r => r.Created).ToList<Review>();
            return tour;
        }
        public List<string> FindHotelPhotos(Tour tour)
        {
            List<string> hotelPhotos = new List<string>();
            foreach (var photo in tour.Hotel.Images)
            {
                hotelPhotos.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(photo.ImageData)));
            }
            return hotelPhotos;
        }
        public List<string> FindExcursionPhotos(Tour tour)
        {
            List<string> excurtionPhotos = new List<string>();
            foreach (var excurtion in tour.Excurtion)
            {
                if (excurtion.Images.Count != 0)
                {
                    excurtionPhotos.Add(string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(excurtion.Images[0]?.ImageData)));
                }
            }
            return excurtionPhotos;
        }
        public string FindCommentName(string username)
        {
            return _context.Users.Include(u => u.Profile).FirstOrDefault(u => u.UserName == username)?.Profile?.Name;
        }

        public async Task CommentAsync(TourInfoModel tourinfoModel)
        {
            Tour tour = await _context.Tours.FirstOrDefaultAsync(t => t.Id == Guid.Parse(tourinfoModel.TourId));
            if (tour != null)
            {
                Review review = new Review()
                {
                    Id = Guid.NewGuid(),
                    Tour = tour,
                    TourId = tour.Id,
                    Created = DateTime.Now,
                    Text = tourinfoModel.CommentText,
                    Username = tourinfoModel.CommentName
                };
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<UserCustomerProfile> TakeProfileInfoAsync(string username)
        {
            return await _context.UserCustomerProfiles.Include(p => p.User).FirstOrDefaultAsync(p => p.User.UserName == username);
        }
        public async Task<Request> CreateRequestAsync(RequestModel requestModel, string username)
        {
            Request newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                CustomerName = requestModel.CustomerName,
                CustomerLastName = requestModel.CustomerLastName,
                PhoneNumber = requestModel.PhoneNumber,
                AmountOfTourists = requestModel.AmountOfTourists,
                Duration = requestModel.Duration,
                CustomerWishes = requestModel.CustomerWishes,
            };

            Tour choosedTour = await _context.Tours.FirstOrDefaultAsync(t => t.Id == Guid.Parse(requestModel.TourId));
            newRequest.Tour = choosedTour;
            newRequest.TourId = choosedTour.Id;

            UserCustomerProfile customer = await _context.UserCustomerProfiles.Include(p => p.User).FirstOrDefaultAsync(p => p.User.UserName == username);
            newRequest.CustomerProfileId = customer.UserProfileId;

            newRequest.OperatorProfileId = choosedTour.TourOperatorProfileId;
            newRequest.Created = DateTime.Now;

            await _context.Requests.AddAsync(newRequest);
            await _context.SaveChangesAsync();
            return newRequest;
        }
    }
}
