using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.MostWanted
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
        public static unsafe bool LoadGlobalB(string GlobalB_dir, Database.MostWanted db)
        {
            LibColBlockExists = false;
            GlobalB_dir += @"\GLOBAL\GlobalB.lzc";

            // Get everything from GlobalB.lzc
            try
            {
                db._GlobalBLZC = File.ReadAllBytes(GlobalB_dir);
                Utils.Log.Write("Reading data from GlobalB.lzc...");
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                if (Core.Process.MessageShow)
                    MessageBox.Show($"Error occured: {e.Message}", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Console.WriteLine(e.Message);
                return false;
            }

            // Decompress if compressed
            db._GlobalBLZC = Utils.JDLZ.Decompress(db._GlobalBLZC);

            // Use pointers to speed up process
            fixed (byte* byteptr_t = &db._GlobalBLZC[0])
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

                while (offset < db._GlobalBLZC.Length)
                {
                    ID = *(uint*)(byteptr_t + offset); // read ID
                    size = *(uint*)(byteptr_t + offset + 4); // read size
                    if (offset + size > db._GlobalBLZC.Length)
                    {
                        if (Core.Process.MessageShow)
                            MessageBox.Show("GlobalB: unable to read beyond the stream.", "Failure");
                        else
                            Console.WriteLine("GlobalB: unable to read beyond the stream.");
                        return false;
                    }

                    switch (ID)
                    {
                        case 0:
                            if (*(uint*)(byteptr_t + offset + 8) == Reflection.ID.Global.GlobalLib)
                                E_GlobalLibBlock(byteptr_t + offset, size + 8);
                            break;

                        case Reflection.ID.Global.Materials:
                            E_Material(byteptr_t + offset, db);
                            break;

                        case Reflection.ID.Global.TPKBlocks:
                            int count = db.TPKBlocks.Length;
                            db.TPKBlocks.Collections.Add(new Class.TPKBlock(byteptr_t + offset, count, db));
                            break;

                        case Reflection.ID.Global.CarTypeInfo:
                            E_CarTypeInfo(byteptr_t + offset + 8, size, db);
                            break;

                        case Reflection.ID.Global.PresetRides:
                            proff = offset + 8;
                            prsize = size;
                            break;

                        case Reflection.ID.Global.CarParts:
                            cpoff = offset + 8;
                            cpsize = size;
                            break;

                        case Reflection.ID.Global.SlotTypes:
                            E_SlotType(byteptr_t + offset, size + 8, db);
                            break;

                        case Reflection.ID.Global.Collisions:
                            cooff = offset + 8;
                            cosize = size;
                            break;

                        case Reflection.ID.Global.FEngFiles:
                        case Reflection.ID.Global.FNGCompress:
                            E_FNGroup(byteptr_t + offset, size + 8, db);
                            break;

                        default:
                            break;
                    }
                    offset += 8 + size; // advance in offset
                }

                // CarParts and Collisions blocks are the last ones to disassemble
                E_CarParts(byteptr_t + cpoff, cpsize, db);
                E_Collisions(byteptr_t + cooff, cosize, db);
                E_PresetRides(byteptr_t + proff, prsize, db);
            }

            // Disperse spoilers across cartypeinfo
            E_Spoilers(db);
            return true;
        }
    }
}
