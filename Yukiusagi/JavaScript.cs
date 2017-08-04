using System;
using System.Runtime.InteropServices;

namespace StoneTank.Yukiusagi
{
    [ComVisible(true)]
    public class JsFront
    {
        /// <summary>
        /// JavaScript 側で window.external.Favorite(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<JsButtonClickedEventArgs> FavoriteButtonClicked;

        protected virtual void OnFavoriteButtonClicked(JsButtonClickedEventArgs e)
        {
            FavoriteButtonClicked?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.Retweet(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<JsButtonClickedEventArgs> RetweetButtonClicked;

        protected virtual void OnRetweetButtonClicked(JsButtonClickedEventArgs e)
        {
            RetweetButtonClicked?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.Steal(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<JsButtonClickedEventArgs> StealButtonClicked;

        protected virtual void OnStealButtonClicked(JsButtonClickedEventArgs e)
        {
            StealButtonClicked?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.Reply(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<JsButtonClickedEventArgs> ReplyButtonClicked;

        protected virtual void OnReplyButtonClicked(JsButtonClickedEventArgs e)
        {
            ReplyButtonClicked?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.Destroy(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<JsButtonClickedEventArgs> DestroyButtonClicked;

        protected virtual void OnDestroyButtonClicked(JsButtonClickedEventArgs e)
        {
            DestroyButtonClicked?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.ShowStatus(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<ShowStatusCalledEventArgs> ShowStatusCalled;

        protected virtual void OnShowStatusCalled(ShowStatusCalledEventArgs e)
        {
            ShowStatusCalled?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.ShowUser(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<ShowUserCalledEventArgs> ShowUserCalled;

        protected virtual void OnShowUserCalled(ShowUserCalledEventArgs e)
        {
            ShowUserCalled?.Invoke(this, e);
        }

        /// <summary>
        /// JavaScript 側で window.external.Search(...) が呼び出された時に発生します。
        /// </summary>
        public event EventHandler<SearchCalledEventArgs> SearchCalled;

        protected virtual void OnSearchCalled(SearchCalledEventArgs e)
        {
            SearchCalled?.Invoke(this, e);
        }

        // Will be called from JavaScript
        public void Favorite(long statusId, string callBackFunctionString)
        {
            OnFavoriteButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Retweet(long statusId, string callBackFunctionString)
        {
            OnRetweetButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Steal(long statusId, string callBackFunctionString)
        {
            OnStealButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Reply(long statusId, string callBackFunctionString)
        {
            OnReplyButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Destroy(long statusId, string callBackFunctionString)
        {
            OnDestroyButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void ShowStatus(long statusId)
        {
            OnShowStatusCalled(new ShowStatusCalledEventArgs(statusId));
        }

        // Will be called from JavaScript
        public void ShowUser(long userId)
        {
            OnShowUserCalled(new ShowUserCalledEventArgs(userId));
        }

        // Will be called from JavaScript
        public void ShowUser(string screenName)
        {
            OnShowUserCalled(new ShowUserCalledEventArgs(screenName));
        }

        // Will be called from JavaScript
        public void Search(string keyword)
        {
            OnSearchCalled(new SearchCalledEventArgs(keyword));
        }

        public bool IsOwnTweet(long statusId)
        {
            // Not Implemented
            return false;
        }

        public bool IsReplyToMe(long statusId)
        {
            // Not Implemented
            return false;
        }

        public bool IsFavorited(long statusId)
        {
            // Not Implemented
            return false;
        }

        public bool IsRetweeted(long statusId)
        {
            // Not Implemented
            return false;
        }
    }

    /// <summary>
    /// JavaScript から呼び出されるイベントで、特にボタン操作によるものの引数を表します。
    /// </summary>
    public class JsButtonClickedEventArgs : EventArgs
    {
        /// <summary>
        /// 対象の Status ID
        /// </summary>
        public long StatusId { get; set; }

        /// <summary>
        /// 処理が完了した際に呼び出される関数名、または実行される JavaScript コード。この内容は eval で評価されます。
        /// </summary>
        public string CallBackFunctionString { get; set; }

        public JsButtonClickedEventArgs(long statusId, string callBackFunctionString)
        {
            this.StatusId = statusId;
            this.CallBackFunctionString = callBackFunctionString;
        }
    }

    /// <summary>
    /// JavaScript から status/show を要求されたときに発生するイベントの引数を表します。
    /// </summary>
    public class ShowStatusCalledEventArgs : EventArgs
    {
        /// <summary>
        /// 対象の ID (Status ID や User ID)
        /// </summary>
        public long StatusId { get; set; }

        public ShowStatusCalledEventArgs(long statusId)
        {
            this.StatusId = statusId;
        }
    }

    /// <summary>
    /// JavaScript から user/show を要求されたときに発生するイベントの引数を表します。
    /// </summary>
    public class ShowUserCalledEventArgs : EventArgs
    {
        /// <summary>
        /// ユーザ ID。UserId または ScreenName のいずれかを使用します。
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// スクリーンネーム。UserId または ScreenName のいずれかを使用します。
        /// </summary>
        public string ScreenName { get; set; }

        public ShowUserCalledEventArgs(long userId)
        {
            this.UserId = userId;
        }

        public ShowUserCalledEventArgs(string screenName)
        {
            this.ScreenName = screenName;
        }

        public ShowUserCalledEventArgs(long userId, string screenName)
        {
            this.UserId = userId;
            this.ScreenName = screenName;
        }
    }

    /// <summary>
    /// JavaScript から Search を要求されたときに発生するイベントの引数を表します。
    /// </summary>
    public class SearchCalledEventArgs : EventArgs
    {
        /// <summary>
        /// 対象キーワード
        /// </summary>
        public string Keyword { get; set; }

        public SearchCalledEventArgs(string keyword)
        {
            this.Keyword = keyword;
        }
    }
}
