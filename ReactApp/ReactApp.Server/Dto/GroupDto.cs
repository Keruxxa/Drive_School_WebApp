namespace API.Server.Dto
{
    public class GroupDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Category { get; set; }

        public DateTime StartOfTraining { get; set; }

        public DateTime EndOfTraining { get; set; }
    }
}
