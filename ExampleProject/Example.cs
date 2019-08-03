using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NitroxModLoader.Attributes;

namespace ExampleProject
{
    public static class Example
    {
        [NitroxMod("Example", "0.1")]
        public static void Init()
        {
            Console.WriteLine("Loaded");
        }
        
        [NitroxModPreInit]
        public static void PreInit()
        {
            Console.WriteLine("Pre-Loaded");
        }

        [NitroxModPostInit]
        public static void PostInit()
        {
            Console.WriteLine("Post-Loaded");
        }
    }
}
