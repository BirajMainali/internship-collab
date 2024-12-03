using Microsoft.AspNetCore.Mvc;
using ProductApp.Dto;
using ProductApp.Models;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class MembertypesController : Controller
{
    private readonly IMembertypesService _membertypesService;
    private readonly IMembertypesRepository _membertypesRepository;
    
    public MembertypesController
    (
        IMembertypesService membertypesService,
        IMembertypesRepository membertypesRepository
    )
    {
        _membertypesService = membertypesService;
        _membertypesRepository = membertypesRepository;
    }

    public IActionResult Index()
    {
        var membertypes = _membertypesRepository.GetAll();
        return View(membertypes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MembertypesVm vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        var dto = new MembertypesDto()
        {
            TypeName  = vm.TypeName,
            MemberCount = vm.MemberCount
        };
        await _membertypesService.Create(dto);
        return RedirectToAction("Index");
        
        
    }


    public IActionResult Edit(long id)
    {
        var dto = _membertypesRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        return View(dto);
    }
    
    [HttpPost]
    public IActionResult Edit(long id ,MembertypesVm vm)
    {
        var dto = new MembertypesDto()
        {
            Id = id,
            TypeName = vm.TypeName,
            MemberCount = vm.MemberCount
        };
        if(!ModelState.IsValid) 
            return View(dto);
        _membertypesService.Edit(dto);
        return RedirectToAction("Index");
    }
    public IActionResult Delete(long id)
    {
        var dto = _membertypesRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        _membertypesService.Delete(id);
        return RedirectToAction("Index");
    }
}