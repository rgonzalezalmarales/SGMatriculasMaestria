using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<bool> DeletePostAsync(int id);
        Task<Post> GetPostAsync(int id);
        Task<IEnumerable<Post>> GetPostsAsync();
        Task InsertPostAsync(Post post);
        Task<bool> UpdatePostAsync(Post post);
    }
}
