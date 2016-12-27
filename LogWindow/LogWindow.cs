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

		public void AddText(string text)
		{
			Gtk.TextIter iter = textview1.Buffer.EndIter;
			text += "\n";
			textview1.Buffer.Insert(ref iter, text);
		}
	}
}

