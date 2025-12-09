using Application02.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application02.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SensorMessage> Sensors { get; set; }
}