using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Data;
using System;
using YourApp.Data;

namespace ReactApp1.Server.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Clubs.Any()) return; // DB already seeded

            context.Clubs.AddRange(
                new Club
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Rhythm Lounge",
                    Description = "An electrifying EDM party spot.",
                    Address = "123 Night Ave, Party City",
                    Latitude = 40.7128,
                    Longitude = -74.0060,
                    ActiveParty = true,
                    Rating = 4.8,
                    OpeningHours = "10 PM - 4 AM",
                    MusicGenres = new List<string> { "EDM", "House", "Trance" },
                    PartyType = "EDM",
                    Image = null
                },
                new Club
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Jazz Central",
                    Description = "Live music every weekend.",
                    Address = "456 Smooth St, Jazzville",
                    Latitude = 34.0522,
                    Longitude = -118.2437,
                    ActiveParty = false,
                    Rating = 4.3,
                    OpeningHours = "6 PM - 1 AM",
                    MusicGenres = new List<string> { "Jazz", "Soul" },
                    PartyType = "Live Music",
                    Image = null
                }
            );

            context.SaveChanges();
        }
    }
}
