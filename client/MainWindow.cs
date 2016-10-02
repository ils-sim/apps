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
		LoadPlugins();
	}
	
	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnButton3Clicked(object sender, EventArgs e)
	{
		LoadPlugins();
	}

	Dictionary<string, PluginInterface> Plugins = new Dictionary<string, PluginInterface>();

	public void LoadPlugins()
	{
		Console.WriteLine("lets load the plugins!");
		ICollection<PluginInterface> plugins = GenericPluginLoader<PluginInterface>.LoadPlugins(".");
		foreach(PluginInterface plugin in plugins)
		{
			Console.WriteLine(plugin.PluginName);
			if(plugin.PluginWindow != null)
			{
				Console.WriteLine("Plugin has a window...");
				plugin.PluginWindow.HideAll();

				Gtk.Button button = new Gtk.Button();
				button.Name = plugin.PluginName;
				button.Label = plugin.PluginName;
				hbox3.Add(button);
				Gtk.Box.BoxChild box = ((Gtk.Box.BoxChild)(hbox3[button]));
				//box.Position = 1;
				//box.Expand = false;
				//box.Fill = false;
				button.Show();
				button.Clicked += new System.EventHandler(this.ShowPluginWindow);
			} else
			{
				Console.WriteLine("Plugin has no window...");
			}
			Plugins.Add(plugin.PluginName, plugin);
		}
		Console.WriteLine("loaded all plugins!");
	}

	protected void ShowPluginWindow(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		PluginInterface plugin = Plugins[button.Label];
		plugin.PluginWindow.ShowAll();
	}
}
