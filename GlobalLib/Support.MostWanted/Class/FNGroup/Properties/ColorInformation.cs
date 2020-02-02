using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.FNGParts;


namespace GlobalLib.Support.MostWanted.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        private List<FEngColor> _colorinfo = new List<FEngColor>();

        /// <summary>
        /// Length of the color information array.
        /// </summary>
        public int InfoLength { get => this._colorinfo.Count; }

        /// <summary>
        /// Gets FEng color from a specific index.
        /// </summary>
        /// <param name="index">Index of the color.</param>
        /// <returns>FEngColor class.</returns>
        public FEngColor GetColor(int index)
        {
            if (this._colorinfo.Count <= index)
                return null;
            else
                return this._colorinfo[index];
        }

        /// <summary>
        /// Sets FEng color at a specific index.
        /// </summary>
        /// <param name="index">Index of the color.</param>
        /// <param name="color">FEng color to be set.</param>
        public void SetColor(int index, FEngColor color)
        {
            if (this._colorinfo.Count <= index)
                return;
            else
                this._colorinfo[index] = color;
        }
    }
}