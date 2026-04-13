using System.ComponentModel.DataAnnotations;

namespace HerzingProjectTemplate.Models
{
    public class Progress
    {
        [Key]
        public int ProgressId { get; set; }
        public bool NutritionStatus { get; set; }
        public bool WorkoutStatus { get; set; }
        public string Day { get; set; } = null!;

        public double ProgressPercentage { get; set; }

        [Display(Name = "Activity Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProgressDate { get; set; }

    }
}
