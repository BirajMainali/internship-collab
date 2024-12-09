using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.ViewModels;

public class ArtistCreateVm
{
    public long Id { get; set; }
    public string Name { get; set; }

}