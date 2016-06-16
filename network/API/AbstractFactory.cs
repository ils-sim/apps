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
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace network
{
	public class AbstractFactory<T>
	{
		public AbstractFactory()
		{
		}

		public static string Protocol = "http";
		public static string Server = "localhost";
		//public static string Server = "api.ils-sim.org";

		public static List<T> load(string url)
		{
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Protocol + "://" + Server + "/" + url);

			request.Method = "GET";
			request.Accept = "application/json";

			try
			{
				WebResponse response = request.GetResponse();
				using(StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					string responseContend = reader.ReadToEnd();
					List<T> objectResponse = JsonConvert.DeserializeObject<List<T>>(responseContend);
					return objectResponse;
				}
			} catch(WebException exception)
			{
				using(var reader = new StreamReader(exception.Response.GetResponseStream()))
				{
					string responseContent = reader.ReadToEnd();
					Console.WriteLine(responseContent);
					return null;
				}
			}
		}

		public static T load(string url, Int32 id)
		{
			List<T> elements = load(url + "/" + id);
			if(elements.Count != 0)
			{
				return elements[0];
			}
			return default(T);
		}
	}
}

