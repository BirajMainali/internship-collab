using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
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
        
        var dto = _context.Members.Select(m=>new MemberDto()
        {
            Id = m.Id,
            Name = m.Name,
            Email= m.Email,
            MemberTypeId = m.MemberTypeId,
            MemberTypeName = m.MemberTypeName
            
            
        }).ToList();
        return dto;
        
    }
    public IQueryable<Member> GetQueryable()
    {
        return _context.Members;
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
            MemberTypeName = Member.MemberTypeName
        };
        return dto;
    }
}