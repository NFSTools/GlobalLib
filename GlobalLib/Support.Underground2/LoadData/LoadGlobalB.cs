using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        private static bool LibPartBlockExists = false;

        /// <summary>
        /// Loads GlobalB file and disassembles its blocks
        /// </summary>
        /// <param name="GlobalB_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadGlobalB(string GlobalB_dir, Database.Underground2 db)
        {
            LibPartBlockExists = false;
            GlobalB_dir += @"\GLOBAL\GlobalB.lzc";

            // Get everything from GlobalB.lzc
            try
            {
                db._GlobalBLZC = File.ReadAllBytes(GlobalB_dir);
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
            db._GlobalBLZC = Utils.JDLZ.Decompress(db._GlobalBLZC);

            // Use pointers to speed up process
            fixed (byte* byteptr_t = &db._GlobalBLZC[0])
            {
                uint offset = 0; // to calculate current offset
                uint ID = 0; // to get the ID of the block being read
                uint size = 0; // to get the size of the block being read

                uint proff = 0; // offset of the preset rides block
                uint prsize = 0; // size of the preset rides block

                uint troff = 0; // offset of the tracks block
                uint trsize = 0; // size of the tracks block

                uint csoff = 0; // offset of the carskins block
                uint cssize = 0; // size of the carskins block

                uint gcoff = 0xFFFFFFFF; // offset of the gcareerinfo block

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
                        case Reflection.ID.Global.Materials:
                            E_Material(byteptr_t + offset, db);
                            break;

                        case Reflection.ID.Global.TPKBlocks:
                            int count = db.TPKBlocks.Count;
                            db.TPKBlocks.Add(new Class.TPKBlock(byteptr_t + offset, count, db));
                            break;

                        case Reflection.ID.Global.CarTypeInfo:
                            E_CarTypeInfo(byteptr_t + offset + 8, size, db);
                            break;

                        case Reflection.ID.Global.PresetRides:
                            proff = offset + 8;
                            prsize = size;
                            break;

                        case Reflection.ID.Global.CarParts:
                            E_CarParts(byteptr_t + offset + 8, size, db);
                            break;

                        case Reflection.ID.Global.SunInfos:
                            E_SunInfo(byteptr_t + offset + 8, size, db);
                            break;

                        case Reflection.ID.Global.Tracks:
                            troff = offset + 8;
                            trsize = size;
                            break;

                        case Reflection.ID.Global.CarSkins:
                            csoff = offset + 8;
                            cssize = size;
                            break;

                        case Reflection.ID.Global.SlotTypes:
                            E_SlotType(byteptr_t + offset, size + 8, db);
                            break;
                        

                        case Reflection.ID.Global.CareerInfo:
                            if (gcoff == 0xFFFFFFFF)
                                gcoff = offset;
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

                // Track, Presets and CarSkins are last one to disperse
                E_Tracks(byteptr_t + troff, trsize, db);
                E_PresetRides(byteptr_t + proff, prsize, db);
                E_CarSkins(byteptr_t + csoff, cssize, db);
                Framework.CareerManager.Disassemble(byteptr_t + gcoff, db);
            }

            // Disperse spoilers across cartypeinfo
            E_SpoilMirrs(db);
            return true;
        }
    }
}
