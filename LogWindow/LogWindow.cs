using System;

namespace LogWindow
{
	public partial class LogWindow : Gtk.Window
	{
		public LogWindow() :
			base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
	}
}

