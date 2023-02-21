using Microsoft.AspNetCore.Mvc;

namespace gAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestsController : ControllerBase
    {


        [HttpGet(Name = "GetQuestItems")]
        public IEnumerable<QuestItem> Get()
        {
            var tmp = new List<QuestItem>();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                tmp = db.Questions.Where(x => x.IsDone == false).ToList();
            }
            return tmp.ToArray();
        }
        [HttpPost()]
        public void Post(IPost pp)
        {
            
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                try { 
                var tmp = db.Questions.First(x => x.Id == pp.id);
                
                tmp.IsDone = true;
                if (tmp.Answer == pp.answer)
                    {
                    tmp.Correct=true;
                }
                else { 
                    tmp.Correct=false; 
                }
                
                //db.Questions.Add(tmp);
                
                db.SaveChanges();
                }
                catch{ }
            }
        }

    }
    public class IPost
    {
        public int id { get; set; }
        public bool answer { get; set; }
    } 
}