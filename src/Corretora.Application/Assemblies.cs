using System;
using System.Reflection;

namespace Corretora.Application
{
    public class Assemblies
    {
        public static Assembly[] Value => AppDomain.CurrentDomain.GetAssemblies();
    }
}
