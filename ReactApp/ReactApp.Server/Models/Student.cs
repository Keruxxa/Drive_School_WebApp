namespace API.Server.Models
{
    public class Student : Person
    {
        public bool PassedTheory { get; set; } = false;

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
