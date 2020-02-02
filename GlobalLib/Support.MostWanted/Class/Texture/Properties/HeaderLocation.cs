﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Header location offset in the Global data.
        /// </summary>
        private int _located_at = 0;

        /// <summary>
        /// Size of the header in the Global data.
        /// </summary>
        private int _size_of_block = 0;

        /// <summary>
        /// Parent TPK of the texture.
        /// </summary>
        private string _parent_TPK;
    }
}