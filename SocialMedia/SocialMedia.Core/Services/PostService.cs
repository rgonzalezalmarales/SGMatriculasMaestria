using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Options;
using SocialMedia.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppSettings _settings;
        private readonly TestConfigOptions _testConfigOptions;

        public PostService(IUnitOfWork unitOfWork, IAppSettings settings, TestConfigOptions testConfigOptions)
        {
            _unitOfWork = unitOfWork;
            _settings = settings;
            _testConfigOptions = testConfigOptions;
        }

        public PagedList<Post> GetPosts(PostQueryFilter filters)
        {
            var fecha = _testConfigOptions.Fecha;
            filters.PageNumber = filters.PageNumber == 0 ? _settings.PaginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _settings.PaginationOptions.DefaultPageSize : filters.PageSize;

            var posts = _unitOfWork.PostRepository.GetAll();
            if (filters.userId != null)
                posts = posts.Where(p => p.UserId == filters.userId);
            if (filters.Date != null)
                posts = posts.Where(p => p.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            if (filters.Description != null)
                posts = posts.Where(p => p.Description.ToLower().Contains(filters.Description.ToLower()));

            var type = posts.GetType().ToString();
            //var intnull = int.Parse(null);

            var pagedPosts = PagedList<Post>.Create(posts, filters.PageNumber, filters.PageSize);
            //Mi clase
            //var pagedPosts1 = new CustomPagedList<Post>(posts, filters.PageNumber, filters.PageSize);
            
            //posts = posts.ToList();
            return pagedPosts;
        }

        public async Task<Post> GetPostAsync(int id)
        {
            return await _unitOfWork.PostRepository.GetByIdAsync(id);
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
            var user = await _unitOfWork.UserRepository.GetByIdAsync(post.UserId);
            if (user == null)
                throw new BusinessException("User doesn't exist");

            if (post.Description.ToLower().Contains("sexo"))
                throw new BusinessException("Content not allowed");

            var postsUser = await _unitOfWork.PostRepository.GetPostsByUserAsync(post.UserId);
            if(postsUser.Count() <= 10)
            {
                var lastpost = postsUser.OrderByDescending(x => x.Date).FirstOrDefault();
                if (lastpost != null && (DateTime.Now - lastpost.Date).TotalDays <= 7)
                    throw new BusinessException("You are not able tu publish the post");
            }           

            await _unitOfWork.PostRepository.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var existingPost = await _unitOfWork.PostRepository.GetByIdAsync(post.Id);
            //Esto lo adicioné porque en una prueba envie un id inexistente y dio error.
            if (existingPost == null)
                throw new BusinessException ("Post doesn't exist");

            //Solo los datos que tienen logica de actualizar
            existingPost.Description = post.Description;
            existingPost.Image = post.Image;

            _unitOfWork.PostRepository.Update(existingPost);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(id);
            if(post == null)
                throw new BusinessException("Post doesn't exist");
            //Hice una comparacion en cuanto a velocidad en cuanto a las dos variantes arojando el siguiente resultado:
            //Metodo Remove promedio -> 27.8 ms
            //Metodo DeleteAsync promedio -> 43.3 ms
            //remove es 1.6 veces más rápido, según mi criterio porque no vuelve a llamar al metodo _unitOfWork.PostRepository.GetByIdAsync
            // mientras que DeleteAsync si.
            if (true)
            {
                //Ramiro
                _unitOfWork.PostRepository.Remove(post);
            }
            else
            {
                //profe
                await _unitOfWork.PostRepository.DeleteAsync(id);
            }

            
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
