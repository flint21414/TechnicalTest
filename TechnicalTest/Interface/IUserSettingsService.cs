using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Enum;
using TechnicalTest.Model;

namespace TechnicalTest.Interface
{
    public interface IUserSettingsService
    {
        bool IsFeatureEnabled(string settings, FeatureSettings feature);
        FeatureSettingsModel CheckAllFeatureEnabled(string settings);

    }
}
