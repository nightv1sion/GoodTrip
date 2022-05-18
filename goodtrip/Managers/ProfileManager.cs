using goodtrip.Models;
using goodtrip.Storage;
using goodtrip.Storage.Entity;
using goodtrip.Storage.Enums;
using Microsoft.EntityFrameworkCore;

namespace goodtrip.Managers
{
    public class ProfileManager : IProfileManager
    {
        private readonly GoodTripContext _context;
        public ProfileManager(GoodTripContext context)
        {
            _context = context;
        }
        public DocumentsModel DocumentsInfo(string username)
        {
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.UserName == username) : null;
            DocumentsModel profile = new DocumentsModel();
            if (user != null)
            {
                profile.Name = user.Profile.Name;
                profile.LastName = user.Profile.LastName;
                profile.BirthDay = user.Profile.BirthDay;
                profile.Nationality = user.Profile.Nationality.ToString();
                profile.Gender = user.Profile.Gender.ToString().ToLower();
                profile.PassNumber = user.Profile.PassportNumber;
                profile.PassValidityPeriod = user.Profile.PassportValidityPeriod;
            }
            return profile;
        }
        public async Task ChangeDocumentsAsync(string username, DocumentsModel profile)
        {
            User user = username != null ? _context.Users.Include(user => user.Profile).FirstOrDefault(u => u.UserName == username) : null;
            UserProfile userprofile = user.Profile;
            if (userprofile != null)
            {
                userprofile.Name = profile.Name;
                userprofile.LastName = profile.LastName;
                userprofile.BirthDay = profile.BirthDay;
                userprofile.Nationality = profile.Nationality == "Russia" ? Nationality.Russia : Nationality.Europe;
                userprofile.Gender = profile.Gender == "male" ? Gender.Male : Gender.Female;
                userprofile.PassportNumber = profile.PassNumber;
                userprofile.PassportValidityPeriod = profile.PassValidityPeriod;
                _context.Update<User>(user);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public void CreateTour(string username, NewTourModel newtourModel, IFormFileCollection files)
        {
            UserOperatorProfile creator = _context.UserOperatorProfiles.Include(p => p.User).FirstOrDefault(p => p.User.UserName == username);
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = newtourModel.TourName,
                City = newtourModel.TourCity,
                Country = newtourModel.TourCountry,
                Description = newtourModel.TourDescription,
                Duration = newtourModel.TourDuration,
                StartDate = newtourModel.StartDate,
                EndDate = newtourModel.EndDate,
                MaxTourists = newtourModel.TourMaxTourists,
                Price = newtourModel.TourPrice,
            };
            if (creator != null)
            {
                tour.TourOperatorProfile = creator;
                tour.TourOperatorProfileId = creator.UserProfileId;
            }
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = newtourModel.HotelName,
                City = newtourModel.HotelCity,
                Country = newtourModel.HotelCountry,
                Address = newtourModel.HotelAddress,
                Description = newtourModel.HotelDescription,
                Feeding = newtourModel.HotelFeeding == "yes" ? true : false,
                FreeRooms = newtourModel.HotelFreeRooms,
                Rooms = newtourModel.HotelRooms,
                Mark = newtourModel.HotelMark,
                IsWifi = newtourModel.HotelIsWifi == "yes" ? true : false,
                Tour = tour,
                TourId = tour.Id,
                Images = new List<ImageHotel>()
            };
            foreach (var file in files)
            {
                ImageHotel img = new ImageHotel();
                img.ImageTitle = file.FileName;
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();
                ms.Close(); ms.Dispose();
                img.Id = Guid.NewGuid();
                img.Hotel = hotel; img.HotelId = hotel.Id;
                hotel.Images.Add(img);
            }
            ImageHotel imghotellast = hotel.Images[hotel.Images.Count - 1];
            ImageExcurtion imgexc = new ImageExcurtion()
            {
                ImageData = imghotellast.ImageData,
                ImageTitle = imghotellast.ImageTitle,
                Id = Guid.NewGuid()
            };
            hotel.Images.RemoveAt(hotel.Images.Count - 1);
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = newtourModel.ExcursionName,
                Description = newtourModel.ExcursionDescription,
                Duration = newtourModel.ExcursionDuration,
                Language = newtourModel.ExcursionLanguage,
                MaxAmountOfVisitors = newtourModel.ExcursionMaxAmountOfVisitors,
                Place = newtourModel.ExcursionPlace,
                Tour = tour,
                TourId = tour.Id,
                Images = new List<ImageExcurtion>()
            });
            imgexc.Excurtion = tour.Excurtion[0];
            imgexc.ExcurtionId = tour.Excurtion[0].Id;
            tour.Excurtion[0].Images.Add(imgexc);
            _context.Tours.Add(tour);
            _context.SaveChanges();
        }
        public List<Tour> AllTours(string username)
        {
            return _context.Tours.Include(t => t.TourOperatorProfile).Include(t => t.TourOperatorProfile.User).
                Where(t => t.TourOperatorProfile.User.UserName == username).ToList();
        }
        public void RemoveTour(string id)
        {
            Guid guid = Guid.Parse(id);
            Tour tourtodelete = _context.Tours.FirstOrDefault(t => t.Id == guid);
            if (tourtodelete != null)
            {
                _context.Tours.Remove(tourtodelete);
            }
            _context.SaveChanges();
            return;
        }
        public List<RequestModel> AllRequests(string username)
        {
            User currentOperator = _context.Users.Include(u => u.Profile).FirstOrDefault(u => u.UserName == username);
            List<Request> requests;
            if (currentOperator != null)
            {
                requests = _context.Requests.Where(r => r.OperatorProfileId == currentOperator.Profile.UserProfileId).ToList();
            }
            else
            {
                return null;
            }
            List<RequestModel> searchedRequests = new List<RequestModel>();
            foreach (var request in requests)
            {
                RequestModel model = new RequestModel()
                {
                    CustomerName = request.CustomerName,
                    CustomerLastName = request.CustomerLastName,
                    PhoneNumber = request.PhoneNumber,
                    TourId = request.TourId.ToString(),
                    TourName = _context.Tours.FirstOrDefault(t => t.Id == request.TourId)?.Name
                };
                searchedRequests.Add(model);
            }
            return searchedRequests;
        }

        public EditTourModel TourEdit(Guid guid)
        {
            if (guid != null)
            {
                Tour tour = _context.Tours.FirstOrDefault(t => t.Id == guid);
                Hotel hotel = _context.Hotels.FirstOrDefault(t => t.TourId == guid);
                Excurtion excursion = _context.Excurtions.FirstOrDefault(t => t.TourId == guid);
                EditTourModel model = new EditTourModel();

                model.Id = tour.Id;
                model.TourName = tour.Name;
                model.TourCity = tour.City;
                model.StartDate = tour.StartDate;
                model.EndDate = tour.EndDate;
                model.TourCountry = tour.Country;
                model.TourDescription = tour.Description;
                model.TourMaxTourists = tour.MaxTourists;
                model.TourPrice = tour.Price;
                model.TourDuration = tour.Duration;

                model.HotelName = hotel.Name;
                model.HotelDescription = hotel.Description;
                model.HotelMark = hotel.Mark;
                model.HotelCountry = hotel.Country;
                model.HotelCity = hotel.City;
                model.HotelAddress = hotel.Address;
                model.HotelRooms = hotel.Rooms;
                model.HotelFreeRooms = hotel.FreeRooms;
                model.HotelIsWifi = hotel.IsWifi;
                model.HotelFeeding = hotel.Feeding;

                model.ExcursionDuration = excursion.Duration;
                model.ExcursionPlace = excursion.Place;
                model.ExcursionMaxAmountOfVisitors = excursion.MaxAmountOfVisitors;
                model.ExcursionLanguage = excursion.Language;
                model.ExcursionName = excursion.Name;
                model.ExcursionDescription = excursion.Description;

                    return model;
            }
            else return null;
        }
        public void EditTour(Tour tour)
        {
            _context.Tours.Update(tour);
            _context.SaveChangesAsync();
        }
    }
}
