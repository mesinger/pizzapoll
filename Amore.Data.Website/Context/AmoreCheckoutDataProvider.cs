namespace Amore.Data.Website.Context
{
    public class AmoreCheckoutDataProvider : IAmoreCheckoutDataProvider
    {
        public string AmoreSessionId { get; set; } = string.Empty;
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string HouseNumber { get; }
        public string Floor { get; }
        public string Door { get; }
        public string City { get; }
        public int Zip { get; }
        public int CountryId { get; }
        public int UseBilling { get; }
        public string SpecialInstructions { get; }
    }

    public interface IAmoreCheckoutDataProvider
    {
        string FirstName { get; }
        string LastName { get; }
        string Address { get; }
        string HouseNumber { get; }
        string Floor { get; }
        string Door { get; }
        string City { get; }
        int Zip { get; }
        int CountryId { get; }
        int UseBilling { get; }
        string SpecialInstructions { get; }
    }
}