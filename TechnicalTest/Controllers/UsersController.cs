using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Enum;
using TechnicalTest.Interface;
using TechnicalTest.Model;

namespace TechnicalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserSettingsService _userSettingsService;
        private readonly IFileService _fileService;

        public UsersController(IUserSettingsService userSettingsService, IFileService fileService)
        {
            _userSettingsService = userSettingsService;
            _fileService = fileService;
        }

        [HttpPost("check-enabled-feature")]
        public IActionResult CheckEnabledSettings(FeatureModel featureRequestModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feature = (FeatureSettings)featureRequestModel.FeatureNumber;

            try
            {
                bool isEnabled = _userSettingsService.IsFeatureEnabled(featureRequestModel.Settings, feature);
                return Ok(isEnabled);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("check-all-enabled-feature")]
        public async Task<IActionResult> CheckAllEnabledSettingsAsync(FeatureCheckModel featureRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var featureSettings = _userSettingsService.CheckAllFeatureEnabled(featureRequestModel.Settings);

                var memoryStream = await _fileService.CreateFileFromJsonAsync(featureSettings, "FeatureSettings.json");

                return File(memoryStream, "application/gzip", "FeatureSettings.gz");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
