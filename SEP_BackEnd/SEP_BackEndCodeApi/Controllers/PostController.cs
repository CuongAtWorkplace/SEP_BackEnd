using BussinessObject.Models;
using DataAccess.Repositories.IReporitory;
using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IConfiguration _config;
        private readonly DB_SEP490Context _db;
        private readonly IPostRepository post;
       

        public PostController(IPostRepository _post, IConfiguration config, DB_SEP490Context db)
        {
            _config = config;
            _db = db;
            post = _post;
        }

        [HttpGet]
        public IActionResult GetAllPost()
        {
            var list = post.GetPostList();
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetPostByName(string PostName)
        {
            try
            {
                var Course = post.getPostByName(PostName);
                return Ok(Course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetPostById(int Id) { 
            try
            {
                Post post1 = post.getPostById(Id);
                return Ok(post1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetPostListActive()
        {
            try
            {
                var post1 = post.GetPostListActive();
                return Ok(post1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdatePost(Post postU)
        {
            try
            {
                post.Update(postU);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdatePostActive(Post postU)
        {
            try
            {
                post.UpdatePostActive(postU);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult AddNewPost(Post postadd)
        {
            try
            {
                post.AddNewPost(postadd);   
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                // Check if a file was uploaded
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // Get the original file name from the uploaded file
                var originalFileName = DateTime.UtcNow.Ticks;

                // Construct the full path to save the image with the original file name
                var imagePath = Path.Combine(@"C:\Users\ngoba\OneDrive\Máy tính\SEP_BackEnd\SEP_BackEnd\SEP_BackEndCodeApi\Photos\", $"{originalFileName}.jpg");

                // Save the image with the original file name
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Now you can use 'originalFileName' in your application if needed

                return Ok(originalFileName+".jpg");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
