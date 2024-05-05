namespace LMS.Data.entities
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int? RoleId { get; set; }


        public ICollection<Course> Courses { get; set; }
        public Role Role { get; set; }
    }
}
