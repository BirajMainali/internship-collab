using Microsoft.AspNetCore.Mvc;
using ProductApp.Dto;
using ProductApp.Entities;
using ProductApp.Models;
using ProductApp.Repositories.Interfaces;
using ProductApp.Services.Interfaces;

namespace ProductApp.Controllers;

public class MemberController : Controller
{
    private readonly IMemberService _memberService;
    private readonly IMemberRepository _memberRepository;
    private readonly IMembertypesRepository _membertypesRepository;

    public MemberController(
        IMemberService memberService,
        IMemberRepository memberRepository,
        IMembertypesRepository membertypesRepository
    )
    {
        _memberService = memberService;
        _memberRepository = memberRepository;
        _membertypesRepository = membertypesRepository;
    }

    public IActionResult Index()
    {
        var members = _memberRepository.GetAll();
        var membertypes = _membertypesRepository.GetAll();

        var vm = members.Select(member => new MemberVm
        {
            Name = Member.Name,
            Email = Member.Email,
            //MemberTypeName = Member.MemberTypename,
            MemberTypeId = Member.MemberTypeId,
            Membertypes = membertypes.FirstOrDefault(Membertypes => Membertypes.Id == members.MemberTypeId)?.Name,
            
           
        }).ToList();

        return View(vm);
    }


    public IActionResult Create()
    {
        var vm = new MemberVm();
        vm.Membertypes = _membertypesRepository.GetMembertypes();
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MemberVm vm)
    {
        if (!ModelState.IsValid)
        {
            vm.Membertypes = _membertypesRepository.GetMembertypes();
            return View(vm);
        }
        var dto = new MemberDto()
        {
            Name = vm.Name,
            Email = vm.Email,
            MemberTypeName = vm.MemberTypeName,
            MemberTypeId = vm.MemberTypeId
        };
            await _memberService.Create(dto);
            return RedirectToAction("Index");
    }


    public IActionResult Edit(long id)
    {
        var dto = _memberRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        var Membertypes = _membertypesRepository.GetMembertypes();
        var vm = new MemberVm()
        {
            //Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            MemberTypeId = dto.MemberTypeId,
            MemberTypeName= dto.MemberTypeName,
            Membertypes  = Membertypes

        };
        

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, MemberVm vm)
    {
        

        if (!ModelState.IsValid)
        {
            vm.Membertypes = _membertypesRepository.GetMembertypes();
            return View(vm);
        }
        var dto = new MemberDto
        {
            Id = id,
            Name = vm.Name,
            Email= vm.Email,
            MemberTypeName = vm.MemberTypeName,
            MemberTypeId = vm.MemberTypeId
        };

        await _memberService.Edit(dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(long id)
    {
        var dto = _memberRepository.GetById(id);
        if (dto == null) return RedirectToAction("Index");
        await _memberService.Delete(id);
        return RedirectToAction("Index");
    }
}
