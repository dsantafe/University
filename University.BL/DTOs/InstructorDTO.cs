using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First MidName")]
        public string FirstMidName { get; set; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", LastName, FirstMidName);
            }
        }

        public ICollection<CourseInstructorDTO> CourseInstructors { get; set; }
        public OfficeAssignmentDTO OfficeAssignment { get; set; }
    }
}
