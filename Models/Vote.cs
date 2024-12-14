namespace VotingSystemBackend.Models
{
    public class Vote
    {
        public int VoteID { get; set; }
        public int ResidentID { get; set; }
        public int VoteYear { get; set; }
        public int ElectionID { get; set; }
        public int CandidateID { get; set; }

        // For if vote has been submitted yet or not. Helps voter verify their vote if = false
        public bool IsSubmitted { get; set; } = false;

        public Resident Resident { get; set; } = null!;
        public Election Election { get; set; } = null!;
        public Candidate Candidate { get; set; } = null!;
    }
}
