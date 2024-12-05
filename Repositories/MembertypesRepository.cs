using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Data;
using ProductApp.Dto;
using ProductApp.Repositories.Interfaces;

namespace ProductApp.Repositories;

public class MembertypesRepository: IMembertypesRepository
{
    public ApplicationDbContext _context;

    public MembertypesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public  List<MembertypesDto> GetAll()
    {
        var dto = _context.Membertypes.Select(x=>new MembertypesDto
        {
            Id = x.Id,
            TypeName  = x.TypeName,
            MemberCount = x.MemberCount
        }).ToList();
        return dto;
    }

    public MembertypesDto GetById(long id)
    {
        var dto = _context.Membertypes.Where(x => x.Id == id).Select(x => new MembertypesDto
        {
            Id = x.Id,
            TypeName = x.TypeName,
            MemberCount = x.MemberCount
        }).FirstOrDefault();
        return dto;
    }

    public List<SelectListItem> GetMembertypes()
    {
        var Membertypes= _context.Membertypes.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.TypeName
        }).ToList();
        return Membertypes;
        
    }
}
