using System;
using System.Collections.Generic;

namespace StoneTank.Yukiusagi
{
    /// <summary>
    /// タイムラインのプロパティを管理します
    /// </summary>
    [Serializable]
    public class TimelinePropertySet
    {
        /// <summary>タイムラインの種類</summary>
        public TimelineType Type { get; set; }

        /// <summary>種類が Home または Mentions の場合、受信アカウントのID</summary>
        public List<long> AccountIds { get; set; }

        /// <summary>種類が User の場合、当該ユーザID</summary>
        public long? UserId { get; set; }

        /// <summary>種類が Search の場合、検索ワード</summary>
        public string SearchKeyword { get; set; }
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
