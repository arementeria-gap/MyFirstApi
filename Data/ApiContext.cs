using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}