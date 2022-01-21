using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Vithal.Framework.Core;

namespace Vithal.SMS.Models
{
    [Table("Course")]
    [ExcludeFromCodeCoverage]
    public class CourseEntity : BaseEntity
    {
        [Required(ErrorMessage = "Course Number is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Course number must be between 3 and 250 characters!")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Course Name is required!")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Course name must be between 3 and 250 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course Description is required!")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Course description must be between 10 and 1000 characters!")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Course start date is required!")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
    }
}
