using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Enumerations;
using System;

namespace SocialMedia.Infrastructure.Interfaces
{
    public interface IUriService
    {
        /*Uri GetPostPaginationNextUrl(PostQueryFilter filters, string actionUrl);
        Uri GetPostPaginationPreviousUrl(PostQueryFilter filters, string actionUrl);
        Uri GetPostPaginationUrl(PostQueryFilter filters, string actionUrl);*/
        Uri GetPostPaginationUrl(PostQueryFilter filters, string actionUrl, PaginationDirection direction = PaginationDirection.Next);
    }
}