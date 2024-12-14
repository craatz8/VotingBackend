// Handles Candidate Related Operations

using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface ICandidate
    {
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task<Candidate?> GetByIdAsync(int candidateId);
    }
}
