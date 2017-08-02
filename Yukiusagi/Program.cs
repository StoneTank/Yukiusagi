using StoneTank.Yukiusagi.Properties;
using System;
using System.Windows.Forms;

namespace StoneTank.Yukiusagi
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set registry key so that WebBrowser emulates IE11
            WebBrowserHacker.SetVersion(WebBrowserHacker.Version.IE11Edge);

            // Disable navigation sound
            WebBrowserHacker.SetNavigateSound(false);

            // 現在のバージョンで既にアカウントを設定しておらず、バージョン 2.x での設定が生き残っていれば引き継ぐ
            if (Settings.Default.TwitterAccounts.Count == 0)
            {
                try
                {
                    string consumerKey = Settings.Default.GetPreviousVersion("ConsumerKey") as string;
                    string consumerSecret = Settings.Default.GetPreviousVersion("ConsumerSecret") as string;
                    string accessToken = Settings.Default.GetPreviousVersion("AccessToken") as string;
                    string accessSecret = Settings.Default.GetPreviousVersion("AccessSecret") as string;

                    if (!string.IsNullOrEmpty(consumerKey) && !string.IsNullOrEmpty(consumerSecret) &&
                        !string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(accessSecret))
                    {
                        Settings.Default.TwitterAccounts.Add(new TwitterAccount(new TwitterAccountData()
                        {
                            ConsumerKey = consumerKey,
                            ConsumerSecret = consumerSecret,
                            AccessToken = accessToken,
                            AccessSecret = accessSecret
                        }));
                    }
                }
                catch (System.Configuration.SettingsPropertyNotFoundException)
                {
                    // Do nothing
                }
            }

            // それ以外の前のバージョンの設定を引き継ぐ
            if (!Settings.Default.IsUpgraded)
            {
                Settings.Default.Upgrade();
                Settings.Default.IsUpgraded = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}
