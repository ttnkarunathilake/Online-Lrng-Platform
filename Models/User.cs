using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearningAPI.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
  
}
