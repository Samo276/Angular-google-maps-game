using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Markers : ControllerBase
    {        
        // GET: api/<VisitedMarkers>
        [HttpGet]
        public IEnumerable<Marker> Get()
        {
            var tmp = new List<Marker>();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                foreach (var item in db.Questions.ToList())
                    tmp.Add(new Marker {lon=item.lon, lat=item.lat});              
            }
            return tmp;
        }
        [HttpPost]
        public void Post()
        {
            /*
            var x = new QuestItem { lat = 49.8121157, lon = 19.041796, Id = 0, Question = "2+2=4", Answer = true, IsDone = false, Correct=false, Range=2 };
            var y = new QuestItem { lat = 49.803875, lon = 19.0559279, Id = 1, Question = "2+2=6", Answer = false, IsDone = false, Correct = false, Range = 2 };
            var z = new QuestItem { lat = 49.803875, lon = 19.0559279, Id = 2, Question = "2+2=6", Answer = false, IsDone = true, Correct = true, Range = 2 };
            using(var db = new gAPI.Database.GAPI_DbContext())
            {
                db.Questions.Add(x);
                db.Questions.Add(y);
                db.Questions.Add(z);
                db.SaveChanges();
            }
            */
        }
    }
}
