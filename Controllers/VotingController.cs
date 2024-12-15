using Microsoft.AspNetCore.Mvc;
using VotingSystemBackend.Interfaces;
using VotingSystemBackend.Models;
using System.Threading.Tasks;

namespace VotingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly IVoting _votingService;

        public VotingController(IVoting votingService)
        {
            _votingService = votingService;
        }

        [HttpPost("{electionId}/cast")]
        public async Task<IActionResult> CastVote(int electionId, [FromBody] Vote vote)
        {
            if (vote == null || vote.ResidentID <= 0 || vote.CandidateID <= 0)
                return BadRequest("Vote, ResidentID, and CandidateID must be provided.");

            // Ensure that the passed electionId matches the vote's ElectionID
            if (vote.ElectionID != electionId)
                return BadRequest("The election ID in the vote does not match the requested election ID.");

            if (await _votingService.HasVoted(vote.ResidentID, electionId))
                return BadRequest("You have already voted in this election.");

            await _votingService.CastVote(vote);
            return Ok("Vote cast successfully.");
        }

        [HttpGet("{residentId}/{electionId}")]
        public async Task<IActionResult> GetVote(int residentId, int electionId)
        {
            // Ensure residentId is valid
            var vote = await _votingService.GetVote(residentId, electionId);
            if (vote == null)
                return NotFound("No vote found for this election and resident.");

            return Ok(vote);
        }

    }
}
