using System;
using System.Collections.Generic;

namespace App.Users.Data.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
