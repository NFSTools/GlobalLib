namespace GlobalLib.Support.Carbon.Parts.CarParts
{
    public class Collision
    {
        private byte[] data;

        public bool Unknown { get; } = false;

        public string BelongsTo { get; private set; }

        public uint BinKey { get => Utils.Bin.Hash(this.BelongsTo); }

        public uint VltKey { get => Utils.Vlt.Hash(this.BelongsTo); }

        /// <summary>
        /// Gets collision array with the specified external key.
        /// </summary>
        /// <param name="externalkey">External key to be set in the collision.</param>
        /// <returns>Collision data as a byte array.</returns>
        public unsafe byte[] GetData(uint externalkey)
        {
            var result = new byte[this.data.Length];
            System.Buffer.BlockCopy(this.data, 0, result, 0, this.data.Length);
            fixed (byte* dataptr_t = &result[0])
            {
                if (this.Unknown)
                    *(uint*)(dataptr_t + 16) = *(uint*)(dataptr_t + 8);
                else
                    *(uint*)(dataptr_t + 16) = externalkey;
            }
            return result;
        }

        // Default constructor: initialize collision with data and collection name.
        public Collision(byte[] data, string CName)
        {
            this.data = data;
            if (CName == null)
                this.Unknown = true;
            else
                this.BelongsTo = CName;
        }
    }
}
