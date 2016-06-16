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
	public class Point
	{
		public Double Latitude { get; set; }

		public Double Longitude { get; set; }

		public Point(Double _Latitude, Double _Longitude)
		{
			Latitude = _Latitude;
			Longitude = _Longitude;
		}

		public Point()
		{
			Latitude = 0.0;
			Longitude = 0.0;
		}

		public Boolean isZerro()
		{
			return Latitude == 0.0 && Longitude == 0.0;
		}

		public void setZerro()
		{
			Latitude = 0.0;
			Longitude = 0.0;
		}

		public override string ToString()
		{
			return string.Format("[Point: Latitude={0}, Longitude={1}]", Latitude, Longitude);
		}
	}
}

