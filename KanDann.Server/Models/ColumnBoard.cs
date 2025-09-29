using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public class ColumnBoard
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Position { get; set; }
        public int ColumnTypeId{ get; set; }
        public int BoardId{ get; set; }

        public virtual ColumnType? ColumnType{ get; set; }
        public virtual Board? Board{ get; set; }
        public virtual List<Tasks>? Tasks{ get; set; }

    }
}
