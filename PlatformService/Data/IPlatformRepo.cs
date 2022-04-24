using System.Diagnostics.Tracing;
using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo
{
    bool saveChanges();

    IEnumerable<Platform> getAllPlatforms();

    Platform getPlatformById(int id);

    void createPlatform(Platform platform);
}