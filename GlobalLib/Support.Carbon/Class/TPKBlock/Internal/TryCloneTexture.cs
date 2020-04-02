namespace GlobalLib.Support.Carbon.Class
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

            if (this.FindTexture(Utils.Bin.Hash(newname), GlobalLib.Database.Collection.eKeyType.BINKEY) != null)
                return false;

            var tex = this.FindTexture(copyfrom);
            if (tex == null) return false;

            if (newname.Length > 0x22) return false;

            var texture = (Texture)tex.MemoryCast(newname);
            this.Textures.Add(texture);
            return true;
        }
    }
}