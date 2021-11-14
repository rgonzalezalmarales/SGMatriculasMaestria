using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _postRepository.GetPostsAsync();
            return posts;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _postRepository.GetPostAsync(id);
        }

        #region History Insert Method
        // (1) Sin lógica de negocio
        //public async Task InsertPostAsync(Post post)
        //{
        //    await _postRepository.InsertPostAsync(post);
        //}
        #endregion
        public async Task InsertPostAsync(Post post)
        {
            var user = await _userRepository.GetUserAsync(post.UserId);
            if (user == null)
                throw new Exception("User doesn't exist");

            if (post.Description.ToLower().Contains("sexo"))
                throw new Exception("Content not allowed");

            await _postRepository.InsertPostAsync(post);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var result = await _postRepository.UpdatePostAsync(post);
            return result;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var result = await _postRepository.DeletePostAsync(id);

            return result;
        }

    }
}
