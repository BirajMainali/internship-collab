using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models;

public class MembertypesVm
{
    [Required]
    public string TypeName { get; set; }
    public int MemberCount { get; set; }
}