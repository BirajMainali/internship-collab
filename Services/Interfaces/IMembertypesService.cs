using ProductApp.Dto;

namespace ProductApp.Services.Interfaces;

public interface IMembertypesService
{
    public Task Create(MembertypesDto dto);
    public void Edit (MembertypesDto dto);
    public void Delete (long id);
}