using _2GetherLearnAPI.Models;
using _2GetherLearnAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace _2GetherLearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPosts()
        {
            var result = await _postService.GetPostsAsync();
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}", Name = "GetPost")]
        public async Task<ActionResult> GetPost(string id)
        {
            var result = await _postService.GetPostAsync(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] Post post)
        {
            var result = await _postService.CreatePostAsync(post);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(string id, [FromBody] Post postIn)
        {
            var result = await _postService.UpdatePostAsync(id, postIn);
            if(result != null)
            { 
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(string id)
        {
            await _postService.RemovePostAsync(id);
            return Ok();
        }
    }
}
