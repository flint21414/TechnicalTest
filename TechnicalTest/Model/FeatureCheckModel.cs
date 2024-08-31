using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Model
{
    public class FeatureCheckModel
    {
        [Required]
        [RegularExpression(@"^[0-1]{8}$", ErrorMessage = "Settings must be a binary string of length 8.")]
        public required string Settings { get; set; }
    }
}
