using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        private static bool LibColBlockExists = false;

        /// <summary>
        /// Loads GlobalB file and disassembles its blocks
        /// </summary>
        /// <param name="GlobalB_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalB(string GlobalB_dir, ref Database.Underground2 db)
        {
            LibColBlockExists = false;
            GlobalB_dir += @"\GLOBAL\GlobalB.lzc";
            byte[] GlobalBLZC;

            // Get everything from GlobalB.lzc
            try
            {
                GlobalBLZC = File.ReadAllBytes(GlobalB_dir);
                Utils.Log.Write("Reading data from GlobalB.lzc...");
            }
            catch (Exception) // If GlobalB.lzc is opened in editing mode in another program
            {
                if (Core.Process.MessageShow)
                    MessageBox.Show("Unable to read GlobalB.lzc file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
                else
                    Console.WriteLine("Unable to read GlobalB.lzc file.");
                return false;
            }

            // Decompress if compressed
            GlobalBLZC = Utils.JDLZ.Decompress(GlobalBLZC);

            // Use pointers to speed up process
            fixed (byte* byteptr_t = &GlobalBLZC[0])
            {
                uint offset = 0; // to calculate current offset
                uint ID = 0; // to get the ID of the block being read
                uint size = 0; // to get the size of the block being read

                uint proff = 0; // offset of the preset rides block
                uint prsize = 0; // size of the preset rides block

                uint cpoff = 0; // offset of the carparts block
                uint cpsize = 0; // size of the carparts block

                uint cooff = 0; // offset of the collision block
                uint cosize = 0; // size of the collision block

                while (offset < GlobalBLZC.Length)
                {
                    ID = *(uint*)(byteptr_t + offset); // read ID
                    size = *(uint*)(byteptr_t + offset + 4); // read size
                    if (offset + size > GlobalBLZC.Length)
                    {
                        if (Core.Process.MessageShow)
                            MessageBox.Show("GlobalB: unable to read beyond the stream.", "Failure");
                        else
                            Console.WriteLine("GlobalB: unable to read beyond the stream.");
                        return false;
                    }

                    switch (ID)
                    {
                        //case 0:
                        //    if (*(uint*)(byteptr_t + offset + 8) == Reflection.ID.Global.GlobalLib)
                        //        E_GlobalLibBlock(byteptr_t + offset, size + 8);
                        //    break;
                        //
                        //case Reflection.ID.Global.Materials:
                        //    E_Material(byteptr_t + offset, ref db);
                        //    break;

                        case Reflection.ID.Global.TPKBlocks:
                            int count = db.TPKBlocks.Count;
                            db.TPKBlocks.Add(new Class.TPKBlock(byteptr_t + offset, count, db));
                            break;

                        case Reflection.ID.Global.CarTypeInfo:
                            E_CarTypeInfo(byteptr_t + offset + 8, size, ref db);
                            break;

                        //case Reflection.ID.Global.PresetRides:
                        //    proff = offset + 8;
                        //    prsize = size;
                        //    break;

                        case Reflection.ID.Global.CarParts:
                            cpoff = offset + 8;
                            cpsize = size;
                            break;

                        //case Reflection.ID.Global.SlotTypes:
                        //    E_SlotType(byteptr_t + offset, size + 8, ref db);
                        //    break;
                        //
                        //case Reflection.ID.Global.Collisions:
                        //    cooff = offset + 8;
                        //    cosize = size;
                        //    break;

                        case Reflection.ID.Global.FEngFiles:
                        case Reflection.ID.Global.FNGCompress:
                            E_FNGroup(byteptr_t + offset, size + 8, ref db);
                            break;

                        default:
                            break;
                    }
                    offset += 8 + size; // advance in offset
                }

                // CarParts and Collisions blocks are the last ones to disassemble
                E_CarParts(byteptr_t + cpoff, cpsize, ref db);
                //E_Collisions(byteptr_t + cooff, cosize, ref db);
                //E_PresetRides(byteptr_t + proff, prsize, ref db);
            }

            // Disperse spoilers across cartypeinfo
            //E_Spoilers(db);
            return true;
        }
    }
}
