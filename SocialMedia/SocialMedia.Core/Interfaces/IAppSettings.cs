using SocialMedia.Core.Options;

namespace SocialMedia.Core.Interfaces
{
    public interface IAppSettings
    {
        PaginationOptions PaginationOptions { get; set; }
    }
}