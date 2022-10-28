using goodtrip.Storage;
using goodtrip.Storage.Entity;

namespace goodtrip
{
    public static class SeedData
    {
        public static void Seed(this GoodTripContext context)
        {

            context.Roles.Add(new UserRole() { Name = "Operator" });
            context.Roles.Add(new UserRole() { Name = "Customer" });
            context.UserOperatorProfiles.Add(new UserOperatorProfile
            {
                UserProfileId = Guid.Parse("416301BA-FECD-4486-9EE5-01A87995E719"),
                User = new User()
                {
                    Login = "danila",
                    Email = "danila@mail.com",
                    Password = "SuperDanila123$"
                }
            });


            context.Tours.Add(new Tour
            {
                Id = Guid.Parse("416901BA-FECD-4486-9EE5-01A87995E719"),
                Name = "Maiami Beaches",
                City = "Maiami",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Country = "USA",
                Description = "The luxury and glitz of the American oceanfront lifestyle",
                Duration = 8,
                Price = 3400,
                MaxTourists = 8,
                TourOperatorProfileId = Guid.Parse("416301BA-FECD-4486-9EE5-01A87995E719")
            });

            context.Hotels.Add(new Hotel
            {
                Id = Guid.Parse("CA9751D5-9F3E-4502-8233-007998F08F08"),
                Name = "TRUMP INTERNATIONAL BEACH RESORT",
                Description = "A modern oceanfront hotel in the Sunny Isles area. The hotel was built by the famous entrepreneur and millionaire Donald Trump and in 2008 became part of The Leading Hotels of the World.",
                Mark = 5,
                Country = "USA",
                City = "Miami",
                Address = "18001 Collins Ave, Miami Beach",
                Rooms = 50,
                FreeRooms = 32,
                IsWifi = true,
                Feeding = true,
                TourId = Guid.Parse("416901BA-FECD-4486-9EE5-01A87995E719"),
            });

            context.Excurtions.Add(new Excurtion
            {
                Id = Guid.Parse("A0B2E212-5423-423F-A5C2-6B469D539795"),
                Duration = 5,
                Place = "Jungle Island",
                MaxAmountOfVisitors = 25,
                Language = "English",
                Name = "Jungle Island",
                Description = "Jungle Island provides a great day out for any company or group. Our amazing animals, exciting exhibits and sensational shows make Jungle Island the perfect choice for a company picnic, large group outing or private daytime or evening event",
                TourId = Guid.Parse("416901BA-FECD-4486-9EE5-01A87995E719"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("C1DAAC29-EA5F-491E-A275-29341CCA3CD3"),
                ImageTitle = "Trump.jpg",
                ImageData = GetPhotoFromStorage("trump1.jpg"),
                HotelId = Guid.Parse("CA9751D5-9F3E-4502-8233-007998F08F08"),
            });;

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("494CF3CE-520A-426D-B361-65046062FA32"),
                ImageTitle = "Trump2.jpg",
                ImageData = GetPhotoFromStorage("trump2.jpg"),
                HotelId = Guid.Parse("CA9751D5-9F3E-4502-8233-007998F08F08"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("B22A3B79-F8E4-44E8-B50C-E4528671D090"),
                ImageTitle = "Trump3.jpg",
                ImageData = GetPhotoFromStorage("trump3.jpg"),
                HotelId = Guid.Parse("CA9751D5-9F3E-4502-8233-007998F08F08"),
            });

            context.ImagesExcurtion.Add(new ImageExcurtion
            {
                Id = Guid.Parse("30B19364-9983-4BF1-801C-AF78C0A221FC"),
                ImageTitle = "JIex.jpg",
                ImageData = GetPhotoFromStorage("excurtion1.jpg"),
                ExcurtionId = Guid.Parse("A0B2E212-5423-423F-A5C2-6B469D539795"),
            });

            ////

            context.Tours.Add(new Tour
            {
                Id = Guid.Parse("98952ADE-D461-45E3-AD79-BFE2460ADA37"),
                Name = "Excellent San-Francisco",
                City = "San-Francisco",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Country = "USA",
                Description = "San Francisco is famous for its Golden Gate Bridge, steep streets, Alcatraz, and – you got it, dude! – Full House. The thirteenth largest city in the United States also has some pretty interesting historical facts.",
                Duration = 8,
                Price = 3400,
                MaxTourists = 8,
                TourOperatorProfileId = Guid.Parse("416301BA-FECD-4486-9EE5-01A87995E719")

            });

            context.Hotels.Add(new Hotel
            {
                Id = Guid.Parse("9D852CDE-7F17-4013-979B-62E0D0F3D7A9"),
                Name = "Riu Plaza Fisherman's Wharf",
                Description = "A modern oceanfront hotel in the Sunny Isles area. The hotel was built by the famous entrepreneur and millionaire Donald Trump and in 2008 became part of The Leading Hotels of the World.",
                Mark = 5,
                Country = "USA",
                City = "Miami",
                Address = "18001 Collins Ave, Miami Beach",
                Rooms = 50,
                FreeRooms = 32,
                IsWifi = true,
                Feeding = true,
                TourId = Guid.Parse("98952ADE-D461-45E3-AD79-BFE2460ADA37"),
            });

            context.Excurtions.Add(new Excurtion
            {
                Id = Guid.Parse("E5E103F4-FA0C-44A8-A6A4-802678F4068B"),
                Duration = 5,
                Place = "Main attractions of San-Francisco",
                MaxAmountOfVisitors = 25,
                Language = "English",
                Name = "Main attractions of San-Francisco",
                Description = "Jungle Island provides a great day out for any company or group. Our amazing animals, exciting exhibits and sensational shows make Jungle Island the perfect choice for a company picnic, large group outing or private daytime or evening event",
                TourId = Guid.Parse("98952ADE-D461-45E3-AD79-BFE2460ADA37"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("DB1162C0-BFFA-4CE5-924E-3D0AE3FF398D"),
                ImageTitle = "Riu1.jpg",
                ImageData = GetPhotoFromStorage("riu1.jpg"),
                HotelId = Guid.Parse("9D852CDE-7F17-4013-979B-62E0D0F3D7A9"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("424CF3CE-590A-426D-B361-65046062FA31"),
                ImageTitle = "Riu2.jpg",
                ImageData = GetPhotoFromStorage("riu2.jpg"),
                HotelId = Guid.Parse("9D852CDE-7F17-4013-979B-62E0D0F3D7A9"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("B23A3B79-F8E4-44E7-B50C-E4528671D090"),
                ImageTitle = "Riu3.jpg",
                ImageData = GetPhotoFromStorage("riu3.jpg"),
                HotelId = Guid.Parse("9D852CDE-7F17-4013-979B-62E0D0F3D7A9"),
            });

            context.ImagesExcurtion.Add(new ImageExcurtion
            {
                Id = Guid.Parse("FA940EBB-2733-4B49-BFF2-142C88C743BB"),
                ImageTitle = "JIex.jpg",
                ImageData = GetPhotoFromStorage("excurtion2.jpg"),
                ExcurtionId = Guid.Parse("E5E103F4-FA0C-44A8-A6A4-802678F4068B"),
            });

            /////
            ///
            context.Tours.Add(new Tour
            {
                Id = Guid.Parse("694B87D5-F93D-4354-B27B-93E4E0FD8E67"),
                Name = "Amazing Orlando",
                City = "Orlando",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Country = "USA",
                Description = "Orlando, city, seat (1856) of Orange county, central Florida, U.S. It is situated in a region dotted by lakes, about 60 miles (95 km) northwest of Melbourne and 85 miles (135 km) northeast of Tampa. The city is the focus for one of the state's most populous metropolitan areas.",
                Duration = 8,
                Price = 3400,
                MaxTourists = 8,
                TourOperatorProfileId = Guid.Parse("416301BA-FECD-4486-9EE5-01A87995E719")
            });

            context.Hotels.Add(new Hotel
            {
                Id = Guid.Parse("2FD7FD63-1259-496D-8904-9A0A4720FEB8"),
                Name = "DoubleTree by Hilton at the Entrance to Universal Orlando",
                Description = "A modern oceanfront hotel in the Sunny Isles area. The hotel was built by the famous entrepreneur and millionaire Donald Trump and in 2008 became part of The Leading Hotels of the World.",
                Mark = 5,
                Country = "USA",
                City = "Miami",
                Address = "18001 Collins Ave, Miami Beach",
                Rooms = 50,
                FreeRooms = 32,
                IsWifi = true,
                Feeding = true,
                TourId = Guid.Parse("694B87D5-F93D-4354-B27B-93E4E0FD8E67"),
            });

            context.Excurtions.Add(new Excurtion
            {
                Id = Guid.Parse("7FD6D5DF-0765-4236-B389-E4FCC234C1D5"),
                Duration = 5,
                Place = "Orlando's best parks",
                MaxAmountOfVisitors = 25,
                Language = "English",
                Name = "Orlando's best parks",
                Description = "Jungle Island provides a great day out for any company or group. Our amazing animals, exciting exhibits and sensational shows make Jungle Island the perfect choice for a company picnic, large group outing or private daytime or evening event",
                TourId = Guid.Parse("694B87D5-F93D-4354-B27B-93E4E0FD8E67"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("4AFB8267-F775-43DA-B209-2E969184E4D6"),
                ImageTitle = "Trump.jpg",
                ImageData = GetPhotoFromStorage("doubltree1.jpg"),
                HotelId = Guid.Parse("2FD7FD63-1259-496D-8904-9A0A4720FEB8"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("464CF3CE-590A-426D-B361-65046062FA33"),
                ImageTitle = "Trump2.jpg",
                ImageData = GetPhotoFromStorage("doubltree2.jpg"),
                HotelId = Guid.Parse("2FD7FD63-1259-496D-8904-9A0A4720FEB8"),
            });

            context.ImagesHotel.Add(new ImageHotel
            {
                Id = Guid.Parse("B92A3B79-F8E4-44E7-B50C-E4528671D090"),
                ImageTitle = "Trump3.jpg",
                ImageData = GetPhotoFromStorage("doubletree3.jpg"),
                HotelId = Guid.Parse("2FD7FD63-1259-496D-8904-9A0A4720FEB8"),
            });

            context.ImagesExcurtion.Add(new ImageExcurtion
            {
                Id = Guid.Parse("DAA4154F-323D-4206-B8B7-7F9B0607202C"),
                ImageTitle = "JIex.jpg",
                ImageData = GetPhotoFromStorage("excurtion3.jpg"),
                ExcurtionId = Guid.Parse("7FD6D5DF-0765-4236-B389-E4FCC234C1D5"),
            });

            context.SaveChanges();
        }
        public static byte[] GetPhotoFromStorage(string imageName)
        {
            byte[] bytes = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images_for_default_tours", imageName));
            return bytes;
        }
    }
}
