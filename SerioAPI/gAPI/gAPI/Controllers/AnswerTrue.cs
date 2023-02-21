using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerTrue : ControllerBase
    {
        // GET: api/<AnswerTrue>
        [HttpGet]
        public bool Get(int id)
        {
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                try
                {
                    var tmp = db.Questions.First(x => x.Id == id);

                    tmp.IsDone = true;
                    if (tmp.Answer)
                    {
                        tmp.Correct = true;
                    }
                    else
                    {
                        tmp.Correct = false;
                    }

                    db.SaveChanges();
                }
                catch { }
            }
            return true;
        }

        
    }
}
