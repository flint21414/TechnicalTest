using Microsoft.AspNetCore.Mvc;

namespace TechnicalTest.Interface
{
    public interface IUserSettingsService
    {
       bool CheckEnabledSettings(string settings, int SettingsNumber);
    }
}
