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
	public class CarFactory : AbstractFactory<Car>
	{
		private static List<Car> _allCars = null;

		public static List<Car> GetAll()
		{
			if(_allCars == null)
			{
				_allCars = load("car");
				foreach(var car in _allCars)
				{
					car.Type = CarTypeFactory.Get(car.Type.id);
					car.Station = StationFactory.GetPreFeatched(car.Station.id);
				}
			}
			return _allCars;
		}

		public static Car Get(int id)
		{
			List<Car> all = GetAll();
			foreach(var car in all)
			{
				if(car.id == id)
				{
					return car;
				}
			}
			return null;
		}

		public static List<Car> LoadCarsFromStation(List<Car> station_cars)
		{
			List<Car> return_cars = new List<Car>();
			foreach(var car in station_cars)
			{
				return_cars.Add(Get(car.id));
			}
			return return_cars;
		}
	}
}

