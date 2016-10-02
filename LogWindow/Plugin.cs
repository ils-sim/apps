using System;
using plugins;

namespace LogWindow
{
	public class Plugin : PluginInterface
	{
		public string PluginName { get { return "LogWindow"; } }

		private Gtk.Window mPluginWindow = null;
		public Gtk.Window PluginWindow {
			get {
				if(mPluginWindow == null)
					mPluginWindow = new LogWindow();
				return mPluginWindow;
			}
		}
	}
}

