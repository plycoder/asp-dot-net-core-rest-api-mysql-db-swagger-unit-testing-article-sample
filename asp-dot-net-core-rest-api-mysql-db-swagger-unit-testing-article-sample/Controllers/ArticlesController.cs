using System.Threading.Tasks;
using ArticleSampleAPI.Data;
using ArticleSampleAPI.Services;
using ArticleSampleAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArticleSampleAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET api/article
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _articleService.GetAllAsync();

            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
           
        }

        // POST api/article
        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] Articles body)
        {
            await _articleService.SaveAsync(body);
            return Ok();
        }

        // GET api/article/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _articleService.GetOne(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // PUT api/article/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Articles body)
        {
            var result = await _articleService.GetOne(id);
            if (result is null)
                return new NotFoundResult();
            result.Name = body.Name;
            result.Authors = body.Authors;
            await _articleService.PutOne(result);
            return new OkResult();
        }

        // DELETE api/article/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var result = await _articleService.GetOne(id);
            if (result is null)
                return new NotFoundResult();
            await _articleService.DeleteOne(result);
            return new OkResult();
        }

    }
}