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

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate?> GetCandidateById(int candidateId)
        {
            return await _context.Candidates.FindAsync(candidateId);
        }

        public async Task<bool> AddCandidate(Candidate candidate)
        {
            // Check if the candidate already exists (you can modify this logic as needed)
            if (_context.Candidates.Any(c => c.FirstName == candidate.FirstName && c.LastName == candidate.LastName))
                return false;

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
