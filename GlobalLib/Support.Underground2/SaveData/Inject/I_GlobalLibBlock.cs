using GlobalLib.Reflection.ID;
using GlobalLib.Core;
using System.IO;

namespace GlobalLib.Support.Underground2
{
    public static partial class SaveData
    {
        private static unsafe void I_GlobalLibBlock(BinaryWriter bw)
        {
            int padding = 0x80 - (((int)bw.BaseStream.Length + 0x50) % 0x80);
            if (padding == 0x80) padding = 0;

            var data = new byte[0x50 + padding];
            fixed (byte* byteptr_t = &data[0])
            {
                *(int*)(byteptr_t + 4) = 0x48 + padding;
                *(uint*)(byteptr_t + 8) = Global.GlobalLib;
                string padblock = "Padding Block";
                string LibDescr = Process.Watermark;
                for (int a1 = 0; a1 < LibDescr.Length; ++a1)
                    *(byteptr_t + 0x10 + a1) = (byte)LibDescr[a1];
                for (int a1 = 0; a1 < padblock.Length; ++a1)
                    *(byteptr_t + 0x30 + a1) = (byte)padblock[a1];
            }
            bw.Write(data);
        }
    }
}