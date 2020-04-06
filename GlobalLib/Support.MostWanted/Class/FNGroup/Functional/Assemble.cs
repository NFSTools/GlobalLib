using GlobalLib.Reflection.ID;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class FNGroup
    {
        /// <summary>
        /// Assembles frontend group into a byte array.
        /// </summary>
        /// <returns>Byte array of the frontend group.</returns>
        public override unsafe byte[] Assemble()
        {
            fixed (byte* byteptr_t = &this._DATA[0])
            {
                *(uint*)byteptr_t = Global.FEngFiles;
                *(uint*)(byteptr_t + 4) = this.Size;

                foreach (var color in this._colorinfo)
                {
                    *(uint*)(byteptr_t + color.Offset + 4) = (uint)color.Blue;
                    *(uint*)(byteptr_t + color.Offset + 8) = (uint)color.Green;
                    *(uint*)(byteptr_t + color.Offset + 12) = (uint)color.Red;
                    *(uint*)(byteptr_t + color.Offset + 16) = (uint)color.Alpha;
                }
            }
            return this._DATA;
        }
    }
}