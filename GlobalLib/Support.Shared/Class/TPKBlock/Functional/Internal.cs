namespace GlobalLib.Support.Shared.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Gets index of the texture in the TPKBlock.
        /// </summary>
        /// <param name="CName">Collection Name of the texture.</param>
        /// <returns>Index number as an integer. If element does not exist, returns -1.</returns>
        public virtual int GetTextureIndex(string CName) { return -1; }

        /// <summary>
        /// Attempts to add texture to the TPKBlock data.
        /// </summary>
        /// <param name="CName">Collection Name of the new texture.</param>
        /// <param name="filename">Path of the texture to be imported.</param>
        /// <returns>True if texture adding was successful, false otherwise.</returns>
        public virtual bool TryAddTexture(string CName, string filename) { return false; }

        /// <summary>
        /// Attempts to remove texture specified from TPKBlock data.
        /// </summary>
        /// <param name="CName">Collection Name of the texture to be deleted.</param>
        /// <returns>True if texture removing was successful, false otherwise.</returns>
        public virtual bool TryRemoveTexture(string CName) { return false; }

        /// <summary>
        /// Attempts to clone texture specified in the TPKBlock data.
        /// </summary>
        /// <param name="newname">Collection Name of the new texture.</param>
        /// <param name="copyfrom">Collection Name of the texture to clone.</param>
        /// <returns>True if class cloning was successful, false otherwise.</returns>
        public virtual bool TryCloneTexture(string newname, string copyfrom) { return false; }
    }
}