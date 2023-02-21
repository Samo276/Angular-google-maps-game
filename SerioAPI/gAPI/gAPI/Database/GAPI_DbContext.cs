

using System.Data.Entity;

namespace gAPI.Database
{
    public class GAPI_DbContext : DbContext
    {
        public DbSet<QuestItem>  Questions { get;set; }

        public GAPI_DbContext(){}
    
    }
}
