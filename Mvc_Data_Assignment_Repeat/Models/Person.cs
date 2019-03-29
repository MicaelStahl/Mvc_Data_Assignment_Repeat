using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
    }
}
