using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task<bool> DeletePostAsync(int id);
        Task<Post> GetPostAsync(int id);
        PagedList<Post> GetPosts(PostQueryFilter filters);
        Task InsertPostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
    }
}