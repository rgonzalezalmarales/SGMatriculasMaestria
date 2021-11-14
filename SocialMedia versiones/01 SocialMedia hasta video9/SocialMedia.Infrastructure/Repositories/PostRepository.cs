using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
        }

        public async Task InsertPostAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var currentPost = await GetPostAsync(post.PostId);
            currentPost.Description = post.Description;
            currentPost.Date = post.Date;
            currentPost.Image = post.Image;

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var currentPost = await GetPostAsync(id);
            _context.Posts.Remove(currentPost);
            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
