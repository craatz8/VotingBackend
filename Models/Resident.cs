using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VotingSystemBackend.Models
{
    public class Resident
    {
        public int ResidentID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public char? MiddleInitial { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
