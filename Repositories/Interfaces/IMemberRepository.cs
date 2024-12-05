using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IMemberRepository
{
    List<MemberDto> GetAll();
    MemberDto GetById(long id);
    IQueryable<Member> GetQueryable();
}