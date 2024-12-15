namespace VotingSystemBackend.Models
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Election> ElectionAsCandidateA { get; set; } = new List<Election>();
        public ICollection<Election> ElectionAsCandidateB { get; set; } = new List<Election>();
        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
