using ProductApp.Entities;

namespace ProductApp.Dtos;

public class SongDto
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public long ArtistId { get; set; }
    public virtual Artist Artist { get; set; }
    
}