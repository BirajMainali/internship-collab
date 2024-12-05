using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Dto;

public class MemberDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MemberTypeName { get; set; }
    public long MemberTypeId { get; set; } 
    public List<SelectListItem> Membertypes  = new List<SelectListItem>();
    public SelectList GetMembertypesOptions ()=> new SelectList(Membertypes, nameof(SelectListItem.Value), nameof(SelectListItem.Text), MemberTypeId);
    

}