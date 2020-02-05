namespace GlobalLib.Support.MostWanted.Class
{
    public partial class TPKBlock : Shared.Class.TPKBlock
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