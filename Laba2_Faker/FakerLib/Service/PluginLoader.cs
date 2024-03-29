﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using FakerLib.Generators.Interfaces;

namespace FakerLib.Service
{
    /// <summary>
    /// Class for loading plugins with generators
    /// </summary>
    public class PluginLoader
    {
        //Path to plugins folder
        private readonly string pluginFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Plugins\\bin");

        /// <summary>
        /// Load plugins from plugins folder
        /// </summary>
        /// <returns>List<IGenerator></returns>
        public List<IGenerator> LoadPlugins()
        {
            List<IGenerator> pluginList = new List<IGenerator>();

            DirectoryInfo PluginDirectory = new DirectoryInfo(pluginFolderPath);
            if (!PluginDirectory.Exists)
            {
                PluginDirectory.Create();
                return pluginList;
            }

            var pluginFiles = Directory.GetFiles(pluginFolderPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly assembly = Assembly.LoadFrom(file);
                var types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    Type[] typeInterfaces = type.GetInterfaces();

                    foreach (Type typeInterface in typeInterfaces)
                    {
                        if (typeInterface.FullName == typeof(IGenerator).FullName)
                        {
                            var plugin = assembly.CreateInstance(type.FullName) as IGenerator;
                            pluginList.Add(plugin);
                        }
                    }
                }
            }
            return pluginList;
        }
    }
}
