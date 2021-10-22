using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWebApi.Models
{

    public class Persons
    {
        [Key]
        public int Id { get; set; }
         public string Name { get; set; }
         public string LastName { get; set; }
         public long JMBG { get; set; }



    }
}
