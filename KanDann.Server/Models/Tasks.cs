using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ColumnBoardId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ColumnBoard? Column { get; set; } 

    }
}
