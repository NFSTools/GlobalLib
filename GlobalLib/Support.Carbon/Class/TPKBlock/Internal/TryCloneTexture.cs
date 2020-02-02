namespace GlobalLib.Support.Carbon.Class
{
    partial class TPKBlock : Shared.Class.TPKBlock
    {
        /// <summary>
        /// Attempts to clone texture specified in the TPKBlock data.
        /// </summary>
        /// <param name="newname">Collection Name of the new texture.</param>
        /// <param name="copyfrom">Collection Name of the texture to clone.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public override bool TryCloneTexture(string newname, string copyfrom)
        {
            if (this.GetTextureIndex(newname) != -1)
                return false;

            int index = this.GetTextureIndex(copyfrom);
            if (index == -1)
                return false;

            var texture = this.Textures[index].MemoryCast(newname);
            this.Textures.Add(texture);
            return true;
        }
    }
}