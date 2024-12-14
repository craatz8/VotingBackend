namespace VotingSystemBackend.Models
{
    public class Election
    {
        public int ElectionID { get; set; }
        public int ElectionYear { get; set; }
        public string? Office { get; set; }
        public int CandidateA { get; set; }
        public int? CandidateB { get; set; }

        public Candidate CandidateAEntity { get; set; } = null!;
        public Candidate? CandidateBEntity { get; set; } = null!;

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
