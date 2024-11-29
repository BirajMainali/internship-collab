namespace ProductApp.Entities;

public class StudentCourse
{
    public long Id { get; set; }

    public long StudentId { get; set; }
    public Student Student { get; set; }

    public long CourseId { get; set; }
    public Course Course { get; set; }
}