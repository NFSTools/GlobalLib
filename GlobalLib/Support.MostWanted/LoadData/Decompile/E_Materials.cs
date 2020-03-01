namespace GlobalLib.Support.MostWanted
{
    public static partial class LoadData
    {
        /// <summary>
        /// Get the material name, initialize its class and inject into Vector.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the beginning of material block in Global data.</param>
        /// <param name="db">Database to which add classes.</param>
        private static unsafe void E_Material(byte* byteptr_t, Database.MostWanted db)
        {
            // Get collection name of the material, starts at 0x14
            string CName = Utils.ScriptX.NullTerminatedString(byteptr_t + 0x1C, 0x1C);
            CName = Utils.EA.Resolve.GetPathFromCollection(CName);
            Utils.EA.Resolve.GetWindowTintString(CName);
            Core.Map.BinKeys[Utils.Bin.Hash(CName)] = CName;

            var Class = new Class.Material(byteptr_t, CName, db);
            db.Materials.Add(Class);
        }
    }
}