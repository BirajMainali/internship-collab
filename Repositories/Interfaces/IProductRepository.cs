using ProductApp.Dto;
using ProductApp.Entities;

namespace ProductApp.Repositories.Interfaces;

public interface IProductRepository
{
    List<ProductDto> GetAll();
    ProductDto GetById(long id);
    IQueryable<Product> GetQueryable();
}