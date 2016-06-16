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
using network;
using models;

namespace client
{
	class MainClass
	{
		public static void ReceivePacket(Protocol package)
		{
			Console.WriteLine(package.ToString());
		}

		public static void Main(string[] args)
		{


			/*TCPClient client = new TCPClient();
			client.Connect("127.0.0.1", 1244);
			client.ReceivePacket += new TCPClient.ReceivePacketEventHandler(ReceivePacket);

			System.Threading.Thread.Sleep(1000);

			UserLogin login = new UserLogin();
			login.Uid = 268369923;
			login.Password = "ZumTesten";
			login.ControlCenter = 1;
			Protocol package = new Protocol();
			package.Type = Protocol.Types.Type.UserLogin;
			package.UserLogin = login;
			client.Send(package);

			System.Threading.Thread.Sleep(1000);

			EmergNew emerg = new EmergNew();
			emerg.IdEmerg = 1;
			package = new Protocol();
			package.Type = Protocol.Types.Type.EmergNew;
			package.EmergNew = emerg;
			client.Send(package);

			System.Threading.Thread.Sleep(1000);

			VehicleAlarm alarm = new VehicleAlarm();
			alarm.IdVehicle = 2940;
			alarm.IdEmerg = 1;
			alarm.BlueLight = true;
			package = new Protocol();
			package.Type = Protocol.Types.Type.VehicleAlarm;
			package.VehicleAlarm = alarm;
			client.Send(package);

			System.Threading.Thread.Sleep(1000);

			client.Close();*/

			/*StationFactory.GetAll();
			Console.WriteLine("Hello World!");
			List<Car> cars = CarFactory.GetAll();
			foreach(var obj in cars)
			{
				Console.WriteLine(obj);
			}*/

			/*StationFactory.GetAll();
			Car car = CarFactory.Get(2940);
			CarUpdate update = CarUpdateFactory.Get(car);
			List<CarPosition> positions = CarPositionFactory.Get(car);*/
		}

		static void HandleReceivePacketEventHandler(Protocol package)
		{
			
		}
	}
}
