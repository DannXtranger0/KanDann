using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual List<ColumnBoard>? Columns { get; set; }
        public virtual List<User>? Users { get; set; }
    }
}
