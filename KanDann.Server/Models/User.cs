using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required,EmailAddress]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? GoogleUserId { get; set; }
        [Url]
        public string? AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        public virtual List<Board>? Boards { get; set; }
    }
}
