using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Shared
{
    public class  Person
    {
        [Required(ErrorMessage ="Firstname must not be empty")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname must not be empty")]
        public string Lastname { get; set; }
        [Required]
        [Range(18,99,ErrorMessage ="Age must be between 18 and 99 years old.")]
        public int Age { get; set; }
    }
}
