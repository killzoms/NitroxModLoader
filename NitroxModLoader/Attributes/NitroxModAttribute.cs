using System;

namespace NitroxModLoader.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class NitroxModAttribute : Attribute
    {
        public string Name;
        public string Version;

        public NitroxModAttribute(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
