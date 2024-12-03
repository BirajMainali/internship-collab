using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class MemberRepository: IMemberRepository
{
    public ApplicationDbContext _context;

    public MemberRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<MemberDto> GetAll()
    {
        
        var dto = _context.Members.Select(x=>new MemberDto()
        {
            Id = x.Id,
            Name = x.Name,
            Email= x.Email,
            MemberTypeId = x.MemberTypeId,
            //MemberTypeName = x.MemberTypeName
            
            
        }).ToList();
        return dto;
        
    }

    public MemberDto GetById(long id)
    {
        var Member = _context.Members.Find(id);
        var dto = new MemberDto()
        {
            Id = Member.Id,
            Name = Member.Name,
            Email = Member.Email,
            MemberTypeId = Member.MemberTypeId,
            
        };
        return dto;
    }
}