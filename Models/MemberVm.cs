using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Entities;

namespace ProductApp.Models;

public class MemberVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MemberTypeName { get; set; } 
    public long MemberTypeId { get; set; } 
    public List<SelectListItem> Membertypes  = new List<SelectListItem>();
    public SelectList GetMembertypesOptions ()=> new SelectList(Membertypes, nameof(SelectListItem.Value), nameof(SelectListItem.Text), MemberTypeId);
   
}