namespace GlobalLib.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attemps to replace texture specified in the TPKBlock data with a new one.
        /// </summary>
        /// <param name="CName">Collection Name of the texture to be replaced.</param>
        /// <param name="filename">Path of the texture that replaces the current one.</param>
        /// <returns>True if texture replacing was successful, false otherwise.</returns>
        public override bool TryReplaceTexture(string CName, string filename)
        {
            if (string.IsNullOrWhiteSpace(CName)) return false;

            var tex = this.FindTexture(CName);
            if (tex == null) return false;

            if (!Utils.EA.Comp.IsDDSTexture(filename))
                return false;

            tex.Reload(filename);
            return true;
        }
    }
}