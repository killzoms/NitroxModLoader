using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NitroxModLoader
{
    public class ModId
    {
        public string Name;
        public string Version;

        public ModId(string name, string version)
        {
            this.Version = version;
            this.Name = name;
        }
    }
}
