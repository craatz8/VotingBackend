using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotingSystemBackend.Data;
using VotingSystemBackend.Interfaces;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Services
{
    public class VoterService : IVoter
    {
        private readonly VotingDbContext _context;

        public VoterService(VotingDbContext context)
        {
            _context = context;
        }

        // Implements Task<bool> RegisterVoter(Resident resident)
        public async Task<bool> RegisterVoter(Resident resident)
        {
            // Asynchronously check if a resident with the same email already exists
            if (await _context.Residents.AnyAsync(r => r.Email == resident.Email))
                return false; // Registration failed due to duplicate email

            // Add the new resident to the database
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();
            return true; // Registration successful
        }

        // Implements Task<string?> Authenticate(string email, string password)
        public async Task<string?> Authenticate(string email, string password)
        {
            // Asynchronously find the resident with matching email and password
            var resident = await _context.Residents
                .FirstOrDefaultAsync(r => r.Email == email && r.Password == password);

            if (resident == null)
                return null; // Authentication failed

           
            return Guid.NewGuid().ToString();
        }

        // Implements Task<Resident?> GetVoterById(int id)
        public async Task<Resident?> GetVoterById(int id)
        {
            // Asynchronously retrieve the resident by ID
            return await _context.Residents.FindAsync(id);
        }
    }
}
