using System;
using System.Collections.Generic;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime HireDate { get; set; }

        public ICollection<CourseInstructorDTO> CourseInstructors { get; set; }
    }
}
