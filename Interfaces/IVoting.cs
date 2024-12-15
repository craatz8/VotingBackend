// Handles Voting Operations

using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface IVoting
    {
        Task<bool> HasVoted(int residentId, int electionId);
        Task<Vote?> GetVote(int residentId, int electionId);
        Task CastVote(Vote vote);
    }
}
