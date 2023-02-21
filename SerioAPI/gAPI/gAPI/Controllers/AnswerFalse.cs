using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerFalse : ControllerBase
    {
        // GET: api/<AnswerFalse>
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
                        tmp.Correct = false;
                    }
                    else
                    {
                        tmp.Correct = true;
                    }

                    db.SaveChanges();
                }
                catch { }
            }
            return true;
        }
    }
}
