using Amore.Domain.Data.Provider;

namespace Amore.Data.Website.Provider
{
    public class ThatsAmoreSessionProvider : ISessionProvider
    {
        public void UpdateCurrentSession(string sessionId)
        {
            SessionId = sessionId;
        }

        public string GetCurrentSession()
        {
            return SessionId;
        }

        public bool HasCurrentSession()
        {
            return !string.IsNullOrWhiteSpace(SessionId);
        }

        public void ReleaseCurrentSession()
        {
            SessionId = string.Empty;
        }

        private string SessionId { get; set; } = string.Empty;
    }
}