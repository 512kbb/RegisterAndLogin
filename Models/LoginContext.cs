using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegisterAndLogin.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}