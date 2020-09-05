using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Display(Name = "Course ID")]
        [Required(ErrorMessage = "The Course ID is required")]
        public int CourseID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "The Title is required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Credits")]
        [Required(ErrorMessage = "The Credits is required")]
        public int Credits { get; set; }

        public ICollection<CourseInstructorDTO> CourseInstructors { get; set; }
    }
}
