using System;
using System.Collections.Generic;
using Gtk;
using client;
using plugins;
using network;

public partial class MainWindow: Gtk.Window
{
	NetworkManager network;
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		StationFactory.GetAll();

		//network = new NetworkManager("127.0.0.1", 1244);
		network = new NetworkManager("148.251.206.227", 1244);
		LoadPlugins();

		System.Threading.Thread.Sleep(1000);

		UserLogin login = new UserLogin();
		login.Uid = 268369923;
		login.Password = "ZumTesten";
		login.ControlCenter = 1;
		Protocol package = new Protocol();
		package.Type = Protocol.Types.Type.UserLogin;
		package.UserLogin = login;
		network.client.Send(package);
	}
	
	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	void connectPlugin(PluginInterface plugin)
	{
		network.onCallAccepted += new NetworkManager.CallAcceptedEventHandler(plugin.CallAcceptedEventHandler);
		network.onCaseEnd += new NetworkManager.CaseEndEventHandler(plugin.CaseEndEventHandler);
		network.onCaseNew += new NetworkManager.CaseNewEventHandler(plugin.CaseNewEventHandler);
		network.onCaseUpdate += new NetworkManager.CaseUpdateEventHandler(plugin.CaseUpdateEventHandler);
		network.onEmergEnd += new NetworkManager.EmergEndEventHandler(plugin.EmergEndEventHandler);
		network.onEmergNew += new NetworkManager.EmergNewEventHandler(plugin.EmergNewEventHandler);
		network.onEmergUpdate += new NetworkManager.EmergUpdateEventHandler(plugin.EmergUpdateEventHandler);
		network.onMsgChat += new NetworkManager.MsgChatEventHandler(plugin.MsgChatEventHandler);
		network.onMsgPrivate += new NetworkManager.MsgPrivateEventHandler(plugin.MsgPrivateEventHandler);
		network.onMsgWall += new NetworkManager.MsgWallEventHandler(plugin.MsgWallEventHandler);
		network.onQuit += new NetworkManager.QuitEventHandler(plugin.QuitEventHandler);
		network.onServerWall += new NetworkManager.ServerWallEventHandler(plugin.ServerWallEventHandler);
		network.onUserListAnswer += new NetworkManager.UserListAnswerEventHandler(plugin.UserListAnswerEventHandler);
		network.onUserLoginAnswer += new NetworkManager.UserLoginAnswerEventHandler(plugin.UserLoginAnswerEventHandler);
		network.onVehicleAlarm += new NetworkManager.VehicleAlarmEventHandler(plugin.VehicleAlarmEventHandler);
		network.onVehicleMsg += new NetworkManager.VehicleMsgEventHandler(plugin.VehicleMsgEventHandler);
		network.onVehiclePosition += new NetworkManager.VehiclePositionEventHandler(plugin.VehiclePositionEventHandler);
		network.onVehicleStorno += new NetworkManager.VehicleStornoEventHandler(plugin.VehicleStornoEventHandler);
		network.onVehicleUpdate += new NetworkManager.VehicleUpdateEventHandler(plugin.VehicleUpdateEventHandler);
	}

	Dictionary<string, PluginInterface> Plugins = new Dictionary<string, PluginInterface>();

	public void LoadPlugins()
	{
		Console.WriteLine("lets load the plugins!");
		hbox3.Forall(hbox3.Remove);
		Plugins = new Dictionary<string, PluginInterface>();
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
			connectPlugin(plugin);
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

	protected void OnCloseActionActivated(object sender, EventArgs e)
	{
		Application.Quit();
	}

	protected void OnReloadActionActivated(object sender, EventArgs e)
	{
		LoadPlugins();
	}
}
