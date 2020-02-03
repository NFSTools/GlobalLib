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
            if (this._colorinfo.Count <= index) return;
            this._colorinfo[index].Alpha = color.Alpha;
            this._colorinfo[index].Red = color.Red;
            this._colorinfo[index].Green = color.Green;
            this._colorinfo[index].Blue = color.Blue;

        }

        /// <summary>
        /// Sets FEng color to all colors that are equal to one at a specific index.
        /// </summary>
        /// <param name="index">Index of the color to be compared to others.</param>
        /// <param name="color">FEng color to be set.</param>
        /// <param name="keepalpha">True if alpha value of all colors should be kept original.</param>
        public void SetSameColors(int index, FEngColor color, bool keepalpha)
        {
            if (this._colorinfo.Count <= index) return;
            for (int a1 = 0; a1 < this._colorinfo.Count; ++a1)
            {
                if (a1 == index) continue;
                if (Utils.EA.SAT.EqualColors(this._colorinfo[index], this._colorinfo[a1], !keepalpha))
                {
                    this._colorinfo[a1].Red = color.Red;
                    this._colorinfo[a1].Green = color.Green;
                    this._colorinfo[a1].Blue = color.Blue;
                    if (!keepalpha)
                        this._colorinfo[a1].Alpha = color.Alpha;
                }
            }
            this._colorinfo[index].Red = color.Red;
            this._colorinfo[index].Green = color.Green;
            this._colorinfo[index].Blue = color.Blue;
            if (!keepalpha)
                this._colorinfo[index].Alpha = color.Alpha;
        }

        /// <summary>
        /// Sets FEng color to all colors in the FEng file.
        /// </summary>
        /// <param name="color">FEng color to be set.</param>
        /// <param name="keepalpha">True if alpha value of all colors should be kept original.</param>
        public void SetAllColors(FEngColor color, bool keepalpha)
        {
            foreach (var thiscolor in this._colorinfo)
            {
                thiscolor.Red = color.Red;
                thiscolor.Green = color.Green;
                thiscolor.Blue = color.Blue;
                if (!keepalpha)
                    thiscolor.Alpha = color.Alpha;
            }
        }
    }
}