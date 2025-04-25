namespace LMS.DTOs
{
    public class InstructorRegisterDto:RegisterModelDto
    {
        public string? Specialization { get; set; }
        public string? Skills { get; set; }
        public string? Experience { get; set; }
    }
}
