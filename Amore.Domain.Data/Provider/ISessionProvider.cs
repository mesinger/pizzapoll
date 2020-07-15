using System;

namespace Amore.Domain.Data.Provider
{
    public interface ISessionProvider
    {
        void UpdateCurrentSession(string sessionId);
        string GetCurrentSession();
        bool HasCurrentSession();
        void ReleaseCurrentSession();
    }
}