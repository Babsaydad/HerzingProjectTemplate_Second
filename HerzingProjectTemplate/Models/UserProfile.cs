using HerzingProjectTemplate.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerzingProjectTemplate.Models
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; } = null!;
        [Required]
        public string ActivityLevel { get; set; } = null!;
        [Required]
        public string FitnessGoal { get; set; } = null!;
        public double BMR { get; set; }
        public double TDEE { get; set; }

        [InverseProperty("UserProfile")]
        public ICollection<Nutrition> Nutritions { get; set; } = new List<Nutrition>();
        public ICollection<WorkOut> WorkOuts { get; set; } = new List<WorkOut>();

    }
}
