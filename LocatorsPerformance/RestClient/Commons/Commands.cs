using System.Diagnostics.CodeAnalysis;

namespace Hackpro.LocatorsPerformance.RestClient.Commons
{
    [ExcludeFromCodeCoverage]
    public static class Commands
    {
        public const string ID_SESSION = "{IdSession}";
        public const string NEW_SESSION = "session";
        public const string DELETE_SESSION = "session/" + ID_SESSION;
    }
}
