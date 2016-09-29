using System;
using Gtk;

namespace client
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();
			MainWindow win = new MainWindow();
			win.Show();
			Application.Run();

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
	}
}
