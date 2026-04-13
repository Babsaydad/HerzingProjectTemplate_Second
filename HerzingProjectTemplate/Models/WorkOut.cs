using System.ComponentModel.DataAnnotations;

namespace HerzingProjectTemplate.Models
{
    public class WorkOut
    {
        [Key]
        public int WorkoutId { get; set; }
        
        public int UserId { get; set; }
        
        public string WorkOutType { get; set; } = null!;
        
        public string WorkoutTypeMode { get; set; } = null!;
        
        public List<string> ExerciseList { get; set; } = new List<string>();

        public string WorkoutDetails { get; set; } = null!;

        public string Day { get; set; } = null!;

        [Display(Name = "Activity Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WorkOutActivityDate { get; set; }
    }
}
