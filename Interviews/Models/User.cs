using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interviews.Models;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Role {  get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
}
