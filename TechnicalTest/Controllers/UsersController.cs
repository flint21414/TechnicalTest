using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechnicalTest.Interface;

namespace TechnicalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserSettingsService _userSettingsService;

        public UsersController(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }
        [HttpGet]
        public IActionResult CheckEnabledSettings([Required] string settings, [Required] int settingNumber)
        {
            try
            {
                return Ok(_userSettingsService.CheckEnabledSettings(settings, settingNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
