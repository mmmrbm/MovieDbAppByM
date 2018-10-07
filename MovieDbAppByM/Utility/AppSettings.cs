namespace MovieDbAppByM.Utility
{
    public class AppSettings
    {
        public object this[string propertyName]
        {
            get
            {
                return Properties.Settings.Default[propertyName];
            }
            set
            {
                Properties.Settings.Default[propertyName] = value;
            }
        }

        public static void Save()
        {
            Properties.Settings.Default.Save();
        }
    }
}
