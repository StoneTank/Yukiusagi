using System;
using System.Collections.Generic;

namespace StoneTank.Yukiusagi
{
    /// <summary>
    /// タイムラインのプロパティを管理します
    /// </summary>
    [Serializable]
    public class TimelineProperty
    {
        /// <summary>Form の PersistString</summary>
        public string FormPersistString { get; set; }
        
        /// <summary>タイムラインのタブなどに表示されるテキスト</summary>
        public string Text { get; set; }

        /// <summary>タイムラインの種類</summary>
        public TimelineType Type { get; set; }

        /// <summary>受信アカウントのID</summary>
        public List<long> AccountIds { get; set; } = new List<long>();

        /// <summary>種類が User の場合、当該ユーザID</summary>
        public long? UserId { get; set; }

        /// <summary>種類が Search の場合、検索ワード</summary>
        public string SearchKeyword { get; set; }

        public TimelineProperty() { }

        public TimelineProperty(TimelineType type, string text, params long[] accountIds)
        {
            Type = type;
            Text = text;
            if (accountIds.Length > 0) { AccountIds.AddRange(accountIds); }
        }

        public TimelineProperty(TimelineType type, string text, long? userId, params long[] accountIds)
        {
            Type = type;
            Text = text;
            UserId = userId;
            if (accountIds.Length > 0) { AccountIds.AddRange(accountIds); }
        }

        public TimelineProperty(TimelineType type, string text, string searchKeyword, params long[] accountIds)
        {
            Type = type;
            Text = text;
            SearchKeyword = searchKeyword;
            if (accountIds.Length > 0) { AccountIds.AddRange(accountIds); }
        }
    }

    /// <summary>
    /// タイムラインの種類
    /// </summary>
    public enum TimelineType
    {
        Home,
        Mentions,
        Messages, // reserved
        List, // reserved
        User,
        Search
    }
}
