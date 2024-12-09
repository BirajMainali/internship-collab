using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Dtos;
using ProductApp.Repositories;
using ProductApp.Services;
using ProductApp.ViewModels;

namespace ProductApp.Controllers;

public class ArtistController : Controller
{
    private readonly ArtistRepo _artistRepo;
    private readonly ArtistService _artistService;
    //Constructor 
    public ArtistController(ArtistRepo artistRepo, ArtistService artistService)
    {
        _artistRepo = artistRepo;
        _artistService = artistService;
    }

    // GET: artist/index
    public async Task<IActionResult> Index()
    {
        var artists = await _artistRepo.GetAllAsync();

        var artistVms = artists.Select(artist => new ArtistCreateVm
        {
            Id = artist.Id,
            Name = artist.Name
        }).ToList();

        return View(artistVms);
    }

    // GET: artist/create
    public IActionResult Create()
    {
        return View();
    }

    // POST: artist/create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ArtistCreateVm vm)
    {
        if (!ModelState.IsValid)
        {
            
            return View(vm);
        }

        var dto = new ArtistDto
        {
            Name = vm.Name
        };

        await _artistService.AddAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: artist/edit
    public async Task<IActionResult> Edit(long id)
    {
        var artist = await _artistRepo.GetByIdAsync(id);
        if (artist == null) return RedirectToAction(nameof(Index));

        var vm = new ArtistVm
        {
            Id = artist.Id,
            Name = artist.Name
        };

        return View(vm);
    }

    // POST: artist/edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ArtistVm vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var dto = new ArtistDto
        {
            Id = vm.Id,
            Name = vm.Name
        };

        await _artistService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: artist/delete
    public async Task<IActionResult> Delete(long id)
    {
        var artist = await _artistRepo.GetByIdAsync(id);
        if (artist == null) return RedirectToAction(nameof(Index));

        var vm = new ArtistVm
        {
            Id = artist.Id,
            Name = artist.Name
        };

        return View(vm);
    }

    // POST: artist/delete
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _artistService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}