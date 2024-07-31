using System;
using System.Collections.Generic;

namespace OnlineLearningAPI.Models;

public partial class Course
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Duration { get; set; }

    public decimal Fees { get; set; }

    public int MaxCount { get; set; }

    public string Status { get; set; } = null!;
}
