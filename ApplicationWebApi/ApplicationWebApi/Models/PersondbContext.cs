using ApplicationWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWebApi.Data
{
    public class PersondbContext : DbContext
    {
        public PersondbContext()
        {
        }

        public PersondbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Persons> Persons { get; set; }



    }
}
