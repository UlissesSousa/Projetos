using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ServiceNamespace.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("ServiceNamespace.Api"),
                Assembly.Load("ServiceNamespace.Application"),
                Assembly.Load("ServiceNamespace.Domain"),
                Assembly.Load("ServiceNamespace.Domain.Core"),
                Assembly.Load("ServiceNamespace.Infrastructure"),
                Assembly.Load("ServiceNamespace.CrossCutting")
            };
        }
    }
}
