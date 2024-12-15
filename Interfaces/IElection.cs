// Handles election-related operations

using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface IElection
    {
        Task<IEnumerable<Election>> GetAllElections();
        Task<Election?> GetElectionById(int electionId);
        Task AddElection(Election election);
    }
}
