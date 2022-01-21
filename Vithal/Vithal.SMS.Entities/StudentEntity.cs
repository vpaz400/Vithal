using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Vithal.Framework.Core;

namespace Vithal.SMS.Models
{
    [Table("Student")]
    [ExcludeFromCodeCoverage]
    public class StudentEntity : BaseEntity
    {
        [Required(ErrorMessage = "Student first name is required!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Student first name should be between 3 and 150 characters!")]
        public string FirstName { get; set; }
        [StringLength(150)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Student last name is required!")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Student last name should be between 3 and 150 characters!")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Joining date is required!")]
        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }
        
        public virtual ICollection<CourseEntity> Courses { get; set; }
    }
}
