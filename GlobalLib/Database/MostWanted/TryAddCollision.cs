using System;
using System.IO;
using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection.ID;
using GlobalLib.Support.MostWanted.Parts.CarParts;



namespace GlobalLib.Database
{
    public partial class MostWanted
    {
        /// <summary>
        /// Adds <see cref="Collision"/> block to the database memory.
        /// </summary>
        /// <param name="CName">Collection Name of the <see cref="Collision"/> block.</param>
        /// <param name="filepath">Filepath of the <see cref="Collision"/> block to be imported.</param>
        /// <param name="error">Error occured when trying to add collision.</param>
        /// <returns>True if adding was successful; false otherwise.</returns>
        public override unsafe bool TryAddCollision(string CName, string filepath, out string error)
        {
            error = null;
            try
            {
                if (!File.Exists(filepath))
                    throw new FileNotFoundException();

                foreach (var pair in Map.CollisionMap)
                {
                    if (CName == pair.Value)
                        throw new Exception("Collision with the same collection name already exists.");
                }

                var data = File.ReadAllBytes(filepath);
                fixed (byte* dataptr_t = &data[0])
                {
                    if (*(uint*)dataptr_t != CarParts.Collision)
                        throw new Exception("File specified is not a collision file.");
                    if (*(int*)(dataptr_t + 4) != data.Length - 8)
                        throw new Exception("File has incorrect length parameters.");
                    uint key = Vlt.Hash(CName);
                    *(uint*)(dataptr_t + 8) = key;
                    *(uint*)(dataptr_t + 16) = 0xFFFFFFFF;
                    var collision = new Collision(data, CName);
                    this.SlotTypes.Collisions[key] = collision;
                    Map.CollisionMap[key] = CName;
                }
                return true;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }
    }
}