using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public class UserBoard
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User? User { get; set; }
        public virtual Board? Board{ get; set; }
        public virtual Role? Role{ get; set; }
    }
}
