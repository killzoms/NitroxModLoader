using System;
using System.Linq;
using System.Reflection;
using NitroxModLoader.Attributes;

namespace NitroxModLoader
{
    public class NitroxMod
    {
        public ModId ModId;
        public MethodInfo PreInit;
        public MethodInfo Init;
        public MethodInfo PostInit;

        public NitroxMod(Assembly modDll)
        {
            Init = modDll.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(NitroxModAttribute), false).Length > 0)
                      .First();

            PreInit = modDll.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(NitroxModPreInitAttribute), false).Length > 0).FirstOrDefault();

            PostInit = modDll.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(NitroxModPostInitAttribute), false).Length > 0).FirstOrDefault();

            NitroxModAttribute attr = (NitroxModAttribute)Init.GetCustomAttributes(typeof(NitroxModAttribute), false).First();
            ModId = new ModId(attr.Name, attr.Version);
        }
    }
}
