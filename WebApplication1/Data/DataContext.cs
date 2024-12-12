using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
namespace Api.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<AppUser> Users { get; set; } //EF is convention based so the table in the DB is also going to have the same name.

}
