﻿namespace GlobalLib.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attempts to remove texture specified from TPKBlock data.
        /// </summary>
        /// <param name="CName">Collection Name of the texture to be deleted.</param>
        /// <returns>True if texture removing was successful, false otherwise.</returns>
        public override bool TryRemoveTexture(string CName)
        {
            int index = this.GetTextureIndex(CName);
            if (index == -1)
                return false;

            this.Textures.RemoveAt(index);
            return true;
        }
    }
}