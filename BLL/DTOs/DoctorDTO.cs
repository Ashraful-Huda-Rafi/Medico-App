namespace BLL.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AdminId { get; set; }
        public string Specialization { get; set; }
        public int UserId { get; set; }
    }
}
