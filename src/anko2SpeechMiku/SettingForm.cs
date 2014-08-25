using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace anko2SpeachMiku {
	internal sealed partial class SettingForm : Form {
		private ankoPlugin2.IPluginHost _host = null;
		private Form _hostForm = null;
		private Config _configData = new Config();

        private BoyomiDictionary boyomichanDictionary;

		// プラグインが動作してるときtrueを返すようにすること
		public bool IsRun { get; private set; }

		public SettingForm(ankoPlugin2.IPluginHost host) {
			InitializeComponent();
            boyomichanDictionary = new BoyomiDictionary();
			this._host = host;
			this._hostForm = (Form)host.Win32WindowOwner;
			ConfigLoad();

            OpenDictionary();

			// アンコちゃんからのイベント（他のイベントは随時追加してください）
			this._host.Initialized += new EventHandler(_host_Initialized);
			this._host.ConnectedServer += new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ConnectedServer);
			this._host.ReceiveContentStatus += new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ReceiveContentStatus);
			this._host.ReceiveChat += new EventHandler<ankoPlugin2.ReceiveChatEventArgs>(_host_ReceiveChat);
			this._host.DisconnectedServer += new EventHandler<ankoPlugin2.ConnectStreamEventArgs>(_host_DisconnectedServer);
			this._host.PluginDispose += new EventHandler(_host_PluginDispose);
		}

		private void SampleForm_Load(object sender, EventArgs e) {
			this.TopMost = _hostForm.TopMost;
		}

		private void SampleForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(this.Visible) {
				ConfigSave();
			}

			if(e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}



		#region アンコちゃんイベント処理（基本的にNon Thread Safeと思って実装したほうがいいよ）

		void _host_Initialized(object sender, EventArgs e) {
			this._host.Initialized -= new EventHandler(_host_Initialized);
			// アンコちゃんのフォームが表示されるときに起きるらしい

		}

		void _host_ConnectedServer(object sender, ankoPlugin2.ReceiveContentStatusEventArgs e) {
			// 放送に接続したときに起きる Non Thread Safeのとき有
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ConnectedServer),sender, e);
				return;
			}
			//*/

		}

		void _host_ReceiveContentStatus(object sender, ankoPlugin2.ReceiveContentStatusEventArgs e) {
			// 放送の情報を取得したときに起きる 放送テスト時間のときは1秒毎にこのイベントが起きるので注意！
			// 2.0.35.5以降1秒毎に起きるのかは知りません Non Thread Safeのとき有かも
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ReceiveContentStatus));
				return;
			}
			//*/

		}

		void _host_ReceiveChat(object sender, ankoPlugin2.ReceiveChatEventArgs e) {
			// コメントを受信したときに起きる Non Thread Safeのとき有
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ReceiveChatEventArgs>(_host_ReceiveChat));
				return;
			}
			//*/

		}

		void _host_DisconnectedServer(object sender, ankoPlugin2.ConnectStreamEventArgs e) {
			// 生放送が終わったときに起きる /disconnect は2回くるので注意！
			// アンコちゃんフォームの放送切断・削除ボタンお押したときに起きる（2回目の削除したときに起きるみたい）
			// 2.0.35.5以降どうなってるのかは知りません Non Thread Safeのとき有かも
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ConnectStreamEventArgs>(_host_DisconnectedServer));
				return;
			}
			//*/

		}

		void _host_PluginDispose(object sender, EventArgs e) {
			this._host.ConnectedServer -= new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ConnectedServer);
			this._host.ReceiveContentStatus -= new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ReceiveContentStatus);
			this._host.ReceiveChat -= new EventHandler<ankoPlugin2.ReceiveChatEventArgs>(_host_ReceiveChat);
			this._host.DisconnectedServer -= new EventHandler<ankoPlugin2.ConnectStreamEventArgs>(_host_DisconnectedServer);
			this._host.PluginDispose -= new EventHandler(_host_PluginDispose);
			// アンコちゃんが終了するときに起きる IDisposable実装みたいな処理をするといいのかも

		}

		#endregion



		#region 設定値の処理（今となっては古い形式、現在ならアプリケーション構成ファイルでしょうか）

		/// <summary>
		/// フォームのコントロールの状態を設定値として得る
		/// </summary>
		/// <returns></returns>
		private Config GetConfigData() {
			if(this.InvokeRequired) {
				return (Config)Invoke(new Func<Config>(GetConfigData));
			}

			// 以下追加した変数に代入
            _configData.boyomichanDictionaryFilePath = label_boyomiFilePath.Text;

			return _configData;
		}

		/// <summary>
		/// 設定値保存ファイルのパスを取得
		/// </summary>
		/// <returns></returns>
		private string GetConfigXmlPath() {
			return Path.Combine(_host.ApplicationDataFolder, this.GetType().Namespace + ".xml");
		}

		/// <summary>
		/// 設定値をファイルから読み込む
		/// </summary>
		/// <returns></returns>
		private bool ConfigLoad() {
			bool result = false;
			Config configData = new Config();

			// 設定値の読込
			string configPath = GetConfigXmlPath();
			if(File.Exists(configPath)) {
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				try {
					using(FileStream fs = new FileStream(configPath, FileMode.Open)) {
						configData = (Config)serializer.Deserialize(fs);
						result = true;
						fs.Close();
					}
				}
				catch {
					result = false;
				}
			}
			else {
				result = false;
			}

			// 設定値の復元
			if(result) {
				this.Size = new Size(configData.windowWidth, configData.windowHeight);
			}

			if(configData.locationX < -this.Size.Width || Screen.GetBounds(this).Width < configData.locationX) {
				if(configData.locationY < 0 || Screen.GetBounds(this).Height < configData.locationY) {
					this.DesktopLocation = new Point(0, 0);
				}
				else {
					this.DesktopLocation = new Point(0, configData.locationY);
				}
			}
			else if(configData.locationY < 0 || Screen.GetBounds(this).Height < configData.locationY) {
				this.DesktopLocation = new Point(configData.locationX, 0);
			}
			else {
				this.DesktopLocation = new Point(configData.locationX, configData.locationY);
			}

			// 以下追加した変数の復元
            label_boyomiFilePath.Text = configData.boyomichanDictionaryFilePath;

			return result;
		}

		/// <summary>
		/// 設定値をファイルに保存する
		/// </summary>
		/// <returns></returns>
		private bool ConfigSave() {

			// 設定値の取得
			Config configData = GetConfigData();

			// ウィンドウ状態
			System.Windows.Forms.FormWindowState state = this.WindowState;
			if(state == FormWindowState.Maximized) {
				this.WindowState = FormWindowState.Normal;
			}
			configData.locationX = this.DesktopLocation.X;
			configData.locationY = this.DesktopLocation.Y;
			configData.windowWidth = this.Size.Width;
			configData.windowHeight = this.Size.Height;
			if(state == FormWindowState.Maximized) {
				this.WindowState = FormWindowState.Maximized;
			}

			// 保存処理
			string configPath = GetConfigXmlPath();
			XmlSerializer serializer = new XmlSerializer(typeof(Config));
			try {
				using(FileStream fs = new FileStream(configPath, FileMode.Create)) {
					serializer.Serialize(fs, configData);
					fs.Close();
				}
			}
			catch {
				return false;
			}

			return true;
		}

		#endregion

        
        private void OpenBoyomichanDictionaryPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "ReplaceWord.dic";
            ofd.Filter = "dicファイル(*.dic)|*.*";
            ofd.Title = "dicファイルを選択してください";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.label_boyomiFilePath.Text = ofd.FileName;
                OpenDictionary();
            }
        }


        /// <summary>
        /// 辞書ファイルを開く
        /// </summary>
        private void OpenDictionary()
        {
           var result = boyomichanDictionary.Open(label_boyomiFilePath.Text);
           if (!result) { label_boyomiFilePath.Text = ""; }
        }
	}
}
