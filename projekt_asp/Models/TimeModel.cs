using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt_asp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projekt_asp.Models
{
    public class TimeModel
    {
        [Key]
        public int TimeId { get; set; }
        public DateTime Date { get; set; }

        public int Hours_worked { get; set; }
       
        public RegisterModel RegisterModel  { get; set; }
    }

}
