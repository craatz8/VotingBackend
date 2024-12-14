// Handles election-related operations

using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface IElection
    {
        Task<IEnumerable<Election>> GetAllAsync();
        Task<Election?> GetByIdAsync(int electionId);
        Task AddAsync(Election election);
    }
}
