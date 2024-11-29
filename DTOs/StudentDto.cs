using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.DTOs;

public class StudentDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public long CourseId { get; set; }
    public SelectList Courses { get; set; }
}