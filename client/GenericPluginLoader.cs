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
using System.Reflection;

namespace client
{
	public class GenericPluginLoader<T>
	{
		public static ICollection<T> LoadPlugins(string path)
		{
			string[] dllFileNames = null;

			if(Directory.Exists(path))
			{
				dllFileNames = Directory.GetFiles(path, "*.dll");

				ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
				foreach(string dllFile in dllFileNames)
				{
					AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
					Assembly assembly = Assembly.Load(an);
					assemblies.Add(assembly);
				}

				Type pluginType = typeof(T);
				ICollection<Type> pluginTypes = new List<Type>();
				foreach(Assembly assembly in assemblies)
				{
					if(assembly != null)
					{
						Type[] types = assembly.GetTypes();

						foreach(Type type in types)
						{
							if(type.IsInterface || type.IsAbstract)
							{
								continue;
							}
							else
							{
								if(type.GetInterface(pluginType.FullName) != null)
								{
									pluginTypes.Add(type);
								}
							}
						}
					}
				}

				ICollection<T> plugins = new List<T>(pluginTypes.Count);
				foreach(Type type in pluginTypes)
				{
					T plugin = (T)Activator.CreateInstance(type);
					plugins.Add(plugin);
				}

				return plugins;
			}

			return null;
		}
	}
}

