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

namespace models
{
	public class CarUpdate
	{
		public DateTime LastUpdate { get; set; }

		public DateTime time { set { LastUpdate = value; } }

		public CarStatus Status { get; set; }

		public Point GoalPosition { get; set; }

		public Point goal{ set { GoalPosition = value; } }

		public Emergency Emergency { get; set; }
		//public Patient Patient { get; set; }
		public Boolean BlueLight { get; set; }

		public Boolean blue_light { set { BlueLight = value; } }

		public Boolean isServerStatus { get; set; }

		public Boolean is_server_status { set { isServerStatus = value; } }
		//public User User { get; set; }

		public CarUpdate(DateTime _LastUpdate, CarStatus _Status, Point _CurrentPosition, Point _GoalPosition,
		                 Emergency _Emergency/*, Patient _Patient*/, Boolean _BlueLight, Boolean _isServerStatus/*, User _User*/)
		{
			LastUpdate = _LastUpdate;
			Status = _Status;
			GoalPosition = _GoalPosition;
			Emergency = _Emergency;
			//Patient = _Patient;
			BlueLight = _BlueLight;
			isServerStatus = _isServerStatus;
			//User = _User;
		}

		public override string ToString()
		{
			return string.Format("[CarUpdate: LastUpdate={0}, Status={1}, GoalPosition={2}, Emergency={3}, BlueLight={4}, isServerStatus={5}]", LastUpdate, Status, GoalPosition, Emergency, BlueLight, isServerStatus);
		}
	}
}

