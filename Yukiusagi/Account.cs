using CoreTweet;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StoneTank.Yukiusagi
{
    /// <summary>
    /// 1つの Twitter アカウントを示します。
    /// </summary>
    [Serializable]
    public class TwitterAccount
    {
        [XmlIgnore]
        public Tokens Tokens { get; private set; }

        [XmlIgnore]
        public User User { get; private set; }

        public TwitterAccountData AccountData { get; set; }

        /// <summary>TwitterAccount を初期化します。</summary>
        public TwitterAccount() { }

        /// <summary>既存の TwitterAccountData を使用して TwitterAccount を初期化します。</summary>
        public TwitterAccount(TwitterAccountData data) { AccountData = data; }

        #region 認証

        /// <summary>
        /// 現在の AccountData.ConsumerKey, AccountData.ConsumerSecret から初回認証を行います。
        /// </summary>
        /// <param name="owner">PIN 入力ダイアログの親ウィンドウ</param>
        public async Task AuthorizeAsync(IWin32Window owner = null)
        {
            await AuthorizeAsync(AccountData.ConsumerKey, AccountData.ConsumerSecret, owner);
        }

        /// <summary>
        /// 指定された ConsumerKey, ConsumerSecret から初回認証を行います。
        /// </summary>
        /// <param name="owner">PIN 入力ダイアログの親ウィンドウ</param>
        public async Task AuthorizeAsync(string consumerKey, string consumerSecret, IWin32Window owner = null)
        {
            if (string.IsNullOrEmpty(consumerKey) || string.IsNullOrEmpty(consumerSecret))
            {
                throw new ArgumentNullException();
            }
            else if (Tokens != null && User != null)
            {
                throw new InvalidOperationException("既に認証されています。");
            }
            else
            {
                OAuth.OAuthSession oAuthSession = await OAuth.AuthorizeAsync(consumerKey, consumerSecret);
                Process.Start(oAuthSession.AuthorizeUri.ToString());

                using (PinDialog dialog = new PinDialog())
                {
                    DialogResult result = dialog.ShowDialog(owner);

                    if (result == DialogResult.OK)
                    {
                        Tokens = await OAuth.GetTokensAsync(oAuthSession, dialog.Pin);
                        User = await Tokens.Account.VerifyCredentialsAsync();

                        if (User == null)
                        {
                            throw new AuthorizationFailedException("ユーザ認証処理で不明なエラーが発生しました。");
                        }
                        else
                        {
                            // 短縮URLの文字数確認用
                            Configurations config = await Tokens.Help.ConfigurationAsync();

                            AccountData = new TwitterAccountData()
                            {
                                ConsumerKey = Tokens.ConsumerKey,
                                ConsumerSecret = Tokens.ConsumerSecret,
                                AccessToken = Tokens.AccessToken,
                                AccessSecret = Tokens.AccessTokenSecret,

                                MediaPossiblySensitive = false,
                                ShortUrlLength = config.ShortUrlLength,
                                ShortUrlLengthHttps = config.ShortUrlLengthHttps,
                                ConfigUpdatedAt = DateTime.Now
                            };
                        }
                    }
                    else
                    {
                        throw new OperationCanceledException();
                    }
                }
            }
        }

        /// <summary>
        /// 現在の AccountData をもとに認証を行います。
        /// </summary>
        /// <returns></returns>
        public async Task CreateAsync()
        {
            if (string.IsNullOrEmpty(AccountData.ConsumerKey) || string.IsNullOrEmpty(AccountData.ConsumerSecret) ||
                string.IsNullOrEmpty(AccountData.AccessToken) || string.IsNullOrEmpty(AccountData.AccessSecret))
            {
                throw new InvalidOperationException("AccountData を設定してから実行してください");
            }
            else if (Tokens != null && User != null)
            {
                throw new InvalidOperationException("既に認証されています");
            }
            else
            {
                Tokens = Tokens.Create(AccountData.ConsumerKey, AccountData.ConsumerSecret, AccountData.AccessToken, AccountData.AccessSecret);
                User = await Tokens.Account.VerifyCredentialsAsync();

                if (User == null)
                {
                    throw new AuthorizationFailedException("ユーザ認証処理で不明なエラーが発生しました。");
                }
                else
                {
                    // 前回の確認から1日以上経過している場合は短縮URLの文字数を確認する
                    if (DateTime.Now.Subtract(AccountData.ConfigUpdatedAt) >= new TimeSpan(1, 0, 0, 0))
                    {
                        Configurations config = await Tokens.Help.ConfigurationAsync();

                        AccountData = new TwitterAccountData()
                        {
                            ConsumerKey = AccountData.ConsumerKey,
                            ConsumerSecret = AccountData.ConsumerSecret,
                            AccessToken = AccountData.AccessToken,
                            AccessSecret = AccountData.AccessSecret,

                            MediaPossiblySensitive = AccountData.MediaPossiblySensitive,
                            ShortUrlLength = config.ShortUrlLength,
                            ShortUrlLengthHttps = config.ShortUrlLengthHttps,
                            ConfigUpdatedAt = DateTime.Now
                        };
                    }
                }
            }
        }
        
        #endregion

    }

    /// <summary>
    /// Twitter アカウントの設定を定義します。
    /// </summary>
    [Serializable]
    public class TwitterAccountData
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }

        public bool MediaPossiblySensitive { get; set; }
        public int ShortUrlLength { get; set; }
        public int ShortUrlLengthHttps { get; set; }
        public DateTime ConfigUpdatedAt { get; set; }

        public TwitterAccountData() { }
    }

    #region Exception

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException() { }
        public AuthorizationFailedException(string message) : base(message) { }
        public AuthorizationFailedException(string message, Exception innerException) : base(message, innerException) { }
    }

    #endregion
}
