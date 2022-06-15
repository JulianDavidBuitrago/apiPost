using apiPost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiPost.Controllers
{

    [Route("api/")]
    [ApiController]

    public class PostController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public PostController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("post")]
        public async Task<ActionResult<List<Post>>> Get()
        {
            return await context.Posts.ToListAsync();
        }

        [HttpPost("post/crear")]
        public async Task<ActionResult> Post(Post post)
        {
            context.Add(post);
            await context.SaveChangesAsync();
            return Ok();
        }

        
        [HttpDelete("post/{id}")]
        public async Task<ActionResult<Post>> Delete(int id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
           context.Posts.Remove(post);
            await context.SaveChangesAsync();
           return post;
        }
        
        private bool PostExists(int id)
        {
            return context.Posts.Any(e => e.Id == id);
        }

        // DELETE: api/CARegistroPersonas/5
        //[HttpDelete("api/registro/{id}")]
        //public async Task<ActionResult<CARegistroPersonas>> DeleteCARegistroPersonas(long id)
        //{
        //    var cARegistroPersonas = await _context.CARegistroPersonas.FindAsync(id);
        //    if (cARegistroPersonas == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CARegistroPersonas.Remove(cARegistroPersonas);
        //    await _context.SaveChangesAsync();

        //    return cARegistroPersonas;
        //}

        //private bool CARegistroPersonasExists(long id)
        //{
        //    return _context.CARegistroPersonas.Any(e => e.Id == id);
        //}

    }
}