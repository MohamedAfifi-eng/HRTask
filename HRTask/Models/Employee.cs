using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace HRTask.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "إسم الموظف")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(maximumLength:50,MinimumLength =3,ErrorMessage ="إسم الموظف ينبغي ان لا يقل عن 3 حروف و لا يزيد عن 50 حرف")]
        public string Name { get; set; }

        [Display(Name="العنوان")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "يجب إدخال عنوان الموظف و ان لا يقل عن 3 حروف و لا يزيد عن 50 حرف")]
        public string Address { get; set; }

        [Display(Name ="رقم التليفون"),
         Required(ErrorMessage = "هذا الحقل مطلوب "),
          DataType(DataType.PhoneNumber),
          StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "رجاء إدخال رقم تليفون صحيح"),
          RegularExpression("^[0-9]+$",ErrorMessage ="رجاء إدخال رقم تليفون صحيح")
            ]
        public string ContactNumber { get; set; }

        [Display(Name = "تاريخ الميلاد")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "النوع")]
        public bool Gender { get; set; }

        [Display(Name = "الجنسية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(maximumLength:30,MinimumLength =3)]
        public string Nationality { get; set; }

        [Display(Name = "الرقم القومي")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public string NationalId { get; set; }

        [Display(Name = "تاريخ التعاقد")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [DataType(DataType.Date)]
        public DateTime DateOfContract { get; set; }


        [Display(Name = "الراتب")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }


        [Display(Name = "موعد الحضور")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [Display(Name = "موعد الانصراف")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }

        [Display(Name = "ملاحظات ")]
        [MaxLength(250)]
        public string? Notes { get; set; }

    }
}
