using SocialMedia.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<IEnumerable<Post>> GetPostsByUserAsync(int userId);
    }
}
