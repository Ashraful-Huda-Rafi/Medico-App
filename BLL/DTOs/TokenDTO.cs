using System;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string TKey { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> DelatedAt { get; set; }
        public int UserId { get; set; }
    }
}
