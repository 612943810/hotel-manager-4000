using Hotel_Manager_4000.Repository;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Hotel_Manager_4000.Models;
    public class User:IdentityUser
    {
    [Key]
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    }

