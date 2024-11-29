namespace ProductApp.Entities;

public class StudentCourses
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }
}