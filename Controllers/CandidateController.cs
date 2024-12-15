using Microsoft.AspNetCore.Mvc;
using VotingSystemBackend.Interfaces;
using VotingSystemBackend.Models;
using System.Threading.Tasks;

namespace VotingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidate _candidateService;

        public CandidateController(ICandidate candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null) return NotFound("Candidate not found.");
            return Ok(candidate);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidate)
        {
            if (string.IsNullOrEmpty(candidate.FirstName) || string.IsNullOrEmpty(candidate.LastName))
                return BadRequest("Candidate first and last name are required.");

            var result = await _candidateService.AddCandidate(candidate);
            if (!result) return BadRequest("Failed to add candidate. Candidate may already exist.");
            return Ok("Candidate added successfully.");
        }
    }
}
