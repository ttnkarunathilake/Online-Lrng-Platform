using System;
using System.Collections.Generic;

namespace OnlineLearningAPI.Models;

public partial class StudentEnroll
{
    public string CourseId { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public DateOnly EnrollDate { get; set; }
}
