/*using goodtrip.Storage;
using goodtrip.Storage.Entity;

namespace goodtrip
{
    public class SeedDataClass
    {
        static public void SuperSeed(GoodTripContext _dbContext)
        {
            SeedData(_dbContext);
            SeedData1(_dbContext);
            SeedData2(_dbContext);
            SeedData3(_dbContext);
            SeedData4(_dbContext);
            SeedData5(_dbContext);
            Seed(_dbContext);
            Seed2(_dbContext);
            Seed3(_dbContext);
            Seed4(_dbContext);
            Seed5(_dbContext);
        }
        static public void Seed(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Sightseeing tour of New-York",
                City = "New-York",
                Country = "USA",
                Description = "Make the most of your time in the city that never sleeps on a guided tour of NYC’s top attractions. Travel by both the Staten Island Ferry and bus as you swing by the 9/11 Memorial, Central Park, Rockefeller Center and more. Then hop aboard a luxury boat for a sightseeing cruise past the Statue of Liberty and Ellis Island, complete with stunning views of the world-famous skyline and Brooklyn Bridge.",
                Duration = 7,
                MaxTourists = 5,
                TourOperator = "AmericanToursFE",
                StartDate = new DateTime(2022, 05, 25),
                EndDate = new DateTime(2022, 06, 20),
                Price = 5000
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Sofitel New York",
                City = "New-York",
                Description = "Explore Manhattan and all that the city has to offer from Sofitel New York. Situated between Fifth and Sixth Avenues, just a stone’s throw from Fifth Avenue and Times Square, the hotel offers the perfect home base from which to explore all of the Big Apple’s attractions and events.",
                Country = "USA",
                Address = "45 West 44th Street",
                Feeding = true,
                FreeRooms = 8,
                Rooms = 45,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NewYorkHotel1.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NewYorkHotel2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NewYorkHotel3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Unforgettable New-York",
                Description = "Getting to know the main sights of the city without internal visits: Central Park, Fifth Avenue, Museum Mile, Times Square, Rockefeller Center, UN Complex, Empire State Building, Iron Skyscraper, Highline Park, Wall Street, Battery Park, Statue of Liberty from the Shore, Brooklyn Bridge, Chinatown, districts Little Italy and Soho and much more.",
                Duration = 8,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Centre of New-York",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NewYorkExcursion.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        static public void Seed2(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Magnificent Сhicago",
                City = "Chicago",
                Country = "USA",
                Description = "Chicago is located on the southwestern shore of Lake Michigan, the third most populous city in the United States after New York and Los Angeles, a major financial and transportation center. Perhaps Chicago is one of the most architecturally interesting cities in the United States.Unusual skyscrapers create a stunning panorama of the city, which looks especially exciting in the evening when the setting sun is reflected in the glass of high - rise buildings. A fascinating tour of the architectural capital of America: for you the most diverse architectural styles, stories about gangster times, the great fire and much more.",
                Duration = 15,
                MaxTourists = 7,
                TourOperator = "AmericanToursFE",
                StartDate = new DateTime(2022, 05, 31),
                EndDate = new DateTime(2022, 08, 15),
                Price = 3500
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Warwick Allerton - Chicago",
                City = "Chicago",
                Description = "Ideally located in the heart of downtown Chicago, the Warwick Allerton is the perfect jumping off point to explore the legendary charms of the Windy City. From premium shopping and authentic Chicago dining along the Magnificent Mile, to breathtaking outdoor events at Millennium Park, there’s something for everyone to enjoy nearby while staying at Warwick Allerton - Chicago.",
                Country = "USA",
                Address = "701 N Michigan Avenue",
                Feeding = false,
                FreeRooms = 13,
                Rooms = 90,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\ChicagoHotel1.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\ChicagoHotel2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\ChicagoHotel3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Unforgettable New-York",
                Description = @"The Commercial Heart of Chicago or the Magnificent Mile
                The magnificent mile: a street of department stores, restaurants and luxury boutiques, is transformed in summer, when it is drowned in colorful tulips and in winter, luring tourists with thousands of New Year's lights.
                John Hancock Center or, as the Chicagoans call it, Big John is a skyscraper that has not been equaled in height for a long time.
                The water tower is the pride of the city, the oldest structure in Chicago that survived the Great Fire of 1871.
                The luxurious historic hotel is the Drake Hotel, where many heads of state, as well as prominent artists have stayed.
                A slender architectural masterpiece is the Vrigley skyscraper, owned by the chewing magnate Vrigley.
                The Chicago Tribune is one of the most beautiful office buildings in the world, which still houses the publishing house of the famous newspaper.
                The Michigan Avenue Bridge is a bridge over the Chicago River, whose four towers, installed at the base of the bridge, each tell about the historical events of the city.
                Chicago LOOP - exchanges, skyscrapers.The financial heart of Chicago
                The Chicago Theater is a great place for theatrical productions, performances, magic shows, comedies and concerts of popular music.Once the theater even had the title – Miracle Theater of the World.
                Willis Tower is a tall, slender skyscraper that attracts tourists with its observation deck with a glass floor and a 360 - degree view of the city.
                State Street, which Frank Sinatra glorified in his songs, is famous for its shopping malls and the phrase Give a woman everything she wants and she will be happy.
                A noisy railway loop that circled the whole area.Yes, maybe it visually spoils the city, but historically it is important for the city.
                The famous Route 66, which originates in Chicago and ends in Santa Monica.What about without a photo with a historical sign?",
                Duration = 8,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Heart of Chicago",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\ChicagoExcursion.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        static public void Seed4(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Amazing Orlando",
                City = "Orlando",
                Country = "USA",
                Description = "Orlando, city, seat (1856) of Orange county, central Florida, U.S. It is situated in a region dotted by lakes, about 60 miles (95 km) northwest of Melbourne and 85 miles (135 km) northeast of Tampa. The city is the focus for one of the state's most populous metropolitan areas.",
                Duration = 20,
                MaxTourists = 11,
                TourOperator = "AmericanToursFE",
                StartDate = new DateTime(2022, 05, 17),
                EndDate = new DateTime(2022, 06, 20),
                Price = 4700
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "DoubleTree by Hilton at the Entrance to Universal Orlando",
                City = "Orlando",
                Description = @"This hotel is superbly located opposite the entrance to the Universal Orlando Resort amusement park. Guests are provided with numerous free services and first-class facilities. The hotel is close to all the main attractions of the area. The Walt Disney World Recreation Center Amusement Park is 15.8 km away.
                The Doubletree Hotel at the entrance to Universal Orlando is equipped with all the amenities necessary for an unforgettable stay. Guests can watch a movie on the flat-screen TV, take a refreshing dip in the semi-Olympic-sized pool, or plan day trips at the leisure desk.",
                Country = "USA",
                Address = "5780 Major Boulevard,",
                Feeding = false,
                FreeRooms = 30,
                Rooms = 90,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\OrlandoHotel1.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\OrlandoHotel2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\OrlandoHotel3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Cool Orlando",
                Description = @"Excursion with a visit to one of the parks of the Walt Disney Recreation Center: Hollywood Studios, or EPCOT Center, or Animal Kingdom, or one of the Typhoon Lagoon water parks, or Wizard Beach) (8 hours)",
                Duration = 8,
                Language = "English",
                MaxAmountOfVisitors = 20,
                Place = "Orlando's best parks",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\OrlandoExcursion.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        static public void Seed3(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Beautiful Philadelphia",
                City = "Philadelphia",
                Country = "USA",
                Description = "Pennsylvania's largest city is known as the home of the Liberty Bell, Independence Hall and the Rocky statue. Philadelphia, a city in Pennsylvania whose name means City of Brotherly Love, was originally settled by Native American tribes, particularly the Lenape hunter gatherers, around 8000 B.C.",
                Duration = 15,
                MaxTourists = 11,
                TourOperator = "AmericanToursFE",
                StartDate = new DateTime(2022, 06, 02),
                EndDate = new DateTime(2022, 07, 15),
                Price = 7500
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Hampton Inn Philadelphia Center City-Convention Center",
                City = "Philadelphia",
                Description = "We're across the street from the Pennsylvania Convention Center and a 20-minute walk from the Liberty Bell and Independence Hall. Countless restaurants can be found within half a mile, near City Hall, or in Chinatown, while Pub 1301 is here in the hotel. The Franklin Institute and Philadelphia Museum of Art are within two miles. Enjoy free hot breakfast and free WiFi.",
                Country = "USA",
                Address = "1301 Race S",
                Feeding = true,
                FreeRooms = 15,
                Rooms = 46,
                IsWifi = true,
                Mark = 3,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\PhiladelphiaHotel1.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\PhiladelphiaHotel2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\PhiladelphiaHotel3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Essential Philadelphia",
                Description = @"Excursion to Philadelphia and Dupont Gardens accompanied by a Russian-speaking guide. Information on the way. Sightseeing tour of Philadelphia. Visit to the Rodin Museum. Visit the famous Dupont Gardens. Return to New York. The duration of the tour is 14 hours. The tour starts and ends at the hotel.",
                Duration = 3,
                Language = "English",
                MaxAmountOfVisitors = 30,
                Place = "Central Philadelphia",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\PhiladelphiaExcursion.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        static public void Seed5(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Excellent San-Francisco",
                City = "San-Francisco",
                Country = "USA",
                Description = "San Francisco is famous for its Golden Gate Bridge, steep streets, Alcatraz, and – you got it, dude! – Full House. The thirteenth largest city in the United States also has some pretty interesting historical facts.",
                Duration = 35,
                MaxTourists = 18,
                TourOperator = "AmericanToursFE",
                StartDate = new DateTime(2022, 05, 25),
                EndDate = new DateTime(2022, 06, 15),
                Price = 8500
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Riu Plaza Fisherman's Wharf",
                City = "Sam-Francisco",
                Description = @"The family-run Riu Plaza Fisherman's Wharf is a 10-minute walk from Pier 39. It offers non-smoking rooms and an outdoor pool. All rooms are equipped with a 49-inch flat-screen TV.
                Each room at Riu Plaza Fisherman's Wharf is equipped with air conditioning, ironing facilities, a safe and tea/coffee making facilities. The rooms are equipped with beds with luxurious linens and a large desk with a chair.
                The hotel's concierge service organizes an outdoor day by the campfire, wine tasting or a tour of the bay. Free Wi-Fi is available in the hotel lobby. The hotel also offers a business center and event facilities.
                The Northpoint Bar & Restaurant serves breakfast, lunch and dinner. The restaurant serves local cuisine, specialty cocktails, craft beer and California wines.
                Riu Plaza Fisherman's Wharf is 500 metres from Cannery Mall. The famous Golden Gate Bridge is 6 km away. Girardelli Square is a 12-minute walk away.
                This is our guests' favorite part of San Francisco, according to independent reviews.
                Couples especially like the location — they appreciated living in this area for a trip together on",
                Country = "USA",
                Address = "2500 Mason Street",
                Feeding = true,
                FreeRooms = 25,
                Rooms = 70,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SanFranciscoHotel1.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SanFranciscoHotel2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SanFranciscoHotel3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Interesting San-Francisco",
                Description = @"In the program of the tour, we offer an introduction to the history of San Francisco and its main attractions: Golden Gate Bridge, business Center, Opera House, Old Mission Dolores, Twin Peaks Peak, Japanese Garden, Palace of Fine Arts, Russian Hill, Lombard Street, financial district of the city, Nob Hill quarter.",
                Duration = 11,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Main attractions of San-Francisco",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SanFranciscoExcursion.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public static void SeedData(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "The American Dream",
                City = "Los-Angeles",
                Country = "USA",
                Description = "Fulfill your American Dream! Visit LA with us.",
                Duration = 7,
                StartDate = new DateTime(2022, 5, 18),
                EndDate = new DateTime(2022, 5, 25),
                MaxTourists = 5,
                TourOperator = "TravelAroundTheUS",
                Price = 1800
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Marriott LAX 4",
                City = "Los-Angeles",
                Description = "The Los Angeles Marriott Airport is an excellent choice for guests of Los Angeles, the family atmosphere and many useful services will make your stay very pleasant.",
                Country = "USA",
                Address = "5855 West Century Boulevard",
                Feeding = true,
                FreeRooms = 13,
                Rooms = 40,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\hotelLAX3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Getting to know Los Angeles",
                Description = "Los Angeles, getting to know the city. Excursion to the historical and modern center, Griffith Park - a fantastic panorama of the city, a photo session against the background of the famous inscription HOLLYWOOD.",
                Duration = 12,
                Language = "English",
                MaxAmountOfVisitors = 10,
                Place = "Around the Los Angeles",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\los-angelesExcursion1.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public static void SeedData1(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Meeting New York",
                City = "New-York",
                Country = "USA",
                Description = "You will meet New-York and get to know a lot of about this amazing city",
                Duration = 6,
                StartDate = new DateTime(2022, 5, 20),
                EndDate = new DateTime(2022, 5, 26),
                MaxTourists = 4,
                TourOperator = "AmericanToursFE",
                Price = 1000
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Springhill by Marriott Midtown Manhattan",
                City = "New-York",
                Description = "The most modern hotel of the East",
                Country = "USA",
                Address = "111 East 24 Street",
                Feeding = true,
                FreeRooms = 28,
                Rooms = 50,
                IsWifi = true,
                Mark = 5,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SpringHill.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SpringHill2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\SpringHill3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Niaghara Waterfall",
                Description = "Morning trip to NW",
                Duration = 8,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Niaghara Waterfall",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\NigWat.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public static void SeedData2(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Las-Vegas",
                City = "Las-Vegas",
                Country = "USA",
                Description = "We offer a guaranteed tour to Las Vegas for 4 days, with accommodation in the center of the Strip in hotel. During the tour you will learn all about Las Vegas, its main attractions and the best casinos. If you wish, you can go on an excursion to Death Valley or Hoover Dam.",
                Duration = 4,
                StartDate = new DateTime(2022, 5, 28),
                EndDate = new DateTime(2022, 6, 02),
                MaxTourists = 3,
                TourOperator = "AmericanToursFE",
                Price = 2900
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Harrah’s",
                City = "Las-Vegas",
                Description = "At Harrah’s, playtime is never over. Harrah’s offers a fun gaming atmosphere, world-class entertainment and welcoming rooms. Here is a place that’s friendly, lighthearted and exciting – the perfect spot to come out and play.",
                Country = "USA",
                Address = "3475 S Las Vegas Blvd",
                Feeding = false,
                FreeRooms = 10,
                Rooms = 25,
                IsWifi = true,
                Mark = 3,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Harra.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Harra2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Harra3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Evening Las-Vegas",
                Description = "Evening excursion in LV to see lost of sights",
                Duration = 4,
                Language = "English",
                MaxAmountOfVisitors = 12,
                Place = "Center of Las-Vegas",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\EVex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "To the Grand Canyon",
                Description = "Enjoy 6 hours at the Grand Canyon, compared to 3 hours offered by other companies. West Rim includes Eagle Point & Guano Point. Photo stop at the Hoover Dam Bypass",
                Duration = 6,
                Language = "English",
                MaxAmountOfVisitors = 8,
                Place = "Grand Canyon",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\GCex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages2.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public static void SeedData3(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Maiami Beaches",
                City = "Maiami",
                Country = "USA",
                Description = "The luxury and glitz of the American oceanfront lifestyle",
                Duration = 8,
                StartDate = new DateTime(2022, 5, 31),
                EndDate = new DateTime(2022, 6, 07),
                MaxTourists = 8,
                TourOperator = "SandAndWater",
                Price = 3400
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "TRUMP INTERNATIONAL BEACH RESORT",
                City = "Maiami",
                Description = "A modern oceanfront hotel in the Sunny Isles area. The hotel was built by the famous entrepreneur and millionaire Donald Trump and in 2008 became part of The Leading Hotels of the World.",
                Country = "USA",
                Address = "18001 Collins Ave, Miami Beach",
                Feeding = true,
                FreeRooms = 32,
                Rooms = 50,
                IsWifi = true,
                Mark = 5,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Trump.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Trump2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Trump3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Miami Seaquarium",
                Description = "You will see a lot of sea inhabitants",
                Duration = 3,
                Language = "English",
                MaxAmountOfVisitors = 30,
                Place = "Miami Seaquarium",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Msea.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Jungle Island",
                Description = "Jungle Island provides a great day out for any company or group. Our amazing animals, exciting exhibits and sensational shows make Jungle Island the perfect choice for a company picnic, large group outing or private daytime or evening event",
                Duration = 5,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Jungle Island",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\JIex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages2.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public static void SeedData4(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "Palms and Sun in Hawaii",
                City = "Honolulu",
                Country = "USA",
                Description = "Visiting the most interesting places of the island. Scenic panorama of Honolulu",
                Duration = 5,
                StartDate = new DateTime(2022, 6, 01),
                EndDate = new DateTime(2022, 6, 06),
                MaxTourists = 4,
                TourOperator = "SandAndWater",
                Price = 7600
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Waikiki Resort Hotel",
                City = "Honolulu",
                Description = "Reputable for its outstanding value and convenience in location, this 275 room hotel is ideally located just steps from famous Waikiki Beach and nearby dining and shopping. ",
                Country = "USA",
                Address = "2460 Koa Avenue, Honolulu, Oahu, HI 96815",
                Feeding = true,
                FreeRooms = 40,
                Rooms = 70,
                IsWifi = true,
                Mark = 4,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Wai.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Wai2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Wai3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Excursion around the island of Oahu.",
                Description = "Scenic panorama of Honolulu from Mount Tantalus; the crater of the Diamond Head volcano; area of ​​luxury houses Kahala. Hanauma Bay is a magnificent beach and a coral reef that stretches inside the crater, a real Halona ocean geyser and the beach From Here to Eternity.",
                Duration = 12,
                Language = "English",
                MaxAmountOfVisitors = 25,
                Place = "Around the island of Oahu",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\OHex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Excursion to Pearl Harbor",
                Description = "Visit the famous Pearl Harbor - the naval base where the US began the Second World War.",
                Duration = 6,
                Language = "English",
                MaxAmountOfVisitors = 12,
                Place = "Pearl Harbor",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\PHex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages2.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
        public static void SeedData5(GoodTripContext _dbContext)
        {
            Tour tour = new Tour()
            {
                Id = Guid.NewGuid(),
                Name = "On the land of Alaska",
                City = "Anchorage",
                Country = "USA",
                Description = "Anchorage - the main city of Alaska, commercial, transport and tourist center, where almost half of the total population of the state lives.",
                Duration = 7,
                StartDate = new DateTime(2022, 6, 03),
                EndDate = new DateTime(2022, 6, 10),
                MaxTourists = 8,
                TourOperator = "TravelAroundTheUS",
                Price = 4300
            };
            Hotel hotel = new Hotel()
            {
                Id = Guid.NewGuid(),
                Name = "Alex Hotel & Suites",
                City = "Anchorage",
                Description = "Alex Hotel & Suites features 123 oversized guest rooms with an excellent location.",
                Country = "USA",
                Address = "4615 Spenard Rd, Anchorage, AK 99517-3235",
                Feeding = false,
                FreeRooms = 15,
                Rooms = 32,
                IsWifi = false,
                Mark = 3,
                Tour = tour,
                TourId = tour.Id,
            };
            FileStream file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Alex.jpg", FileMode.Open);
            List<ImageHotel> hotelimages = new List<ImageHotel>();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Alex2.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\Alex3.jpg", FileMode.Open);
            ms = new MemoryStream();
            file.CopyTo(ms);
            hotelimages.Add(
                new ImageHotel() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Hotel = hotel, HotelId = hotel.Id }
            );
            hotel.Images = hotelimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Anchorage City Tour.",
                Description = "A sightseeing tour introduces the sights and history of Anchorage. A visit to the largest museum in Alaska, which introduces the history and sights of the state.* Overnight in Anchorage.",
                Duration = 5,
                Language = "English",
                MaxAmountOfVisitors = 15,
                Place = "Around the Anchorage",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\ANex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion, ExcurtionId = excurtion.Id }
            );
            excurtion.Images = excurtionimages;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            Excurtion excurtion2 = new Excurtion()
            {
                Id = Guid.NewGuid(),
                Name = "Moving to the Denali Reserve region",
                Description = "On the way - beautiful views of mountains, valleys, tundra, lakes. Visit the village of Wassila and the headquarters of the most famous dog sled race in Alaska - Iditarod. Overnight at a hotel in the Denali Wildlife Refuge.",
                Duration = 24,
                Language = "English",
                MaxAmountOfVisitors = 8,
                Place = "Denali",
                Tour = tour,
                TourId = tour.Id
            };
            file = new FileStream("C:\\Users\\Saimon\\goodtrip\\goodtrip\\Storage\\Images\\DENex.jpg", FileMode.Open);
            List<ImageExcurtion> excurtionimages2 = new List<ImageExcurtion>();
            ms = new MemoryStream();
            file.CopyTo(ms);
            excurtionimages2.Add(
                new ImageExcurtion() { Id = Guid.NewGuid(), ImageTitle = file.Name, ImageData = ms.ToArray(), Excurtion = excurtion2, ExcurtionId = excurtion2.Id }
            );
            excurtion2.Images = excurtionimages2;
            file.Close(); file.Dispose(); ms.Close(); ms.Dispose();
            tour.Hotel = hotel;
            tour.Excurtion = new List<Excurtion>();
            tour.Excurtion.Add(excurtion);
            tour.Excurtion.Add(excurtion2);
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }
    }
}
*/