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
using network;
using models;

namespace unittests
{
	[TestFixture()]
	public class FactoryTests
	{
		[Test()]
		public void CarStatusFactoryTest()
		{
			List<CarStatus> status = CarStatusFactory.GetAll();
			Assert.IsNotEmpty(status);
			foreach(var obj in status)
			{
				Console.WriteLine(obj);
			}
			CarStatus elem = CarStatusFactory.Get(1);
			Assert.IsNotNull(elem);
		}

		[Test()]
		public void CarTypeFactoryTest()
		{
			List<CarType> type = CarTypeFactory.GetAll();
			Assert.IsNotEmpty(type);
			foreach(var obj in type)
			{
				Console.WriteLine(obj);
			}
			CarType elem = CarTypeFactory.Get(1);
			Assert.IsNotNull(elem);
		}

		[Test()]
		public void StationTypeFactoryTest()
		{
			List<StationType> type = StationTypeFactory.GetAll();
			Assert.IsNotEmpty(type);
			foreach(var obj in type)
			{
				Console.WriteLine(obj);
			}
			StationType elem = StationTypeFactory.Get(1);
			Assert.IsNotNull(elem);
		}

		[Test()]
		public void ControlCenterFactoryTest()
		{
			Console.WriteLine("all:");
			List<ControlCenter> centers = ControlCenterFactory.GetAll();
			Assert.IsNotEmpty(centers);
			foreach(var obj in centers)
			{
				Console.WriteLine(obj);
			}

			Console.WriteLine("ID: 11");
			ControlCenter elem = ControlCenterFactory.Get(11);
			Console.WriteLine(elem);
			Assert.IsNotNull(elem);

			Console.WriteLine("all active:");
			List<ControlCenter> active = ControlCenterFactory.GetAllActive();
			Assert.IsNotEmpty(active);
			foreach(var obj in active)
			{
				Console.WriteLine(obj);
			}
		}

		[Test()]
		public void StationFactoryTest()
		{
			Console.WriteLine("all:");
			List<Station> stations = StationFactory.GetAll();
			Assert.IsNotEmpty(stations);
			foreach(var obj in stations)
			{
				Console.WriteLine(obj);
			}

			Console.WriteLine("ID: 4");
			Station elem = StationFactory.Get(4);
			Console.WriteLine(elem);
			Assert.IsNotNull(elem);
		}

		[Test()]
		public void CarFactoryTest()
		{
			StationFactory.GetAll();
			Console.WriteLine("all:");
			List<Car> cars = CarFactory.GetAll();
			Assert.IsNotEmpty(cars);
			foreach(var obj in cars)
			{
				Console.WriteLine(obj);
			}

			Console.WriteLine("ID: 1");
			Car elem = CarFactory.Get(1);
			Console.WriteLine(elem);
			Assert.IsNotNull(elem);
		}

		[Test()]
		public void CarUpdateTest()
		{
			StationFactory.GetAll();
			Car car = CarFactory.Get(1);
			Console.WriteLine(car);
			CarUpdate update = CarUpdateFactory.Get(car);
			Console.WriteLine(update);
			Assert.IsNotNull(update);
		}
	}
}

