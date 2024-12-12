using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.ViewModels;

public class StudentVm
{
    public long Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public string Address { get; set; }

    [Required(ErrorMessage = "Please select a course.")]
    public long CourseId { get; set; }

    public List<SelectListItem> Courses { get; set; } = [];
}