using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.ViewModels;

public class StudentVm
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }

    [Required(ErrorMessage = "Please select a course.")]
    public long CourseId { get; set; }

    public SelectList Courses { get; set; }
}