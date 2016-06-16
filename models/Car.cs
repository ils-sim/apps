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
	public class Car
	{
		public Int32 id { get; set; }

		public String Callsign { get; set; }

		public Station Station { get; set; }

		public CarType Type { get; set; }

		public CarUpdate LastUpdate { get; set; }

		public Car(Int32 _id, String _Callsign, Station _Station, CarType _Type)
		{
			id = _id;
			Callsign = _Callsign;
			Station = _Station;
			Type = _Type;
		}

		public override string ToString()
		{
			return string.Format("[Car: id={0}, Callsign={1}, Station={2}, Type={3}, LastUpdate={4}]", id, Callsign, Station, Type, LastUpdate);
		}
	}
}

