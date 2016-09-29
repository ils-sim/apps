using System;
using plugins;

namespace LogWindow
{
	public class Plugin : PluginInterface
	{
		public string PluginName { get { return "LogWindow"; } }

		public Gtk.Window PluginWindow { get { return new LogWindow(); } }
	}
}

