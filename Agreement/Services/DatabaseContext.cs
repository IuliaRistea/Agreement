using Agreement.Models;
using Microsoft.EntityFrameworkCore;

namespace Agreement.Services
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        public virtual  DbSet<AgreementModel> Agreements { get; set; }
        public virtual DbSet<ErrorModel> Errors { get; set; }
    }

}
