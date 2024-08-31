using TechnicalTest.Enum;
using TechnicalTest.Interface;
using TechnicalTest.Model;

namespace TechnicalTest.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        public bool IsFeatureEnabled(string settings, FeatureSettings feature)
        {
            return settings[(int)feature -1] == '1';
        }

        public FeatureSettingsModel CheckAllFeatureEnabled(string settings)
        {
            var featureSettings = new FeatureSettingsModel
            {
                SmsNotifications = IsFeatureEnabled(settings, FeatureSettings.SmsNotificationsEnabled),
                PushNotifications = IsFeatureEnabled(settings, FeatureSettings.PushNotificationsEnabled),
                Biometrics = IsFeatureEnabled(settings, FeatureSettings.BiometricsEnabled),
                Camera = IsFeatureEnabled(settings, FeatureSettings.CameraEnabled),
                Location = IsFeatureEnabled(settings, FeatureSettings.LocationEnabled),
                NFC = IsFeatureEnabled(settings, FeatureSettings.NfcEnabled),
                Vouchers = IsFeatureEnabled(settings, FeatureSettings.VouchersEnabled),
                Loyalty = IsFeatureEnabled(settings, FeatureSettings.LoyaltyEnabled)
            };

            return featureSettings;
        }
    }
}
