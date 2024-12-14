// Handles voter-related operations

using System.Threading.Tasks;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Interfaces
{
    public interface IVoter
    {
        Task RegisterAsync(Resident resident);
        Task<Resident?> AuthenticateAsync(string email, string password);
    }
}
