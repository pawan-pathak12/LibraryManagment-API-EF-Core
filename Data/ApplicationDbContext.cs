using Library_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {
            
        }
    public    DbSet<AppUser> Users { get; set; }
    }
}
