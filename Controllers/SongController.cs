using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Dtos;
using ProductApp.Repositories;
using ProductApp.Services;
using ProductApp.ViewModels;


namespace ProductApp.Controllers;

public class SongController : Controller
{
    private readonly ArtistRepo _artistRepo;
    private readonly SongRepo _songRepo;
    private readonly SongService _songService;

    // constructor
    public SongController(SongRepo songRepo, SongService songService, ArtistRepo artistRepo)
    {
        _songRepo = songRepo;
        _songService = songService;
        _artistRepo = artistRepo;
    }

    // GET: song/index
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var songs = await _songRepo.GetAllWithArtistsAsync();
        var songVms = songs.Select(song => new SongVm
        {
            Id = song.Id,
            Title = song.Title,
            Genre = song.Genre,
            ArtistId = song.ArtistId,
            Artists = new List<SelectListItem> { new SelectListItem { Text = song.Artist.Name, Value = song.Artist.Id.ToString() } }
        }).ToList();

        return View(songVms);
    }

    // GET: song/create
    public async Task<IActionResult> Create()
    {
        var artists = await _artistRepo.GetAllAsync();

        var vm = new SongVm
        {
            Artists = artists.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList()
        };

        return View(vm);
    }

    // POST: song/create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SongVm vm)
    {
        if (!ModelState.IsValid)
        {
            // Repopulate dropdown if validation fails
            vm.Artists = (await _artistRepo.GetAllAsync()).Select(artist => new SelectListItem
            {
                Value = artist.Id.ToString(),
                Text = artist.Name
            }).ToList();
            return View(vm);
        }

        var dto = new SongDto
        {
            Title = vm.Title,
            Genre = vm.Genre,
            ArtistId = vm.ArtistId
        };

        await _songService.AddAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: song/edit
    // In SongController.cs
    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var song = await _songRepo.GetByIdAsync(id);
        if (song == null)
        {
            return NotFound();
        }

        var artists = await _artistRepo.GetAllAsync();

        var vm = new SongVm
        {
            Id = song.Id,
            Title = song.Title,
            Genre = song.Genre,
            ArtistId = song.ArtistId,
            Artists = artists.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList()
        };

        return View(vm);
    }


    // POST: song/edit
    [HttpPost]
    public async Task<IActionResult> Edit(SongVm vm)
    {
        if (!ModelState.IsValid)
        {
            // Repopulate Artists list in case of validation failure
            var artists = await _artistRepo.GetAllAsync();
            vm.Artists = artists.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return View(vm);
        }

        var dto = new SongDto
        {
            Id = vm.Id,
            Title = vm.Title,
            Genre = vm.Genre,
            ArtistId = vm.ArtistId
        };

        await _songService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }


    // GET: song/delete
    public async Task<IActionResult> Delete(long id)
    {
        var song = await _songRepo.GetByIdAsync(id);
        if (song == null) return RedirectToAction(nameof(Index));

        var vm = new SongVm
        {
            Id = song.Id,
            Title = song.Title,
            Genre = song.Genre,
            ArtistId = song.ArtistId
        };

        return View(vm);
    }

    // POST: song/delete
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _songService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}