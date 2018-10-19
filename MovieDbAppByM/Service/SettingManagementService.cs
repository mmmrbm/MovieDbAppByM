using MovieDbAppByM.EventHub;
using MovieDbAppByM.View.Helpers;
using System;

namespace MovieDbAppByM.Service
{
    public class SettingManagementService
    {
        /// <summary>
        /// The theme color codes.
        /// </summary>
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

        public event EventHandler<AppThemeChangedEventArgs> AppThemeChanged = delegate { };

        #region Implementaion Methods
        /// <summary>
        /// Responsible to produce the theme colors as per the settings selected by user.
        /// </summary>
        /// <returns></returns>
        public ThemeColorHolder GetThemeAscent()
        {
            string selectedTheme = Properties.Settings.Default.Theme;
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

        /// <summary>
        /// Reponsible to persist the theme selected by user.
        /// </summary>
        /// <param name="theme">Theme selected by user.</param>
        public void PersistApplicationTheme(string theme)
        {
            Properties.Settings.Default.Theme = theme;
            Properties.Settings.Default.Save();

            AppThemeChangedEventArgs eventArgs = new AppThemeChangedEventArgs()
            {
                SelectedTheme = theme
            };
            this.AppThemeChanged(this, eventArgs);
        }

        /// <summary>
        /// Gets application theme currently used by end user.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentTheme()
        {
            return Properties.Settings.Default.Theme;
        }
        #endregion
    }
}
