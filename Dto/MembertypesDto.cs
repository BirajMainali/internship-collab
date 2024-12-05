using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Dto;

public class MembertypesDto
{
    public long Id { get; set; }
    public string TypeName { get; set; }
    public int MemberCount { get; set; }
   
}