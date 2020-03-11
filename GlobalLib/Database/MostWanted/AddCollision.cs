namespace GlobalLib.Database
{
    public partial class MostWanted
    {
        /// <summary>
        /// Adds collision block to the database memory.
        /// </summary>
        /// <param name="CName">Collection Name of the collision block.</param>
        /// <param name="filepath">Filepath of the collision block to be imported.</param>
        public unsafe bool AddCollision(string CName, string filepath)
        {
            try
            {
                if (!System.IO.File.Exists(filepath))
                    throw new System.IO.FileNotFoundException();

                foreach (var pair in Core.Map.CollisionMap)
                {
                    if (CName == pair.Value)
                        throw new System.Exception("Collision with the same collection name already exists.");
                }

                var data = System.IO.File.ReadAllBytes(filepath);
                fixed (byte* dataptr_t = &data[0])
                {
                    if (*(uint*)dataptr_t != Reflection.ID.CarParts.Collision)
                        throw new System.Exception("File specified is not a collision file.");
                    if (*(int*)(dataptr_t + 4) != data.Length - 8)
                        throw new System.Exception("File has incorrect length parameters.");
                    uint key = Utils.Vlt.Hash(CName);
                    *(uint*)(dataptr_t + 8) = key;
                    *(uint*)(dataptr_t + 16) = 0xFFFFFFFF;
                    var collision = new Support.MostWanted.Parts.CarParts.Collision(data, CName);
                    this.SlotTypes.Collisions[key] = collision;
                    Core.Map.CollisionMap[key] = CName;
                }
                return true;
            }
            catch (System.Exception e)
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message, "Warning");
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }
    }
}