using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScore : ControllerBase
    {
        // GET: api/<HighScore>
        [HttpGet]
        public int Get()
        {
            var tmp = new int();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                tmp = db.Questions.Count(x => x.Correct == true);
            }
            return tmp;
        }

        
    }
}
