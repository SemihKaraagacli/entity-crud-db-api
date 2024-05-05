namespace LMS.Data.entities
{
    public class Course:BaseEntity
    {
        public string Name { get; set; }
        public string Descrition { get; set; }
        public int? TeacherId { get; set; }
        public User Teacher { get; set; }
    }
}
