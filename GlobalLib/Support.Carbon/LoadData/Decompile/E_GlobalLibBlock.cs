﻿using GlobalLib.Core;
using GlobalLib.Utils;

namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        private static unsafe void E_GlobalLibBlock(byte* byteptr_t, uint length)
        {
            int off = 0x50; // offset in data
            int num = 0; // number of strings
            int len = 0; // length of strings

            string blocktype = ScriptX.NullTerminatedString(byteptr_t + 0x30, 0x20);

            switch (blocktype)
            {
                case "Padding Block":
                    return;

                case "Collision Block":
                    num = *(int*)(byteptr_t + off); // get number of strings allocated
                    len = *(int*)(byteptr_t + off + 4); // get total length of characters
                    off += 8; // move last time
                    Map.CollisionMap.Clear(); // clear collision map
                    while (len > 0 && num > 0)
                    {
                        string CName = "";
                        int numbytes = *(byteptr_t + off); // length of the string
                        for (int a1 = off + 1; a1 < off + 1 + numbytes; ++a1)
                            CName += ((char)*(byteptr_t + a1)).ToString();
                        Map.CollisionMap[Vlt.Hash(CName)] = CName;
                        --num;
                        len -= numbytes + 1;
                        off += numbytes + 1;
                    }
                    LibColBlockExists = true;
                    break;

                case "Raider Block": // suspended, no longer supported
                    num = *(int*)(byteptr_t + off); // get number of strings allocated
                    len = *(int*)(byteptr_t + off + 4); // get total length of characters
                    off += 8; // move last time
                    while (len > 0 && num > 0)
                    {
                        string CName = "";
                        int numbytes = *(byteptr_t + off); // length of the string
                        for (int a1 = off + 1; a1 < off + 1 + numbytes; ++a1)
                            CName += ((char)*(byteptr_t + a1)).ToString();
                        Map.BinKeys[Bin.Hash(CName)] = CName;
                        --num;
                        len -= numbytes + 1;
                        off += numbytes + 1;
                    }
                    break;

                default:
                    break;
            }
        }
    }
}