using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveCollegeProject.Models
{
    public class Student
    {
      
        [Display(Name = "Student Number")]
        
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }


        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [StringLength(16, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName+ ", " + LastName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}