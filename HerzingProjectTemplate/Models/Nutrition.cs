using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerzingProjectTemplate.Models
{
    public class Nutrition
    {
        [Required]
        public int NutritionId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string MealType { get; set; } = null!;
        [Required]
        public string FoodName { get; set; } = null!;
        [Required]
        public double FoodEnergy { get; set; }
        [Required]
        public string Day { get; set; } = null!;
        [Required]
        public double DailyTotal { get; set; }
        [Required]
        public double Protein { get; set; }
        [Required]
        public double Carbohydrates { get; set; }
        [Required]
        public double Fats { get; set; }
        [Required]
        public double Calories { get; set; }

        [Display(Name = "Activity Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NutritionActivityDate { get; set; }

        [ForeignKey("UserId2")]
        public virtual UserProfile? UserProfile { get; set; }
    }
}
