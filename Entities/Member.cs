namespace ProductApp.Entities;

public class Member
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public long MemberTypeId { get; set; } 
    public  Membertypes Membertypes { get; set; } 
}