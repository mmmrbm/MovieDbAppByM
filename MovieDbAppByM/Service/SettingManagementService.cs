using MovieDbAppByM.Utility;
using MovieDbAppByM.View.Helpers;

namespace MovieDbAppByM.Service
{
    public class SettingManagementService
    {
        #region Constants
        private static readonly string redDeep = "#642424";
        private static readonly string redLight = "#E7B7B7";
        private static readonly string blueDeep = "#102540";
        private static readonly string blueLight = "#8BB4E2";
        private static readonly string greenDeep = "#4F6328";
        private static readonly string greenLight = "#D7E3BF";
        private static readonly string greyDeep = "#000000";
        private static readonly string greyLight = "#D9D9D9";
        private static readonly string purpleDeep = "#3F3152";
        private static readonly string purpleLight = "#CDBFD8";
        private static readonly string orangeDeep = "#984907";
        private static readonly string orangeLight = "#FCD4B1";
        #endregion

        public ThemeColorHolder GetThemeAscent()
        {
            string selectedTheme = new AppSettings()["Theme"].ToString();
            ThemeColorHolder themeColorHolder = new ThemeColorHolder();

            switch (selectedTheme)
            {
                case "Red":
                    themeColorHolder.BackgroundColor = redDeep;
                    themeColorHolder.ForegroundColor = redLight;
                    break;

                case "Green":
                    themeColorHolder.BackgroundColor = greenDeep;
                    themeColorHolder.ForegroundColor = greenLight;
                    break;

                case "Blue":
                    themeColorHolder.BackgroundColor = blueDeep;
                    themeColorHolder.ForegroundColor = blueLight;
                    break;

                case "Grey":
                    themeColorHolder.BackgroundColor = greyDeep;
                    themeColorHolder.ForegroundColor = greyLight;
                    break;

                case "Purple":
                    themeColorHolder.BackgroundColor = purpleDeep;
                    themeColorHolder.ForegroundColor = purpleLight;
                    break;

                case "Orange":
                    themeColorHolder.BackgroundColor = orangeDeep;
                    themeColorHolder.ForegroundColor = orangeLight;
                    break;

                default:
                    themeColorHolder.BackgroundColor = greyDeep;
                    themeColorHolder.ForegroundColor = greyLight;
                    break;
            }

            return themeColorHolder;
        }

        public void SetApplicationTheme(string theme)
        {
            new AppSettings()["Theme"] = theme;
        }
    }
}
