using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_AspNet.Data;

public class ApplicationDbContext : IdentityDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
}