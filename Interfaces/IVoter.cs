// Handles voter-related operations

using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface IVoter
    {
        Task<bool> RegisterVoter(Resident resident); // Register a voter
        Task<string?> Authenticate(string email, string password); // Authenticate a voter
        Task<Resident?> GetVoterById(int id); // Get voter details by ID
    }
}
