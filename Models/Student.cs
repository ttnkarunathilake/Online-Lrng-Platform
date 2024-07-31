using System;
using System.Collections.Generic;

namespace OnlineLearningAPI.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Nic { get; set; } = null!;

    public DateTime RegisterDate { get; set; }
}
