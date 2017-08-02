using CoreTweet;
using CoreTweet.Streaming;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
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
        private Tokens tokens;
        private User user;

        [XmlIgnore]
        public Tokens Tokens { get => tokens; }

        [XmlIgnore]
        public User User { get => user; }

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
            else if (tokens != null && user != null)
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
                        tokens = await OAuth.GetTokensAsync(oAuthSession, dialog.Pin);
                        user = await tokens.Account.VerifyCredentialsAsync();

                        if (user == null)
                        {
                            throw new AuthorizationFailedException("ユーザ認証処理で不明なエラーが発生しました。");
                        }
                        else
                        {
                            // 短縮URLの文字数確認用
                            Configurations config = await tokens.Help.ConfigurationAsync();

                            AccountData = new TwitterAccountData()
                            {
                                ConsumerKey = tokens.ConsumerKey,
                                ConsumerSecret = tokens.ConsumerSecret,
                                AccessToken = tokens.AccessToken,
                                AccessSecret = tokens.AccessTokenSecret,

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
            else if (tokens != null && user != null)
            {
                throw new InvalidOperationException("既に認証されています");
            }
            else
            {
                tokens = Tokens.Create(AccountData.ConsumerKey, AccountData.ConsumerSecret, AccountData.AccessToken, AccountData.AccessSecret);
                user = await tokens.Account.VerifyCredentialsAsync();

                if (user == null)
                {
                    throw new AuthorizationFailedException("ユーザ認証処理で不明なエラーが発生しました。");
                }
                else
                {
                    // 前回の確認から1日以上経過している場合は短縮URLの文字数を確認する
                    if (DateTime.Now.Subtract(AccountData.ConfigUpdatedAt) >= new TimeSpan(1, 0, 0, 0))
                    {
                        Configurations config = await tokens.Help.ConfigurationAsync();

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

        #region Streaming API

        /// <summary>
        /// StartUserStream() で開始した User Stream 接続の IDisposable です。。
        /// </summary>
        private IDisposable userStreamIDisposable;

        /// <summary>
        /// User Stream 接続を開始します。
        /// </summary>
        public void StartUserStream()
        {
            var stream = Tokens.Streaming.UserAsObservable().Publish();
            
            stream.Subscribe(
                (StreamingMessage message) =>
                {
                    OnStreamingMessageReceicved(message);
                },
                (Exception ex) =>
                {
                    if (userStreamIDisposable != null)
                    {
                        userStreamIDisposable.Dispose();
                        userStreamIDisposable = null;
                    }

                    throw new StreamDisconnectedException("予期せず User Stream 接続が終了しました", ex);
                },
                () =>
                {
                    if (userStreamIDisposable != null)
                    {
                        userStreamIDisposable.Dispose();
                        userStreamIDisposable = null;
                    }

                    throw new StreamDisconnectedException("予期せず User Stream 接続が終了しました");
                }
            );

            userStreamIDisposable = stream.Connect();
        }

        /// <summary>
        /// Stop user stream if active
        /// </summary>
        public void StopUserStream()
        {
            if (userStreamIDisposable != null)
            {
                userStreamIDisposable.Dispose();
                userStreamIDisposable = null;
            }
        }

        /// <summary>
        /// Streaming message を受信したときに発生します。
        /// </summary>
        public event EventHandler<StreamingMessage> StreamingMessageReceived;
        
        protected virtual void OnStreamingMessageReceicved(StreamingMessage message)
        {
            StreamingMessageReceived?.Invoke(this, message);
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

    public class StreamDisconnectedException : Exception
    {
        public StreamDisconnectedException() { }
        public StreamDisconnectedException(string message) : base(message) { }
        public StreamDisconnectedException(string message, Exception innerException) : base(message, innerException) { }
    }

    #endregion
}
