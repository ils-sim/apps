using System;
using System.Collections.Generic;
using plugins;
using models;

namespace LogWindow
{
	public class Plugin : PluginInterface
	{
		public string PluginName { get { return "LogWindow"; } }

		private LogWindow mPluginWindow = null;
		public Gtk.Window PluginWindow {
			get {
				if(mPluginWindow == null)
					mPluginWindow = new LogWindow();
				return mPluginWindow;
			}
		}
			
		public void CallAcceptedEventHandler(models.Emergency emerg, models.User user)
		{
			mPluginWindow.AddText("CallAcceptedEventHandler: " + emerg.ToString() + user.ToString());
		}

		public void CaseEndEventHandler(models.Emergency emerg)
		{
			mPluginWindow.AddText("CaseEndEventHandler: " + emerg.ToString());
		}

		public void CaseNewEventHandler(models.Emergency emerg)
		{
			mPluginWindow.AddText("CaseNewEventHandler: " + emerg.ToString());
		}

		public void CaseUpdateEventHandler(models.Emergency emerg)
		{
			mPluginWindow.AddText("CaseUpdateEventHandler: " + emerg.ToString());
		}

		public void EmergEndEventHandler(models.Emergency emerg)
		{
			mPluginWindow.AddText("EmergEndEventHandler: " + emerg.ToString());
		}

		public void EmergNewEventHandler(models.Emergency emerg)
		{
			mPluginWindow.AddText("EmergNewEventHandler: " + emerg.ToString());
		}

		public void EmergUpdateEventHandler(models.Emergency emerg)
		{
			mPluginWindow.AddText("EmergUpdateEventHandler: " + emerg.ToString());
		}

		public void MsgChatEventHandler(models.User sender, String message)
		{
			mPluginWindow.AddText("MsgChatEventHandler: " + sender.ToString() + message);
		}

		public void MsgPrivateEventHandler(models.User sender, String message)
		{
			mPluginWindow.AddText("MsgPrivateEventHandler: " + sender.ToString() + message);
		}

		public void MsgWallEventHandler(models.User sender, String message)
		{
			mPluginWindow.AddText("MsgWallEventHandler: " + sender.ToString() + message);
		}

		public void QuitEventHandler()
		{
			mPluginWindow.AddText("QuitEventHandler");
		}

		public void ServerWallEventHandler(String message)
		{
			mPluginWindow.AddText("ServerWallEventHandler: " + message);
		}

		public void UserListAnswerEventHandler(List<models.User> users)
		{
			mPluginWindow.AddText("UserListAnswerEventHandler: " + users.ToString());
		}

		public void UserLoginAnswerEventHandler(Int32 servertime)
		{
			Console.WriteLine("Login is: " + (servertime != 0) + ", with servertime: " + servertime);
			mPluginWindow.AddText("UserLoginAnswerEventHandler: " + servertime);
		}

		public void VehicleAlarmEventHandler(models.Car car)
		{
			mPluginWindow.AddText("VehicleAlarmEventHandler: " + car.ToString());
		}

		public void VehicleMsgEventHandler(models.Car car, String message)
		{
			mPluginWindow.AddText("VehicleMsgEventHandler: " + car.ToString() + message);
		}

		public void VehiclePositionEventHandler(models.Car car, models.CarPosition position)
		{
			mPluginWindow.AddText("VehiclePositionEventHandler: " + car.ToString() + position.ToString());
		}

		public void VehicleStornoEventHandler(models.Car car)
		{
			mPluginWindow.AddText("VehicleStornoEventHandler: " + car.ToString());
		}

		public void VehicleUpdateEventHandler(models.Car car)
		{
			mPluginWindow.AddText("VehicleUpdateEventHandler: " + car.ToString());
		}
	}
}

