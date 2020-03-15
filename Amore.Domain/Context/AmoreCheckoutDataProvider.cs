namespace Amore.Domain.Context
{
    public class AmoreCheckoutDataProvider : IAmoreCheckoutDataProvider
    {
        public string AmoreSessionId { get; set; } = string.Empty;
        public string FirstName { get; set; }
    }

    public interface IAmoreCheckoutDataProvider
    {
        string AmoreSessionId { get; set; }
        string FirstName { get; }

        bool HasCurrentSession()
        {
            return !string.IsNullOrWhiteSpace(AmoreSessionId);
        }
    }
}