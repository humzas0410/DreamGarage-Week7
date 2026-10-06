using Microsoft.EntityFrameworkCore;
using DreamGarage.Models;

namespace DreamGarage.Data;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions<CarContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
}