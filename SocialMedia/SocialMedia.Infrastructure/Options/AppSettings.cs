using Microsoft.Extensions.Options;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Options;

namespace SocialMedia.Infrastructure.Options
{
    public class AppSettings : IAppSettings
    {
        public PaginationOptions PaginationOptions { get; set; }
        public AppSettings(IOptions<PaginationOptions> optionsPg)
        {
            PaginationOptions = optionsPg.Value;
        }
    }
}
