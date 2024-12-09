using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Entities;

namespace ProductApp.ViewModels;

public class ArtistVm
{
    public long Id { get; set; }
    public required string Name { get; set; }
    
}