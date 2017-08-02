using System.Text.RegularExpressions;

namespace StoneTank.Yukiusagi
{
    public static class Define
    {
        #region 正規表現

        /// <summary>
        /// HTTP および HTTPS の URL です。
        /// </summary>
        public static readonly Regex UrlRegex = new Regex(@"https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        /// <summary>
        /// スクリーンネームにマッチ
        /// </summary>
        public static readonly Regex ScreenNameRegex = new Regex(@"@[_a-zA-Z0-9]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion
    }
}
