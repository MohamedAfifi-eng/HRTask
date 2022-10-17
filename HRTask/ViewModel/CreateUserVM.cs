using HRTask.Models;
using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace HRTask.ViewModel
{
    public class CreateUserVM
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage ="You Should chose Group"),Display(Name ="Group")]
        public int GroupId_FK { get; set; }
    }
}
