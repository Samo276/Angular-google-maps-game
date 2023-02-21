using gAPI.Database;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterPackage : ControllerBase
    {
        // GET: api/<MasterPackage>
        [HttpGet]
        public MasterPack[] Get(double cuLon, double cuLat)
        {
            var Package = new MasterPack();

            var tmp = new List<QuestItem>();
            var closest = new QuestItem();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                tmp = db.Questions.Where(x => x.IsDone == false).ToList();
                closest = tmp.First();

                foreach (var item in tmp)
                {
                    if (
                        ((item.lat - cuLat) * (item.lat - cuLat) + (item.lon - cuLon) * (item.lon - cuLon))
                        <=
                        ((closest.lat - cuLat) * (closest.lat - cuLat) + (closest.lon - cuLon) * (closest.lon - cuLon))
                        )
                    {
                        closest = item;
                    }
                }
            }
            closest.Range = ((closest.lat - cuLat) * (closest.lat - cuLat) + (closest.lon - cuLon) * (closest.lon - cuLon));
            Package.ClosestItem = closest;

            var tmp2 = new List<QuestItem>();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                tmp2 = db.Questions.Where(x => x.IsDone == false).ToList();
            }
            Package.QuestItems = tmp2.ToArray();

            var tmp3 = new int();
            using (var db = new gAPI.Database.GAPI_DbContext())
            {
                tmp3 = db.Questions.Count(x => x.Correct == true);
            }
            Package.Score = tmp3;
            var tmp4 = new List<MasterPack>();
            tmp4.Add(Package);
            return tmp4.ToArray();

        }

        
    }
}
