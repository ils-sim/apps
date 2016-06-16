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

namespace models
{
	public class Station
	{
		public Int32 id { get; set; }

		public String Name { get; set; }

		public Point Position { get; set; }

		public StationType Type { get; set; }

		public List<Car> Cars { get; set; }

		public Station(Int32 _id, String _Name, Point _Position, StationType _Type, List<Car> _Cars)
		{
			id = _id;
			Name = _Name;
			Position = _Position;
			Type = _Type;
			Cars = _Cars;
		}

		public override string ToString()
		{
			return string.Format("[Station: id={0}, Name={1}, Position={2}, Type={3}, Cars={4}]", id, Name, Position, Type, Cars);
		}
	}
}

