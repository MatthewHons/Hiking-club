using Microsoft.EntityFrameworkCore;

namespace HikingProject.Models
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }

        //protected DefaultContext()
        //{

        //}

        #region Properties

        public DbSet<Hikes> Hike { get; set; }
        #endregion
    }
}
