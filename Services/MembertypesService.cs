using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Services.Interfaces;

namespace ProductApp.Services;

public class MembertypesService : IMembertypesService
{
    public ApplicationDbContext _context;
    public MembertypesService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Create(MembertypesDto dto)
    {
        var membertypes = new Membertypes()
        {
            TypeName  = dto.TypeName,
            MemberCount = dto.MemberCount,
        };
        _context.Membertypes.Add(membertypes);
        await _context.SaveChangesAsync();
        
    }

    public void Edit(MembertypesDto dto)
    {
        var membertypes = _context.Membertypes.Find(dto.Id);
        membertypes.TypeName = dto.TypeName;
        membertypes.MemberCount = dto.MemberCount;
        _context.Membertypes.Update(membertypes);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        var membertypes = _context.Membertypes.Find(id);
        _context.Membertypes.Remove(membertypes);
        _context.SaveChanges();
    }
}