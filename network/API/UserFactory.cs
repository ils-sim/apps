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
	public class UserFactory : AbstractFactory<models.User>
	{
		private static List<models.User> _allUsers = null;

		public static List<models.User> GetAll()
		{
			if(_allUsers == null)
			{
				_allUsers = load("user");
			}
			return _allUsers;
		}

		public static models.User Get(int id)
		{
			List<models.User> all = GetAll();
			foreach(var user in all)
			{
				if(user.id == id)
				{
					return user;
				}
			}
			return null;
		}
	}
}

