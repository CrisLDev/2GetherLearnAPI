namespace _2GetherLearnAPI.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DatabaseName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
    }

    public interface IDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
