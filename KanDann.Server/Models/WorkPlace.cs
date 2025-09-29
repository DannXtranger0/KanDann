using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public class WorkPlace
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
