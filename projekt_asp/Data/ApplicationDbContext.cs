using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace projekt_asp.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }


        public DbSet<RegisterModel> Users { get; set; }
        public DbSet<MsgModel> User_Msg { get; set; }
        public DbSet<TimeModel> Times { get; set; }

    }
}