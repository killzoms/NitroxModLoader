using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NitroxModLoader.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class NitroxModPreInitAttribute : Attribute
    {
    }
}
