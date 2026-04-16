using System.ComponentModel.DataAnnotations;

namespace HerzingProjectTemplate.Models
{
    public class Progress
    {
        [Key]
        public int ProgressId { get; set; }
        public int UserId { get; set; } 
        public bool NutritionStatus { get; set; }
        public bool WorkoutStatus { get; set; }
        public string Day { get; set; } = null!;

        public double TotalDailyCalories { get; set; }
        public double TotalWeeklyCalories { get; set; }
        public double TotalWeeklyProtein { get; set; }
        public double TotalWeeklyFats { get; set; }
        public double TotalWeeklyCaloriesTaken { get; set; }

        public double WeeklyNutritionPercentageCompletion { get; set; }
        public double WeeklyWorkoutPercentageCompletion { get; set; }


        /// <summary>
        //public double ProgressPercentage { get; set; }
        /// </summary>

        [Display(Name = "Activity Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProgressDate { get; set; }

        public ICollection<Nutrition> Nutritions { get; set; } = new List<Nutrition>();
        public ICollection<WorkOut> WorkOuts { get; set; } = new List<WorkOut>();

    }
}
