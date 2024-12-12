using System.ComponentModel.DataAnnotations;

namespace ProductApp.Entities;

public class Student
{
    public long Id { get; set; }

    [Required] [StringLength(64)] public required string Name { get; set; }

    [Required] [EmailAddress] public required string Email { get; set; }

    [Required] [StringLength(64)] public required string Address { get; set; }

    [Required(ErrorMessage = "Please select a course.")]
    public long CourseId { get; set; }

    public Course Course { get; set; }
}