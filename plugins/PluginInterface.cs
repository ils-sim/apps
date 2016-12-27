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

namespace plugins
{
	public interface PluginInterface
	{
		string PluginName { get; }

		Gtk.Window PluginWindow { get; }

		void CallAcceptedEventHandler(models.Emergency emerg, models.User user);
		void CaseEndEventHandler(models.Emergency emerg);
		void CaseNewEventHandler(models.Emergency emerg);
		void CaseUpdateEventHandler(models.Emergency emerg);
		void EmergEndEventHandler(models.Emergency emerg);
		void EmergNewEventHandler(models.Emergency emerg);
		void EmergUpdateEventHandler(models.Emergency emerg);
		void MsgChatEventHandler(models.User sender, String message);
		void MsgPrivateEventHandler(models.User sender, String message);
		void MsgWallEventHandler(models.User sender, String message);
		void QuitEventHandler();
		void ServerWallEventHandler(String message);
		void UserListAnswerEventHandler(List<models.User> users);
		void UserLoginAnswerEventHandler(Int32 servertime);
		void VehicleAlarmEventHandler(models.Car car);
		void VehicleMsgEventHandler(models.Car car, String message);
		void VehiclePositionEventHandler(models.Car car, models.CarPosition position);
		void VehicleStornoEventHandler(models.Car car);
		void VehicleUpdateEventHandler(models.Car car);
	}
}

