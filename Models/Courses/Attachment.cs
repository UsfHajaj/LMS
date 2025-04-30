namespace LMS.Models.Courses
{
    public class Attachment
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
