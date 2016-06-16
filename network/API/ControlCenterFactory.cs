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
using models;

namespace network
{
	public class ControlCenterFactory : AbstractFactory<ControlCenter>
	{
		private static List<ControlCenter> _allCenters = null;

		public static List<ControlCenter> GetAll()
		{
			if(_allCenters == null)
			{
				_allCenters = load("control_center");
				foreach(var center in _allCenters)
				{
					center.Stations = StationFactory.LoadStationFromCenter(center);
				}
			}
			return _allCenters;
		}

		public static ControlCenter Get(int id)
		{
			List<ControlCenter> centers = GetAll();
			foreach(var center in centers)
			{
				if(center.id == id)
				{
					return center;
				}
			}
			return null;
		}

		public static List<ControlCenter> GetAllActive()
		{
			List<ControlCenter> active_centers = load("control_center/active");
			List<ControlCenter> return_centers = new List<ControlCenter>();
			foreach(var center in active_centers)
			{
				return_centers.Add(Get(center.id));
			}
			return return_centers;
		}
	}
}

