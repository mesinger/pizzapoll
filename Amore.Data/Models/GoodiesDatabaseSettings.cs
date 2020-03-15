namespace Amore.Data.Models
{
    public class GoodiesDatabaseSettings : IGoodiesDatabaseSettings
    {
        public string GoodiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGoodiesDatabaseSettings
    {
        string GoodiesCollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}