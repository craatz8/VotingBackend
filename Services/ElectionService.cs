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
    public class ElectionService : IElection
    {
        private readonly VotingDbContext _context;

        public ElectionService(VotingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Election>> GetAllAsync()
        {
            return await _context.Elections.ToListAsync();
        }

        public async Task<Election?> GetByIdAsync(int electionId)
        {
            return await _context.Elections.FindAsync(electionId);
        }

        public async Task AddAsync(Election election)
        {
            _context.Elections.Add(election);
            await _context.SaveChangesAsync();
        }
    }
}
