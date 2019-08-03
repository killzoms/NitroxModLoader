using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using NitroxModLoader.Attributes;

namespace NitroxModLoader
{
    public static class Loader
    {
        public static Dictionary<string, NitroxMod> loadedMods = new Dictionary<string, NitroxMod>();
        private static string ModsDir;

        public static void LoadMods(string modsDir = null)
        {
            if (modsDir == null)
            {
                ModsDir = Path.Combine(Environment.CurrentDirectory, "mods");
            }
            else
            {
                ModsDir = modsDir;
            }

            Assembly[] modAssemblies = Directory.GetDirectories(ModsDir).SelectMany(p => Directory.GetFiles(p, "*.dll")
            .Select(a => Assembly.LoadFrom(a)))
                .Where(a => a.GetTypes()
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(NitroxModAttribute), false).Length > 0).Any()).ToArray();

            foreach (Assembly modAssembly in modAssemblies)
            {
                NitroxMod mod = new NitroxMod(modAssembly);
                loadedMods.Add(mod.ModId.Name, mod);
            }

            PreInit();

            Init();

            PostInit();
        }

        public static void PreInit()
        {
            foreach (NitroxMod mod in loadedMods.Values)
            {
                mod.PreInit?.Invoke(null, null);
            }
        }

        public static void Init()
        {
            foreach (NitroxMod mod in loadedMods.Values)
            {
                mod.Init.Invoke(null, null);
            }
        }

        public static void PostInit()
        {
            foreach (NitroxMod mod in loadedMods.Values)
            {
                mod.PostInit?.Invoke(null, null);
            }
        }
    }
}
