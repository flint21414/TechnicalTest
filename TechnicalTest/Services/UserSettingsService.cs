using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Interface;

namespace TechnicalTest.Services
{
    public class UserSettingsService : IUserSettingsService
    {

        public bool CheckEnabledSettings(string settings, int settingsNumber)
        {
            // Ensure the settings string is valid
            if (string.IsNullOrEmpty(settings) || settings.Length != 8)
            {
                throw new ArgumentException("Settings must be an 8-bit binary string.");
            }

            if (settingsNumber < 1 || settingsNumber > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(settingsNumber), "SettingsNumber must be between 1 and 8.");
            }

            int index = 8 - settingsNumber; 

            return settings[index] == '1';
        }
    }
}
