using GlobalLib.Core;
using GlobalLib.Support.Underground2.Class;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Get the material name, initialize its class and inject into Vector.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of material block in Global data.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_Material(byte* byteptr_t, Database.Underground2 db)
        {
            // Get collection name of the material, starts at 0x14
            string CName = ScriptX.NullTerminatedString(byteptr_t + 0x1C, 0x1C);
            CName = Resolve.GetPathFromCollection(CName);
            Resolve.GetWindowTintString(CName);
            Map.BinKeys[Bin.Hash(CName)] = CName;

            var Class = new Material((IntPtr)byteptr_t, CName, db);
            db.Materials.Collections.Add(Class);
        }
    }
}