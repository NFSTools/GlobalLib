using GlobalLib.Core;
using GlobalLib.Reflection.ID;
using GlobalLib.Support.Carbon.Parts.CarParts;
using System.Collections.Generic;



namespace GlobalLib.Support.Carbon
{
    public static partial class LoadData
    {
        private static unsafe void E_Collisions(byte* byteptr_t, uint length, Database.Carbon db)
        {
            db.SlotTypes.Collisions = new Dictionary<uint, Collision>();

            // Make a map of vlt hash cartypeinfo and indexes
            var CNameToIndex = new Dictionary<uint, string>();
            foreach (var pair in db.CarTypeInfos.Collections)
                CNameToIndex[pair.VltKey] = pair.CollectionName;

            uint offset = 0;
            while (offset < length)
            {
                uint ID = *(uint*)(byteptr_t + offset);
                int size = *(int*)(byteptr_t + offset + 4);
                if (ID == CarParts.Collision)
                {
                    uint intkey = *(uint*)(byteptr_t + offset + 8);
                    uint extkey = *(uint*)(byteptr_t + offset + 16);

                    // If internal key exists and map shows a string for it
                    if (intkey != 0x11111111 && intkey != 0 && Map.CollisionMap.TryGetValue(intkey, out string CName))
                    {
                        // If collision is not in the map, plug it in
                        if (!db.SlotTypes.Collisions.ContainsKey(intkey))
                        {
                            // Copy whole data, get it into collision map
                            var data = new byte[size + 8];
                            fixed (byte* dataptr_t = &data[0])
                            {
                                for (int a1 = 0; a1 < size + 8; ++a1)
                                    *(dataptr_t + a1) = *(byteptr_t + offset + a1);
                                *(uint*)(dataptr_t + 16) = 0xFFFFFFFF;
                            }
                            var Class = new Collision(data, CName);
                            db.SlotTypes.Collisions[intkey] = Class;
                        }

                        // Check if cartypeinfo with a set external key exists
                        if (CNameToIndex.TryGetValue(extkey, out var name))
                        {
                            var car = db.CarTypeInfos.FindCollection(name);
                            car.CollisionExternalName = car.CollectionName;
                            car.CollisionInternalName = CName;
                        }
                    }
                    else
                    {
                        // Copy entire collision block
                        var data = new byte[size + 8];
                        fixed (byte* dataptr_t = &data[0])
                        {
                            for (int a1 = 0; a1 < size + 8; ++a1)
                                *(dataptr_t + a1) = *(byteptr_t + offset + a1);
                            *(uint*)(dataptr_t + 8) = extkey;
                            *(uint*)(dataptr_t + 16) = 0xFFFFFFFF;
                        }

                        // If collision map has value for external key
                        if (Map.CollisionMap.TryGetValue(extkey, out string ExName))
                        {
                            var Class = new Collision(data, ExName);
                            db.SlotTypes.Collisions[extkey] = Class;

                            // Check if cartypeinfo with a set external key exists
                            if (CNameToIndex.TryGetValue(extkey, out var name))
                            {
                                var car = db.CarTypeInfos.FindCollection(name);
                                car.CollisionExternalName = car.CollectionName;
                                car.CollisionInternalName = car.CollectionName;
                            }
                        }
                        else
                        {
                            var Class = new Collision(data, null);
                            db.SlotTypes.Collisions[extkey] = Class;
                        }
                    }
                }
                offset += (uint)size + 8;
            }

            // New collision map based on real collisions
            Map.CollisionMap.Clear();
            foreach (var collision in db.SlotTypes.Collisions)
            {
                if (!collision.Value.Unknown)
                    Map.CollisionMap[collision.Key] = collision.Value.BelongsTo;
            }
        }
    }
}