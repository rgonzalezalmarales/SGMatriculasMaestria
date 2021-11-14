using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Controllers.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        #region History [HttpGet]
        // (1) Get usando <Post> como objeto de transferencia
        //public async Task<IActionResult> Get()
        //{
        //    //var posts = await new ExampleRepository().GetPostsAsync();
        //    var posts = await _postRepository.GetPostsAsync();
        //    return Ok(posts);
        //}

        // (2) Get usando PostDto Linq mapping
        //public async Task<IActionResult> Get()
        //{
        //    var posts = await _postRepository.GetPostsAsync();
        //    var postsDto = posts.Select(x => new PostDto
        //    {
        //        PostId = x.PostId,
        //        UserId = x.UserId,
        //        Date = x.Date,
        //        Description = x.Description,
        //        Image = x.Image

        //    });
        //    return Ok(postsDto);
        //}
        // (3)
        //public async Task<IActionResult> Get()
        //{
        //    var posts = await _postRepository.GetPostsAsync();
        //    var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
        //    var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
        //    return Ok(response);
        //}
        #endregion

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetPostsAsync();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
            return Ok(response);
        }

        #region History Get [HttpGet("{id}")]
        // (1) Get usando <Post> como objeto de transferencia
        //public async Task<IActionResult> Get(int id)
        //{
        //    var post = await _postRepository.GetPostAsync(id);
        //    return Ok(post);
        //}

        // (2) Get usando PostDto Linq mapping
        //public async Task<IActionResult> Get(int id)
        //{
        //    var post = await _postRepository.GetPostAsync(id);
        //    var postDto = new PostDto
        //    {

        //        PostId = post.PostId,
        //        UserId = post.UserId,
        //        Date = post.Date,
        //        Description = post.Description,
        //        Image = post.Image

        //    };
        //    return Ok(postDto);
        //}
        // (3)
        //public async Task<IActionResult> Post(PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    await _postRepository.InsertPostAsync(post);
        //    postDto = _mapper.Map<PostDto>(post);

        //    var response = new ApiResponse<PostDto>(postDto);
        //    return Ok(response);
        //}
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetPostAsync(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        #region History Post [HttpPost]
        // (1) Get usando <Post> como objeto de transferencia
        //public async Task<IActionResult> Post(Post post)
        //{
        //    await _postRepository.InsertPostAsync(post);
        //    return Ok(post);
        //}

        // (2) Post usando PostDto mapping
        //public async Task<IActionResult> Post(PostDto postDto)
        //{
        //    var post = new Post
        //    {
        //        UserId = postDto.UserId,
        //        Date = postDto.Date,
        //        Description = postDto.Description,
        //        Image = postDto.Image
        //    };
        //    await _postRepository.InsertPostAsync(post);
        //    return Ok(post);
        //}
        // (3)
        //public async Task<IActionResult> Post(PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    await _postRepository.InsertPostAsync(post);
        //    postDto = _mapper.Map<PostDto>(post);

        //    var response = new ApiResponse<PostDto>(postDto);
        //    return Ok(response);
        //}
        #endregion

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postService.InsertPostAsync(post);
            postDto = _mapper.Map<PostDto>(post);

            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        #region History [HttpPut] and [HttpPut("{id}")]
        // (1)
        //[HttpPut]
        //public async Task<IActionResult> Put(int id, PostDto postDto)
        //{
        //    var post = _mapper.Map<Post>(postDto);
        //    post.PostId = id;
        //    var result = await _postRepository.UpdatePostAsync(post);

        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}
        //(2) Cambio de [HttpPut] a [HttpPut("{id}")]
        #endregion

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.PostId = id;
            var result = await _postService.UpdatePostAsync(post);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        #region History [HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _postRepository.DeletePostAsync(id);
        //    var response = new ApiResponse<bool>(result);
        //    return Ok(response);
        //}
        #endregion

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePostAsync(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
