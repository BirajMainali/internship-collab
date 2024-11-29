namespace ProductApp.Entities;

public class Course
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }
}