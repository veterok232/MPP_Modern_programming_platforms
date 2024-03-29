﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generators.Interfaces;
using FakerLib.Generators.Service;

namespace FakerLib.Generators.SystemTypesGenerators.ValueTypesGenerators
{
    /// <summary>
    /// DateTimeGenerator object
    /// </summary>
    public class DateTimeGenerator : IGenerator
    {
        /// <summary>
        /// Generate DateTime object
        /// </summary>
        /// <param name="context">GeneratorContext object</param>
        /// <returns>object</returns>
        object IGenerator.Generate(GeneratorContext context)
        {
            int year = context.Randomizer.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = context.Randomizer.Next(1, 13);
            int day = context.Randomizer.Next(1, DateTime.DaysInMonth(year, month) + 1);
            int hour = context.Randomizer.Next(0, 24);
            int minute = context.Randomizer.Next(0, 60);
            int second = context.Randomizer.Next(0, 60);
            int millisecond = context.Randomizer.Next(0, 100);

            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Check the type for generator
        /// </summary>
        /// <param name="type">Type for check</param>
        /// <returns>bool</returns>
        bool IGenerator.isTypeCompatible(Type type)
        {
            return type == typeof(DateTime);
        }
    }
}
