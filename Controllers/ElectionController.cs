using Microsoft.AspNetCore.Mvc;
using VotingSystemBackend.Interfaces;
using VotingSystemBackend.Models;
using System.Threading.Tasks;

namespace VotingSystemBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectionController : ControllerBase
    {
        private readonly IElection _electionService;

        public ElectionController(IElection electionService)
        {
            _electionService = electionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllElections()
        {
            var elections = await _electionService.GetAllElections();
            return Ok(elections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElectionById(int id)
        {
            var election = await _electionService.GetElectionById(id);
            if (election == null) return NotFound("Election not found.\n");
            return Ok(election);
        }

        [HttpPost]
        public async Task<IActionResult> AddElection([FromBody] Election election)
        {
            if (string.IsNullOrEmpty(election.Office))
                return BadRequest("Election office name is required.\n");

            if (election.CandidateA <= 0)
                return BadRequest("Valid CandidateA is required.\n");

            await _electionService.AddElection(election);
            return Ok("Election added successfully.\n");
        }

    }
}
