using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace StoneTank.Yukiusagi
{
    class WebBrowserHacker
    {
        public enum Version
        {
            /// <summary>
            /// Internet Explorer 11 (Edge モード) と同等のバージョン
            /// </summary>
            IE11Edge = 0x2af9,

            /// <summary>
            /// Internet Explorer 11 と同等のバージョン
            /// </summary>
            IE11 = 0x2af8,

            /// <summary>
            /// Internet Explorer 10 (Standards モード) と同等のバージョン
            /// </summary>
            IE10Standards = 0x2711,

            /// <summary>
            /// Internet Explorer 10 と同等のバージョン
            /// </summary>
            IE10 = 0x2710,

            /// <summary>
            /// Internet Explorer 9 (Standards モード) と同等のバージョン
            /// </summary>
            IE9Standards = 0x270f,

            /// <summary>
            /// Internet Explorer 9 と同等のバージョン
            /// </summary>
            IE9 = 0x2710,

            /// <summary>
            /// Internet Explorer 8 (Standards モード) と同等のバージョン
            /// </summary>
            IE8Standards = 0x22b8,

            /// <summary>
            /// Internet Explorer 8 と同等のバージョン
            /// </summary>
            IE8 = 0x1f40,

            /// <summary>
            /// Internet Explorer 7 と同等のバージョン
            /// </summary>
            IE7 = 0x1b58
        }

        /// <summary>
        /// appName で指定したアプリケーション上の WebBrowser が version で指定したバージョンの IE と同様の動作をするよう設定します。appName を省略すると現在のアセンブリを指定します。
        /// </summary>
        /// <param name="version">設定するバージョン。</param>
        /// <param name="appName">対象アプリケーションのファイル名。例: 'example.exe'。省略すると現在のアセンブリを指定します。</param>
        public static void SetVersion(Version version, string appName = "")
        {
            if (appName == "")
            {
                appName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            }

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION");

            try
            {
                key.SetValue(appName, (int)version);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                key.Close();
            }
        }

        /// <summary>
        /// appName で指定したアプリケーションについて WebBrowser のバージョンを制御する設定が既に存在していれば削除し、存在しない場合は何もしません。appName を省略すると現在のアセンブリを指定します。
        /// </summary>
        /// <param name="appName">対象アプリケーションのファイル名。例: 'example.exe'。省略すると現在のアセンブリを指定します。</param>
        public static void UnsetVersion(string appName = "")
        {
            if (appName == "")
            {
                appName = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);

            try
            {
                key.DeleteValue(appName, false);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                key.Close();
            }
        }

        /// <summary>
        /// WebBrowser のナビゲート音を有効または無効にします。この設定は現在のアプリケーションにのみ有効です。
        /// </summary>
        public static void SetNavigateSound(bool soundEnabled)
        {
            CoInternetSetFeatureEnabled(0x15, 0x2, !soundEnabled);
        }

        [DllImport("urlmon.dll")]
        private static extern int CoInternetSetFeatureEnabled(int featureEntry, [MarshalAs(UnmanagedType.U4)] int dwFlags, [MarshalAs(UnmanagedType.Bool)] bool fEnable);
    }
}
