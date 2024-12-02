using ProductApp.Entities;

namespace ProductApp.Viewmodels;

public class PhoneVm
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public long BrandId { get; set; }
    public Brand Brand { get; set; }
}