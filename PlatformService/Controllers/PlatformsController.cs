using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/platforms")]
public class PlatformsController: ControllerBase
{
    private readonly ILogger<PlatformsController> _logger;
    private readonly IPlatformRepo _platformRepo;
    private readonly IMapper _mapper;

    public PlatformsController(ILogger<PlatformsController> logger, IPlatformRepo repo, IMapper mapper)
    {
        _logger = logger;
        _platformRepo = repo;
        _mapper = mapper;
    }


    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {

        Console.WriteLine("--> Gettign Platforms");

        var platforms = _platformRepo.getAllPlatforms();

        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms)); 
    }

    [HttpGet("{id}", Name = "getPlatformById")]
    public ActionResult<PlatformReadDto> getPlatformById(int id)
    {

        Console.WriteLine($"--> Gettign Platforms by Id: {id}");

        var platform = _platformRepo.getPlatformById(id);

        if (platform == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PlatformReadDto>(platform));
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platformModel = _mapper.Map<Platform>(platformCreateDto);
        _platformRepo.createPlatform(platformModel);
        _platformRepo.saveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

        return CreatedAtRoute(nameof(getPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
    }
}
