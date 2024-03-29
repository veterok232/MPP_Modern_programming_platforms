﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generators.Interfaces;
using FakerLib.Generators.Service;

namespace FakerLib.Generators.SystemTypesGenerators.ReferenceTypesGenerators
{
    /// <summary>
    /// StringGenerator class
    /// </summary>
    public class StringGenerator : IGenerator
    {
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int MIN_LENGTH = 1;
        private const int MAX_LENGTH = 100;

        /// <summary>
        /// Generate string object
        /// </summary>
        /// <param name="context">GeneratorContext object</param>
        /// <returns>object</returns>
        object IGenerator.Generate(GeneratorContext context)
        {
            return new string(Enumerable.Repeat(ALPHABET, context.Randomizer.Next(MIN_LENGTH, MAX_LENGTH))
              .Select(s => s[context.Randomizer.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Check the type for generator
        /// </summary>
        /// <param name="type">Type for check</param>
        /// <returns>bool</returns>
        bool IGenerator.isTypeCompatible(Type type)
        {
            return (type == typeof(string));
        }
    }
}
