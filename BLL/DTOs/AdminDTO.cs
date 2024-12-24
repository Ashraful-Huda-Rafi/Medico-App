using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
