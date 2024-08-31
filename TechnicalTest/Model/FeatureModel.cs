using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Model
{
    public class FeatureModel : FeatureCheckModel
    {
      
        [RegularExpression(@"^[1-8]$", ErrorMessage = "Feature Number must be a number between 1-8.")]
        public int FeatureNumber { get; set; }
    }
}
