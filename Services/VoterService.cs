using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic; 
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

        public async Task RegisterAsync(Resident resident)
        {
            if (_context.Residents.Any(r => r.Email == resident.Email))
                throw new InvalidOperationException("A voter with this email already exists.");

            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();
        }

        public async Task<Resident?> AuthenticateAsync(string email, string password)
        {
            return await _context.Residents
                .FirstOrDefaultAsync(r => r.Email == email && r.Password == password);
        }
    }
}
