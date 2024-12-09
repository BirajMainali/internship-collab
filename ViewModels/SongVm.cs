using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.ViewModels;

public class SongVm
{
    public long Id { get; set; }
    public  string Title { get; set; }
    public  string Genre { get; set; }
    public long ArtistId { get; set; }
    public List<SelectListItem> Artists { get; set; } = [];
}