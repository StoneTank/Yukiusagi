﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace StoneTank.Yukiusagi.Properties
{
    // このクラスでは設定クラスでの特定のイベントを処理することができます:
    //  SettingChanging イベントは、設定値が変更される前に発生します。
    //  PropertyChanged イベントは、設定値が変更された後に発生します。
    //  SettingsLoaded イベントは、設定値が読み込まれた後に発生します。
    //  SettingsSaving イベントは、設定値が保存される前に発生します。
    internal sealed partial class Settings
    {

        public Settings()
        {
            // // 設定の保存と変更のイベント ハンドラーを追加するには、以下の行のコメントを解除します:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
            // SettingChangingEvent イベントを処理するコードをここに追加してください。
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
            // SettingsSaving イベントを処理するコードをここに追加してください。
        }

        /// <summary>
        /// Twitter のアカウント設定
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public List<TwitterAccount> TwitterAccounts
        {
            get { return (List<TwitterAccount>)(this["TwitterAccounts"]); }
            set { this["TwitterAccounts"] = value; }
        }

        /// <summary>
        /// タイムライン設定
        /// </summary>
        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public List<TimelineProperty> TimelineProperties
        {
            get { return (List<TimelineProperty>)(this["TimelineProperties"]); }
            set { this["TimelineProperties"] = value; }
        }
    }
}
