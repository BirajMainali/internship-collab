﻿namespace ProductApp.Entities;

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public long CourseId { get; set; }
    public Course Course { get; set; }
}