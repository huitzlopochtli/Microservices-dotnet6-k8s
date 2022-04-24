using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

class PlatformRepo : IPlatformRepo
{
    private AppDbContext _context;
    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }
    public void createPlatform(Platform platform)
    {
        if(platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }
        
        _context.Add(platform);
    }

    public IEnumerable<Platform> getAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform getPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public bool saveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}