namespace Amore.Data.Models
{
    public class PizzasDatabaseSettings : IPizzasDatabaseSettings
    {
        public string PizzasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPizzasDatabaseSettings
    {
        string PizzasCollectionName { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}