using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Dto;

namespace ProductApp.Repositories.Interfaces;

public interface IMembertypesRepository
{
    List<MembertypesDto> GetAll();
    MembertypesDto GetById(long id);
    List<SelectListItem> GetMembertypes();
}