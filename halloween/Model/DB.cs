using System;
using Microsoft.EntityFrameworkCore;

namespace halloween.Model
{
    public class DB : DbContext
    {
        //DEFAULT CONSTRUCTOR
        public DB() { }

        //CONSTRUCTOR
        public DB(DbContextOptions<DB> options) : base(options) { }

        //CREATE A DB FOR EACH EXISTING MODEL(S)
        public DbSet<Greetings> Greetings { get; set; }
    }
}
