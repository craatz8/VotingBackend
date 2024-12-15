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
    public class VotingService : IVoting
    {
        private readonly VotingDbContext _context;

        public VotingService(VotingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasVoted(int residentId, int electionId)
        {
            return await _context.Votes.AnyAsync(v => v.ResidentID == residentId && v.ElectionID == electionId);
        }

        public async Task<Vote?> GetVote(int residentId, int electionId)
        {
            return await _context.Votes
                .Include(v => v.Candidate)
                .Include(v => v.Election)
                .FirstOrDefaultAsync(v => v.ResidentID == residentId && v.ElectionID == electionId);
        }

        public async Task CastVote(Vote vote)
        {
            if (await HasVoted(vote.ResidentID, vote.ElectionID))
                throw new InvalidOperationException("You have already voted in this election.");

            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
        }
    }
}
