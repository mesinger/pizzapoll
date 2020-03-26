namespace Amore.Data.Settings
{
    public class MongoGoodieDatabaseSettings : IMongoGoodieDatabaseSettings
    {
        public string GoodiesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoGoodieDatabaseSettings
    {
        string GoodiesCollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}