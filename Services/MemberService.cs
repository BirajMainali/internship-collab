using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class MemberService: IMemberService
{
    private readonly ApplicationDbContext _context;

    public MemberService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async  Task Create(MemberDto dto)
    {
        var member = new Member()
        {
            Name = dto.Name,
            Email = dto.Email,  
            MemberTypeName = dto.MemberTypeName,
            MemberTypeId =   dto.MemberTypeId

        };
        _context.Members.Add(member);
        await _context.SaveChangesAsync();

    }

    public async Task Edit(MemberDto dto)
    {
        var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == dto.Id);
        member.Name = dto.Name;
        member.Email= dto.Email;
        member.MemberTypeId = dto.MemberTypeId;
        member.MemberTypeName = dto.MemberTypeName;

        await _context.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var member = await _context.Members.FindAsync( id);
        _context.Members.Remove(member);

        await _context.SaveChangesAsync();
    }
}