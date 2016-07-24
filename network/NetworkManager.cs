/*********************************************************************************************
* 
* ILS-Sim.org Apps
* Copyright (C) 2016  ils-sim.org Team
* 
* This program is free software; you can redistribute it and/or modify it under the terms
* of the GNU General Public License as published by the Free Software Foundation; either
* version 3 of the License, or (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
* without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
* See the GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License along with this
* program; if not, see <http://www.gnu.org/licenses/>.
* 
*********************************************************************************************/
using System;
using System.Collections.Generic;

namespace network
{
	public class NetworkManager
	{
		public NetworkManager(String host, Int32 port)
		{
			TCPClient client = new TCPClient();
			client.Connect(host, port);
			client.onPackageReceive += new TCPClient.ReceivePacketEventHandler(PackageReceive);
		}

		public delegate void CallAcceptedEventHandler(models.Emergency emerg, models.User user);
		public event CallAcceptedEventHandler onCallAccepted;

		public delegate void CaseEndEventHandler(models.Emergency emerg);
		public event CaseEndEventHandler onCaseEnd;

		public delegate void CaseNewEventHandler(models.Emergency emerg);
		public event CaseNewEventHandler onCaseNew;

		public delegate void CaseUpdateEventHandler(models.Emergency emerg);
		public event CaseUpdateEventHandler onCaseUpdate;

		public delegate void EmergEndEventHandler(models.Emergency emerg);
		public event EmergEndEventHandler onEmergEnd;

		public delegate void EmergNewEventHandler(models.Emergency emerg);
		public event EmergNewEventHandler onEmergNew;

		public delegate void EmergUpdateEventHandler(models.Emergency emerg);
		public event EmergUpdateEventHandler onEmergUpdate;

		public delegate void MsgChatEventHandler(models.User sender, String message);
		public event MsgChatEventHandler onMsgChat;

		public delegate void MsgPrivateEventHandler(models.User sender, String message);
		public event MsgPrivateEventHandler onMsgPrivate;

		public delegate void MsgWallEventHandler(models.User sender, String message);
		public event MsgWallEventHandler onMsgWall;

		public delegate void QuitEventHandler();
		public event QuitEventHandler onQuit;

		public delegate void ServerWallEventHandler(String message);
		public event ServerWallEventHandler onServerWall;

		public delegate void UserListAnswerEventHandler(List<models.User> users);
		public event UserListAnswerEventHandler onUserListAnswer;

		public delegate void UserLoginAnswerEventHandler(bool loginwasok);
		public event UserLoginAnswerEventHandler onUserLoginAnswer;

		public delegate void VehicleAlarmEventHandler(models.Car car);
		public event VehicleAlarmEventHandler onVehicleAlarm;

		public delegate void VehicleMsgEventHandler(models.Car car, String message);
		public event VehicleMsgEventHandler onVehicleMsg;

		public delegate void VehiclePositionEventHandler(models.Car car, models.CarPosition position);
		public event VehiclePositionEventHandler onVehiclePosition;

		public delegate void VehicleStornoEventHandler(models.Car car);
		public event VehicleStornoEventHandler onVehicleStorno;

		public delegate void VehicleUpdateEventHandler(models.Car car);
		public event VehicleUpdateEventHandler onVehicleUpdate;

		private void PackageReceive(Protocol package)
		{
			Console.WriteLine(package.ToString());
			switch(package.Type)
			{
			case Protocol.Types.Type.CallAccepted:
				if(onCallAccepted != null)
					onCallAccepted(
						EmergencyFactory.Get(package.CallAccepted.IdEmerg),
						UserFactory.Get(package.CallAccepted.IdReciever));
				break;
			case Protocol.Types.Type.CaseEnd:
				if(onCaseEnd != null)
					onCaseEnd(EmergencyFactory.Get(package.CaseEnd.IdCase));
				break;
			case Protocol.Types.Type.CaseNew:
				if(onCaseNew != null)
					onCaseNew(EmergencyFactory.Get(package.CaseNew.IdCase));
				break;
			case Protocol.Types.Type.CaseUpdate:
				if(onCaseUpdate != null)
					onCaseUpdate(EmergencyFactory.Get(package.CaseUpdate.IdCase));
				break;
			case Protocol.Types.Type.EmergEnd:
				if(onEmergEnd != null)
					onEmergEnd(EmergencyFactory.Get(package.EmergEnd.IdEmerg));
				break;
			case Protocol.Types.Type.EmergNew:
				if(onEmergNew != null)
					onEmergNew(EmergencyFactory.Get(package.EmergNew.IdEmerg));
				break;
			case Protocol.Types.Type.EmergUpdate:
				if(onEmergUpdate != null)
					onEmergUpdate(EmergencyFactory.Get(package.EmergUpdate.IdEmerg));
				break;
			case Protocol.Types.Type.MsgChat:
				if(onMsgChat != null)
					onMsgChat(UserFactory.Get(package.MsgChat.IdSender), package.MsgChat.NewMessage);
				break;
			case Protocol.Types.Type.MsgPrivate:
				if(onMsgPrivate != null)
					onMsgPrivate(UserFactory.Get(package.MsgPrivate.IdSender), package.MsgPrivate.NewMessage);
				break;
			case Protocol.Types.Type.MsgWall:
				if(onMsgWall != null)
					onMsgWall(UserFactory.Get(package.MsgWall.IdSender), package.MsgWall.NewMessage);
				break;
			case Protocol.Types.Type.Quit:
				if(onQuit != null)
					onQuit();
				break;
			case Protocol.Types.Type.ServerWall:
				if(onServerWall != null)
					onServerWall(package.ServerWall.NewMessage);
				break;
			/*case Protocol.Types.Type.UserListAnswer:
				if(onUserListAnswer != null)
					onUserListAnswer(package.UserListAnswer);
				break;*/
			case Protocol.Types.Type.UserLoginAnswer:
				if(onUserLoginAnswer != null)
					onUserLoginAnswer(package.UserLoginAnswer.Servertime != 0);
				break;
			case Protocol.Types.Type.VehicleAlarm:
				if(onVehicleAlarm != null)
					onVehicleAlarm(CarFactory.Get(package.VehicleAlarm.IdVehicle));
				break;
			case Protocol.Types.Type.VehicleMsg:
				if(onVehicleMsg != null)
					onVehicleMsg(CarFactory.Get(package.VehicleMsg.IdVehicle), package.VehicleMsg.NewMessage);
				break;
			case Protocol.Types.Type.VehiclePosition:
				if(onVehiclePosition != null)
					onVehiclePosition(
						CarFactory.Get(package.VehiclePosition.IdVehicle),
						new models.CarPosition(DateTime.Now,
							new models.Point(package.VehiclePosition.Latitude, package.VehiclePosition.Longitude)));
				break;
			case Protocol.Types.Type.VehicleStorno:
				if(onVehicleStorno != null)
					onVehicleStorno(CarFactory.Get(package.VehicleStornno.IdVehicle));
				break;
			case Protocol.Types.Type.VehicleUpdate:
				if(onVehicleUpdate != null)
					onVehicleUpdate(CarFactory.Get(package.VehicleUpdate.IdVehicle));
				break;
			}
		}
	}
}

