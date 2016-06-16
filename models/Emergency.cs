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
	public class Emergency
	{
		public Int32 id { get; set; }

		public String City { get; set; }

		public String Street { get; set; }

		public Int32 StreetNumber { get; set; }

		public Point Position { get; set; }

		DateTime CallTime { get; set; }

		ControlCenter Center { get; set; }

		DateTime EndTime { get; set; }

		public Emergency(Int32 _id, String _City, String _Street, Int32 _StreetNumber, Point _Position,
		                 DateTime _CallTime, DateTime _EndTime, ControlCenter _Center)
		{
			id = _id;
			City = _City;
			Street = _Street;
			StreetNumber = _StreetNumber;
			Position = _Position;
			CallTime = _CallTime;
			EndTime = _EndTime;
			Center = _Center;
		}

		public override string ToString()
		{
			return string.Format("[Emergency: id={0}, City={1}, Street={2}, StreetNumber={3}, Position={4}]", id, City, Street, StreetNumber, Position);
		}
	}
}

