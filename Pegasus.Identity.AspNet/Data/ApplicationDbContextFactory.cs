using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pegasus.Identity.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlite("Data Source=../Pegasus.Web/app.db",
            builder => builder.MigrationsAssembly("Pegasus.Identity"));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}