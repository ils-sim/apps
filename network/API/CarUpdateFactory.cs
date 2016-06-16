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
	public class CarUpdateFactory : AbstractFactory<CarUpdate>
	{
		public static CarUpdate Get(Car car)
		{
			List<CarUpdate> updates = load("car/" + car.id + "/update");
			if(updates.Count == 0)
			{
				return null;
			}
			CarUpdate update = updates[0];
			update.Status = CarStatusFactory.Get(update.Status.id);
			//update.Emergency = Eme
			// add position data and the rest...
			return update;
		}
	}
}

