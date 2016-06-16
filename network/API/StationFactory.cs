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
using NUnit.Framework;
using System;
using System.Collections.Generic;
using models;

namespace network
{
	public class StationFactory : AbstractFactory<Station>
	{
		private static List<Station> _allStations = null;

		public static List<Station> GetAll()
		{
			if(_allStations == null)
			{
				_allStations = load("station");
				foreach(var station in _allStations)
				{
					station.Type = StationTypeFactory.Get(station.Type.id);
					station.Cars = CarFactory.LoadCarsFromStation(station.Cars);
				}
			}
			return _allStations;
		}

		public static Station Get(int id)
		{
			List<Station> all = GetAll();
			foreach(var station in all)
			{
				if(station.id == id)
				{
					return station;
				}
			}
			return null;
		}

		public static Station GetPreFeatched(int id)
		{
			Assert.IsNotNull(_allStations);
			foreach(var station in _allStations)
			{
				if(station.id == id)
				{
					return station;
				}
			}
			return null;
		}

		public static List<Station> LoadStationFromCenter(ControlCenter center)
		{
			List<Station> center_stations = load("control_center/" + center.id + "/station");
			List<Station> return_stations = new List<Station>();
			foreach(var station in center_stations)
			{
				return_stations.Add(Get(station.id));
			}
			return return_stations;
		}
	}
}

