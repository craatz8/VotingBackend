// Handles Voting Operations

using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface IVoting
    {
        Task<bool> HasVotedAsync(int residentId, int electionId);
        Task<Vote?> GetVoteAsync(int residentId, int electionId);
        Task SubmitVoteAsync(Vote vote);
    }
}
