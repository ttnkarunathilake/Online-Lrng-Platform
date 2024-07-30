using System;
using System.Collections.Generic;

namespace OnlineLearningAPI.Models;

public partial class CourseEnroll
{
    public string CourseId { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public string Coordinator { get; set; } = null!;

    public string ContactNo { get; set; } = null!;
}
