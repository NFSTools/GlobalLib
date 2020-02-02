namespace GlobalLib.Support.MostWanted.Class
{
    partial class TPKBlock : Shared.Class.TPKBlock
    {
        /// <summary>
        /// Attempts to add texture to the TPKBlock data.
        /// </summary>
        /// <param name="CName">Collection Name of the new texture.</param>
        /// <param name="filename">Path of the texture to be imported.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public override bool TryAddTexture(string CName, string filename)
        {
            if (string.IsNullOrWhiteSpace(CName)) return false;

            if (this.GetTextureIndex(CName) != -1)
                return false;

            if (CName.Length > 0x17) return false;

            if (!Utils.EA.Comp.IsDDSTexture(filename))
                return false;

            var texture = new Texture(CName, filename);
            this.Textures.Add(texture);
            return true;
        }
    }
}