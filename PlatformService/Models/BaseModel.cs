using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models;

public abstract class BaseModel
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;
}
