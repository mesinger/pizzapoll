namespace Amore.Data.Settings
{
    public class MongoPizzaOrderDatabaseSettings : IMongoPizzaOrderDatabaseSettings
    {
        public string PizzaOrdersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoPizzaOrderDatabaseSettings
    {
        string PizzaOrdersCollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}