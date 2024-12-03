using System.ComponentModel.DataAnnotations;

namespace ProductApp.Dto;

public class MemberDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MemberTypeName { get; set; }
    public long MemberTypeId { get; set; } 
    

}