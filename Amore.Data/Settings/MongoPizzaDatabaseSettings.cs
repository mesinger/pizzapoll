namespace Amore.Data.Settings
{
    public class MongoPizzaDatabaseSettings : IMongoPizzaDatabaseSettings
    {
        public string PizzasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoPizzaDatabaseSettings
    {
        string PizzasCollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}