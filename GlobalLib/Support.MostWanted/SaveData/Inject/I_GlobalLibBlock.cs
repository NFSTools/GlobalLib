namespace GlobalLib.Support.MostWanted
{
    public static partial class SaveData
    {
        private static unsafe void I_GlobalLibBlock(Database.MostWanted db, System.IO.BinaryWriter bw)
        {
            int colsize = 0;
            int strsize = 0;
            int padding = 0;

            // Collision Block
            var CollisionsUsed = new System.Collections.Generic.List<string>();
            foreach (var info in db.CarTypeInfos)
            {
                if (info.CollisionExternalName == Reflection.BaseArguments.NULL)
                    continue;
                else if (info.CollisionExternalName != info.CollisionInternalName)
                {
                    CollisionsUsed.Add(info.CollisionInternalName);
                    colsize += info.CollisionInternalName.Length + 1;
                }
                else
                {
                    CollisionsUsed.Add(info.CollisionExternalName);
                    colsize += info.CollisionExternalName.Length + 1;
                }
            }

            padding = 0x80 - ((colsize + 0x58) % 0x80);
            if (padding == 0x80) padding = 0;
            var coldata = new byte[0x58];
            fixed (byte* byteptr_t = &coldata[0])
            {
                *(int*)(byteptr_t + 4) = colsize + 0x50 + padding;
                *(uint*)(byteptr_t + 8) = Reflection.ID.Global.GlobalLib;
                string colblock = "Collision Block";
                string LibDescr = "GlobalLib by MaxHwoy " + System.DateTime.Today.ToString("dd-MM-yyyy");
                for (int a1 = 0; a1 < LibDescr.Length; ++a1)
                    *(byteptr_t + 0x10 + a1) = (byte)LibDescr[a1];
                for (int a1 = 0; a1 < colblock.Length; ++a1)
                    *(byteptr_t + 0x30 + a1) = (byte)colblock[a1];
                *(int*)(byteptr_t + 0x50) = CollisionsUsed.Count;
                *(int*)(byteptr_t + 0x54) = colsize;

            }
            bw.Write(coldata);
            for (int a1 = 0; a1 < CollisionsUsed.Count; ++a1)
                bw.Write(CollisionsUsed[a1]);
            for (int a1 = 0; a1 < padding; ++a1)
                bw.Write((byte)0);

            // Raider block
            int stroffset = (int)bw.BaseStream.Position + 8;
            var strdata = new byte[0x58];
            fixed (byte* byteptr_t = &strdata[0])
            {
                *(int*)(byteptr_t + 4) = strsize + 0x50 + padding;
                *(uint*)(byteptr_t + 8) = Reflection.ID.Global.GlobalLib;
                string strblock = "Raider Block";
                string LibDescr = "GlobalLib by MaxHwoy " + System.DateTime.Today.ToString("dd-MM-yyyy");
                for (int a1 = 0; a1 < LibDescr.Length; ++a1)
                    *(byteptr_t + 0x10 + a1) = (byte)LibDescr[a1];
                for (int a1 = 0; a1 < strblock.Length; ++a1)
                    *(byteptr_t + 0x30 + a1) = (byte)strblock[a1];
            }
            bw.Write(strdata);

            int dataoffset = (int)bw.BaseStream.Position;
            foreach (var pair in Core.Map.BinKeys)
            {
                ++strsize;
                bw.Write(pair.Value);
            }
            bw.BaseStream.Position = dataoffset - 8;
            bw.Write(strsize);
            bw.Write((int)bw.BaseStream.Length - dataoffset);

            padding = 0x80 - ((int)bw.BaseStream.Length + 0x40) % 0x80;
            if (padding == 0x80) padding = 0;
            bw.BaseStream.Position = bw.BaseStream.Length;
            for (int a1 = 0; a1 < padding; ++a1)
                bw.Write((byte)0);
            bw.BaseStream.Position = stroffset - 4;
            bw.Write((int)bw.BaseStream.Length - stroffset);
            bw.BaseStream.Position = bw.BaseStream.Length;
        }
    }
}