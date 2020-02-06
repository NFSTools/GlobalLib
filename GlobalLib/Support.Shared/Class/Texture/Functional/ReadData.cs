﻿namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Reads .dds data from the tpk block.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the tpk block.</param>
        /// <param name="offset">Data offset from where to read.</param>
        public virtual unsafe void ReadData(byte* byteptr_t, int offset) { }
    }
}