namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }

        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
