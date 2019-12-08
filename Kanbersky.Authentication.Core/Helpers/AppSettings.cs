using System.Diagnostics.CodeAnalysis;

namespace Kanbersky.Authentication.Core.Helpers
{
    [ExcludeFromCodeCoverage]
    public abstract class AppSettings
    {
        protected AppSettings(string secret)
        {
            Secret = secret;
        }

        public string Secret { get; }
    }
}
