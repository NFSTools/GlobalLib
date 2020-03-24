namespace GlobalLib.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attempts to clone texture specified in the TPKBlock data.
        /// </summary>
        /// <param name="newname">Collection Name of the new texture.</param>
        /// <param name="copyfrom">Collection Name of the texture to clone.</param>
        /// <returns>True if texture cloning was successful, false otherwise.</returns>
        public override bool TryCloneTexture(string newname, string copyfrom)
        {
            if (string.IsNullOrWhiteSpace(newname)) return false;

            if (this.GetTextureIndex(newname) != -1)
                return false;

            int index = this.GetTextureIndex(copyfrom);
            if (index == -1)
                return false;

            if (newname.Length > 0x17) return false;

            var texture = (Texture)this.Textures[index].MemoryCast(newname);
            this.Textures.Add(texture);
            return true;
        }
    }
}