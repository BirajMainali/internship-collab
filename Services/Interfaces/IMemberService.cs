using ProductApp.Dto;

namespace ProductApp.Services.Interfaces;

public interface IMemberService
{
    public Task Create(MemberDto dto);
    public Task Edit(MemberDto dto);
    public Task Delete(long id);
}