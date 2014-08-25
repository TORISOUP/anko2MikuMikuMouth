using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anko2SpeachMiku {
	[Serializable()]
	public class Config : IConfig {

		#region IConfigの実装

		public int locationX { get; set; }
		public int locationY { get; set; }
		public int windowWidth { get; set; }
		public int windowHeight { get; set; }
		
		#endregion

		// 以下保存したい変数
		public bool alwaysRun { get; set; }

		public Config() {
			this.locationX = 0;
			this.locationY = 0;
			this.windowWidth = 640;
			this.windowHeight = 480;

			// 以下保存したい変数の初期化
			alwaysRun = false;

		}

	}
}
