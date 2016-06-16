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
	public class CarStatusFactory : AbstractFactory<CarStatus>
	{
		private static List<CarStatus> _allStatus = null;

		public static List<CarStatus> GetAll()
		{
			if(_allStatus == null)
			{
				_allStatus = load("car/status");
			}
			return _allStatus;
		}

		public static CarStatus Get(int id)
		{
			List<CarStatus> _all = GetAll();
			foreach(var _status in _all)
			{
				if(_status.id == id)
				{
					return _status;
				}
			}
			return null;
		}
	}
}

