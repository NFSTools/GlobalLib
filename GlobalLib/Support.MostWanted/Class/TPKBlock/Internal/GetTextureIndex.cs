namespace GlobalLib.Support.MostWanted.Class
{
    partial class TPKBlock : Shared.Class.TPKBlock
    {
        /// <summary>
        /// Gets index of the texture in the TPKBlock.
        /// </summary>
        /// <param name="CName">Collection Name of the texture.</param>
        /// <returns>Index number as an integer. If element does not exist, returns -1.</returns>
        public override int GetTextureIndex(string CName)
        {
            for (int a1 = 0; a1 < this.Textures.Count; ++a1)
            {
                if (CName == this.Textures[a1].CollectionName)
                    return a1;
            }
            return -1;
        }
    }
}