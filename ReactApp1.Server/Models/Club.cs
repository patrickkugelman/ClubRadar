namespace YourApp.Models
{
    public class Club
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool ActiveParty { get; set; }
        public double Rating { get; set; }
        public string OpeningHours { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<string> MusicGenres { get; set; } = new();
        public string PartyType { get; set; } = "Regular";
    }
}
