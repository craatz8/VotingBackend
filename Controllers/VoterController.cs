using Microsoft.AspNetCore.Mvc;
using VotingSystemBackend.Interfaces;
using VotingSystemBackend.Models;

namespace VotingSystemBackend.Controllers
{
    [Route("api/voters")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoter _voterService;

        public VoterController(IVoter voterService)
        {
            _voterService = voterService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Resident resident)
        {
            try
            {
                var result = await _voterService.RegisterVoter(resident);
                if (!result) return BadRequest("Voter registration failed.");
                return Ok("Voter registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during voter registration: {ex.Message}");
                return StatusCode(500, "An internal error occurred.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var token = await _voterService.Authenticate(loginRequest.Email, loginRequest.Password);
            if (string.IsNullOrEmpty(token)) return Unauthorized("Invalid credentials.");
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoterDetails(int id)
        {
            var voter = await _voterService.GetVoterById(id);
            if (voter == null) return NotFound("Voter not found.");
            return Ok(voter);
        }
    }
}
