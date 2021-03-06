﻿using GlobalLib.Reflection;
using GlobalLib.Reflection.ID;
using GlobalLib.Core;
using System.Collections.Generic;
using System.IO;

namespace GlobalLib.Support.Carbon
{
    public static partial class SaveData
    {
        private static unsafe void I_CollisionLibBlock(Database.Carbon db, BinaryWriter bw)
        {
            int colsize = 0;
            int padding = 0;

            // Collision Block
            var CollisionsUsed = new List<string>();
            foreach (var info in db.CarTypeInfos.Collections)
            {
                if (info.CollisionExternalName == BaseArguments.NULL)
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

            padding = 0x80 - (((int)bw.BaseStream.Length + colsize + 0x70) % 0x80);
            if (padding == 0x80) padding = 0;
            var coldata = new byte[0x58];
            fixed (byte* byteptr_t = &coldata[0])
            {
                *(int*)(byteptr_t + 4) = colsize + 0x50 + padding;
                *(uint*)(byteptr_t + 8) = Global.GlobalLib;
                string colblock = "Collision Block";
                string LibDescr = Process.Watermark;
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
        }
    }
}