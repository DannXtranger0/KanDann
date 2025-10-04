using System.ComponentModel.DataAnnotations;

namespace KanDann.Server.Models
{
    public enum RoleEnum
    {
        Admin,
        User,
        Seeker
    }
    public class Role
    {
        public int Id { get; set; }
        public RoleEnum Name { get; set; }
        
    }
}
