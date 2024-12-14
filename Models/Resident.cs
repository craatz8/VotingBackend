namespace VotingSystemBackend.Models
{
    public class Resident
    {
        public int ResidentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public char? MiddleInitial { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
