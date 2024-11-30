using ProductApp.Dto;

namespace ProductApp.Services.Interfaces;

public interface IProductService
{
    public Task Create(ProductDto dto);
    public Task Edit(ProductDto dto);

}