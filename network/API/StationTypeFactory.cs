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
	public class StationTypeFactory : AbstractFactory<StationType>
	{
		private static List<StationType> _allTypes = null;

		public static List<StationType> GetAll()
		{
			if(_allTypes == null)
			{
				_allTypes = load("station/type");
			}
			return _allTypes;
		}

		public static StationType Get(int id)
		{
			List<StationType> _all = GetAll();
			foreach(var _type in _all)
			{
				if(_type.id == id)
				{
					return _type;
				}
			}
			return null;
		}
	}
}

