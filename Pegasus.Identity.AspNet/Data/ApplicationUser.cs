using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Pegasus.Identity.Data;

public class ApplicationUser : IdentityUser {
    [MaxLength(256)]
    [MinLength(3)]
    [Display(Name = "Display Name")]
    public string? DisplayName { get; set; }
}