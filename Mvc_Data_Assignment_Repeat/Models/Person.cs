using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment_Repeat.Models
{
    public class Person
    {
        /// <summary>
        /// This Model is the blueprint of a person.
        /// The [Required] means that line is required to have a value
        /// otherwise the ModelState will be false.
        /// </summary>

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
    }
}
