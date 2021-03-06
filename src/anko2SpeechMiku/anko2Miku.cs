﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using anko2MikuMikuMouth;
using anko2SpeachMiku;

namespace anko2MikuMikuMouth
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class anko2Miku : ankoPlugin2.IPlugin
    {
        private ankoPlugin2.IPluginHost _host = null;
        private SettingForm _form = null;
        private TCPListenerManager tcpThread;

        public anko2Miku()
        {
            tcpThread = new TCPListenerManager();
            tcpThread.ServerStart();
        }

        #region ankoPlugin2.IPluginの実装

        public ankoPlugin2.IPluginHost host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
                _form = new SettingForm(value);
                _host.ReceiveChat += _host_ReceiveChat;
            }
        }

        /// <summary>
        /// コメント受信時に実行される部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _host_ReceiveChat(object sender, ankoPlugin2.ReceiveChatEventArgs e)
        {
            if (_host.CurrentCast == null) { return; }

            //コメント取得していないなら何もしない
            if (string.IsNullOrEmpty(e.Chat.Message))
            {
                return;
            }

            //コメント情報をjsonに変換する
            var json = (new RequestDataPackage(e.Chat)).ToJson();
            Debug.WriteLine(json);
            tcpThread.SendToAll(json);
        }

        public string Name
        {
            get { return "みくみくまうすプラグイン" + (_form.IsRun ? "（動作中）" : ""); }
        }

        public string Description
        {
            get { return "みくみくまうすへコメント情報を送信します"; }
        }

        public bool IsAlive
        {
            get { return _form.IsRun; }
        }

        public void Run()
        {
            if (!_form.Visible)
            {
                _form.Show((System.Windows.Forms.IWin32Window)host.Win32WindowOwner);
            }
            else if (_form.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                _form.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        #endregion
    }
}
