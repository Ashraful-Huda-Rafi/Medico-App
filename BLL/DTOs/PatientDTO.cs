using System;

namespace BLL.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AminId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public int UserId { get; set; }
    }
}
