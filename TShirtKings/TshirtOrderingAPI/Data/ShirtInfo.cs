using Microsoft.EntityFrameworkCore;
using TshirtOrderingAPI.Api.Models;

namespace TshirtOrderingAPI.Api.Data
{
    public class ShirtInfo : DbContext
    {
        public ShirtInfo(DbContextOptions<ShirtInfo> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
