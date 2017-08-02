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
        
        // Will be called from JavaScript
        public void Favorite(int statusId, string callBackFunctionString)
        {
            OnFavoriteButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Retweet(int statusId, string callBackFunctionString)
        {
            OnRetweetButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Steal(int statusId, string callBackFunctionString)
        {
            OnStealButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }

        // Will be called from JavaScript
        public void Reply(int statusId, string callBackFunctionString)
        {
            OnReplyButtonClicked(new JsButtonClickedEventArgs(statusId, callBackFunctionString));
        }
    }

    /// <summary>
    /// JavaScript から呼び出されるイベントの引数を表します。
    /// </summary>
    public class JsButtonClickedEventArgs : EventArgs
    {
        /// <summary>
        /// 対象の Status ID
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// 処理が完了した際に呼び出される関数名、または実行される JavaScript コード。この内容は eval で評価されます。
        /// </summary>
        public string CallBackFunctionString { get; set; }

        public JsButtonClickedEventArgs(int statusId, string callBackFunctionString)
        {
            this.StatusId = statusId;
            this.CallBackFunctionString = callBackFunctionString;
        }
    }
}
