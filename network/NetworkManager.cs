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
using models;

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

		//public delegate void CallAcceptedEventHandler(CallAccept package);
		//public event CallAcceptedEventHandler onCallAccepted;

		public delegate void CaseEndEventHandler(Emergency emerg);
		public event CaseEndEventHandler onCaseEnd;

		public delegate void CaseNewEventHandler(Emergency emerg);
		public event CaseNewEventHandler onCaseNew;

		public delegate void CaseUpdateEventHandler(Emergency emerg);
		public event CaseUpdateEventHandler onCaseUpdate;

		public delegate void EmergEndEventHandler(Emergency emerg);
		public event EmergEndEventHandler onEmergEnd;

		public delegate void EmergNewEventHandler(Emergency emerg);
		public event EmergNewEventHandler onEmergNew;

		public delegate void EmergUpdateEventHandler(Emergency emerg);
		public event EmergUpdateEventHandler onEmergUpdate;

		public delegate void MsgChatEventHandler(User sender, String message);
		public event MsgChatEventHandler onMsgChat;

		public delegate void MsgPrivateEventHandler(User sender, String message);
		public event MsgPrivateEventHandler onMsgPrivate;

		public delegate void MsgWallEventHandler(User sender, String message);
		public event MsgWallEventHandler onMsgWall;

		public delegate void QuitEventHandler();
		public event QuitEventHandler onQuit;

		public delegate void ServerWallEventHandler(String message);
		public event ServerWallEventHandler onServerWall;

		//public delegate void UserListAnswerEventHandler(UserListAnswer package);
		//public event UserListAnswerEventHandler onUserListAnswer;

		public delegate void UserLoginAnswerEventHandler(bool loginwasok);
		public event UserLoginAnswerEventHandler onUserLoginAnswer;

		public delegate void VehicleAlarmEventHandler(Car car);
		public event VehicleAlarmEventHandler onVehicleAlarm;

		public delegate void VehicleMsgEventHandler(Car car, String message);
		public event VehicleMsgEventHandler onVehicleMsg;

		public delegate void VehiclePositionEventHandler(Car car, CarPosition position);
		public event VehiclePositionEventHandler onVehiclePosition;

		public delegate void VehicleStornoEventHandler(Car car);
		public event VehicleStornoEventHandler onVehicleStorno;

		public delegate void VehicleUpdateEventHandler(Car car);
		public event VehicleUpdateEventHandler onVehicleUpdate;

		private void PackageReceive(Protocol package)
		{
			Console.WriteLine(package.ToString());
			switch(package.Type)
			{
			/*case Protocol.Types.Type.CallAccepted:
				if(onCallAccepted != null)
					onCallAccepted(package.CallAccepted);
				break;*/
			case Protocol.Types.Type.CaseEnd:
				if(onCaseEnd != null)
					onCaseEnd(package.CaseEnd);
				break;
			case Protocol.Types.Type.CaseNew:
				if(onCaseNew != null)
					onCaseNew(package.CaseNew);
				break;
			case Protocol.Types.Type.CaseUpdate:
				if(onCaseUpdate != null)
					onCaseNew(package.CaseNew);
				break;
			case Protocol.Types.Type.EmergEnd:
				if(onEmergEnd != null)
					onEmergEnd(package.EmergEnd);
				break;
			case Protocol.Types.Type.EmergNew:
				if(onEmergNew != null)
					onEmergNew(package.EmergNew);
				break;
			case Protocol.Types.Type.EmergUpdate:
				if(onEmergUpdate != null)
					onEmergUpdate(package.EmergUpdate);
				break;
			case Protocol.Types.Type.MsgChat:
				if(onMsgChat != null)
					onMsgChat(null, package.MsgChat.NewMessage);
				break;
			case Protocol.Types.Type.MsgPrivate:
				if(onMsgPrivate != null)
					onMsgPrivate(null, package.MsgPrivate.NewMessage);
				break;
			case Protocol.Types.Type.MsgWall:
				if(onMsgWall != null)
					onMsgWall(null, package.MsgWall.NewMessage);
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
					onUserLoginAnswer(package.UserLoginAnswer.Servertime != null);
				break;
			case Protocol.Types.Type.VehicleAlarm:
				if(onVehicleAlarm != null)
					onVehicleAlarm(CarFactory.Get(package.VehicleAlarm.IdVehicle), null);
				break;
			case Protocol.Types.Type.VehicleMsg:
				if(onVehicleMsg != null)
					onVehicleMsg(package.VehicleMsg);
				break;
			case Protocol.Types.Type.VehiclePosition:
				if(onVehiclePosition != null)
					onVehiclePosition(package.VehiclePosition);
				break;
			case Protocol.Types.Type.VehicleStorno:
				if(onVehicleStorno != null)
					onVehicleStorno(package.VehicleStornno);
				break;
			case Protocol.Types.Type.VehicleUpdate:
				if(onVehicleUpdate != null)
					onVehicleUpdate(package.VehicleUpdate);
				break;
			}
		}
	}
}

