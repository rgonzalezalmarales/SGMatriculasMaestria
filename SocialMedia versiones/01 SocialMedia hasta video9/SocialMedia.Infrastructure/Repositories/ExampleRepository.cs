using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class ExampleRepository : IPostRepository
    {
        public Task<bool> DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = Enumerable.Range(0, 10).Select(x => new Post
            {
                PostId = x,
                UserId = x * 2,
                Description = $"Descripción {x}",
                Date = DateTime.Now,
                Image = $"https://misapis.com/{x}",
                
            });
            await Task.Delay(10);
            return posts;
        }

        public Task InsertPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Post>> GetPostsAsync()
        //{
        //    var posts = Enumerable.Range(0, 10).Select(x => new Post 
        //    {
        //        PostId = x,
        //        UserId = x * 2,
        //        Description = $"Description {x}",
        //        Date = DateTime.Now,
        //        Image = $"https://misapis.com/{x}"
        //    });
        //    await Task.Delay(10);
        //    return posts;
        //}
    }
}
