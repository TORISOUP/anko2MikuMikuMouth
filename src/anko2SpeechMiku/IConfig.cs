using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace anko2SpeachMiku {
	public interface IConfig {
		int locationX { get; set; }
		int locationY { get; set; }
		int windowWidth { get; set; }
		int windowHeight { get; set; }
	}
}
