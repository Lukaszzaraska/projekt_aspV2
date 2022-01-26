using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projekt_asp.Models
{
    public class RegisterModel
    {

        public RegisterModel()
        {
            TimeModels = new HashSet<TimeModel>();
        }
        [HiddenInput]
        [Key]
        public string UserId { get; set; }
        public Position position { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(20)]
        public string Login { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(5, ErrorMessage = "Your password is too short")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Please provide the correct eamil!")]
        public string Email { get; set; }


        public enum Position
        {
            [Display(Name = "Employee")] Low = 1,
            [Display(Name = "Office_worker")] Normal = 2,
            [Display(Name = "Employee It")] High = 3,
            [Display(Name = "Boss")] God = 4

        }
      
        public ICollection<TimeModel> TimeModels { get; set; }
        public ICollection<MsgModel> MsgModels { get; set; }

    }
}
