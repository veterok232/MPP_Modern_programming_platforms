﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generators.Service;

namespace FakerLib.Generators.Interfaces
{
    /// <summary>
    /// General interface for generators
    /// </summary>
    public interface IGenerator
    {
        object Generate(GeneratorContext context);
        bool isTypeCompatible(Type type);
    }
}
