using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetClosest : ControllerBase
    {


        // GET api/<GetClosest>/5
        [HttpGet]
        public QuestItem[] Get(double cuLon, double cuLat)
        {
            var tmp = new List<QuestItem>();
            var closest= new QuestItem();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                tmp = db.Questions.Where(x => x.IsDone == false).ToList();
                closest =tmp.First();

                foreach (var item in tmp)
                {
                    if(
                        ((item.lat-cuLat)*(item.lat - cuLat)+(item.lon-cuLon)*(item.lon - cuLon) )
                        <=
                        ((closest.lat - cuLat) * (closest.lat - cuLat) + (closest.lon - cuLon) * (closest.lon - cuLon))
                        ) 
                    {
                        closest = item;
                    }
                }                
            }
            closest.Range = ((closest.lat - cuLat) * (closest.lat - cuLat) + (closest.lon - cuLon) * (closest.lon - cuLon));
            var result = new List<QuestItem>() { closest};
            return result.ToArray();
            //return closest;
        }

        
    }
}
