using System;
using System.Collections.Generic;
using Gtk;
using client;
using plugins;

public partial class MainWindow: Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
	}
	
	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnButton3Clicked(object sender, EventArgs e)
	{
		Console.WriteLine("lets load the plugins!");
		ICollection<PluginInterface> plugins = GenericPluginLoader<PluginInterface>.LoadPlugins(".");
		foreach(PluginInterface plugin in plugins)
		{
			Console.WriteLine(plugin.PluginName);
			plugin.PluginWindow.Show();
		}
		Console.WriteLine("loaded all plugins!");
	}
}
