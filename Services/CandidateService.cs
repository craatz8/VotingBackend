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
    public class CandidateService : ICandidate
    {
        private readonly VotingDbContext _context;

        public CandidateService(VotingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate?> GetByIdAsync(int candidateId)
        {
            return await _context.Candidates.FindAsync(candidateId);
        }
    }
}
