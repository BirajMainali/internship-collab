using ProductApp.Dto;

namespace ProductApp.Repositories.Interfaces;

public interface IMemberRepository
{
    List<MemberDto> GetAll();
    MemberDto GetById(long id);
}