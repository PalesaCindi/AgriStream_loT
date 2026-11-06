using Microsoft.EntityFrameworkCore;

namespace AgriStream_loT.Data
{
    public class AgriStream_loTContext : DbContext
    {
        public AgriStream_loTContext(DbContextOptions<AgriStream_loTContext> options) : base(options)
        {
        }

        public DbSet<Models.farmer> Farmers { get; set; }
    }
}
