using System;
using System.Collections.Generic;

namespace OnlineLearningAPI.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
