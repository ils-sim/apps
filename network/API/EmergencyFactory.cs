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
using models;

namespace network
{
	public class EmergencyFactory : AbstractFactory<Emergency>
	{
		private static List<Emergency> _allEmergencies = null;

		public static List<Emergency> GetAll()
		{
			if(_allEmergencies == null)
			{
				_allEmergencies = load("emergency");
			}
			return _allEmergencies;
		}

		public static Emergency Get(int id)
		{
			List<Emergency> all = GetAll();
			foreach(var emergency in all)
			{
				if(emergency.id == id)
				{
					return emergency;
				}
			}
			return null;
		}
	}
}

