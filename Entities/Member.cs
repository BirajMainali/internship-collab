namespace ProductApp.Entities;

public class Member
{
    public long Id { get; set; }
    public  string Name { get; set; }
    public  string Email { get; set; }
    public  long MemberTypeId { get; set; } 
    public virtual Membertypes Membertypes { get; set; }
    public  string MemberTypeName { get; set; }
}