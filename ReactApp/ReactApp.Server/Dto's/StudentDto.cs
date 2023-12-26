namespace API.Server.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public bool PassedTheory { get; set; } = false;
    }
}
