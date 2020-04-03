using System.Collections.Generic;
using GlobalLib.Support.Shared.Parts.FNGParts;



namespace GlobalLib.Support.Shared.Class
{
    public class FNGroup
    {
        #region Main Properties

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public string CollectionName { get; protected set; }

        /// <summary>
        /// Binary memory hash of the collection name.
        /// </summary>
        public uint BinKey { get => Utils.Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the collection name.
        /// </summary>
        public uint VltKey { get => Utils.Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Size of the group in Global memory.
        /// </summary>
        public uint Size { get; protected set; }

        /// <summary>
        /// Represents boolean of whether this group can be destroyed b/c it is repetitive.
        /// </summary>
        public bool Destroy { get; protected set; } = false;

        protected List<FEngColor> _colorinfo = new List<FEngColor>();

        /// <summary>
        /// Length of the color information array.
        /// </summary>
        public int InfoLength { get => this._colorinfo.Count; }

        #endregion

        #region Methods

        /// <summary>
        /// Assembles frontend group into a byte array.
        /// </summary>
        /// <returns>Byte array of the frontend group.</returns>
        public virtual unsafe byte[] Assemble() { return null; }

        /// <summary>
        /// Disassembles frontend group array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the frontend group array.</param>
        protected virtual unsafe void Disassemble(byte[] data) { }

        /// <summary>
        /// Gets <see cref="FEngColor"/> from a specific index.
        /// </summary>
        /// <param name="index">Index of the color.</param>
        /// <returns><see cref="FEngColor"/> class.</returns>
        public virtual FEngColor GetColor(int index)
        {
            if (index >= this.InfoLength) return null;
            else return this._colorinfo[index];
        }

        /// <summary>
        /// Gets <see cref="FEngColor"/> using Color[X] string.
        /// </summary>
        /// <param name="colortext">String of Color[X] format.</param>
        /// <returns><see cref="FEngColor"/> class.</returns>
        public virtual FEngColor GetColor(string colortext)
        {
            if (!Utils.FormatX.GetInt32(colortext, "Color[{X}]", out int index)) return null;
            else return this.GetColor(index);
        }

        /// <summary>
        /// Attempts to set new <see cref="FEngColor"/> at specific color.
        /// </summary>
        /// <param name="index">Index of the color to set.</param>
        /// <param name="color">New <see cref="FEngColor"/> to set.</param>
        /// <returns>True if setting new color was successful; false otherwise.</returns>
        public virtual bool TrySetOne(int index, FEngColor color)
        {
            var thiscolor = this.GetColor(index);
            if (thiscolor == null) return false;
            thiscolor.Alpha = color.Alpha;
            thiscolor.Red = color.Red;
            thiscolor.Green = color.Green;
            thiscolor.Blue = color.Blue;
            return true;
        }

        /// <summary>
        /// Attempts to set new <see cref="FEngColor"/> at specific color.
        /// </summary>
        /// <param name="colortext">String of Color[X] format.</param>
        /// <param name="color">New <see cref="FEngColor"/> to set.</param>
        /// <returns>True if setting new color was successful; false otherwise.</returns>
        public virtual bool TrySetOne(string colortext, FEngColor color)
        {
            var thiscolor = this.GetColor(colortext);
            if (thiscolor == null) return false;
            thiscolor.Alpha = color.Alpha;
            thiscolor.Red = color.Red;
            thiscolor.Green = color.Green;
            thiscolor.Blue = color.Blue;
            return true;
        }

        /// <summary>
        /// Attempts to set new <see cref="FEngColor"/> at specific color.
        /// </summary>
        /// <param name="index">Index of the color to set.</param>
        /// <param name="color">New <see cref="FEngColor"/> to set.</param>
        /// <param name="error">Error occured when trying to set one color.</param>
        /// <returns>True if setting new color was successful; false otherwise.</returns>
        public virtual bool TrySetOne(int index, FEngColor color, out string error)
        {
            error = null;
            var thiscolor = this.GetColor(index);
            if (thiscolor == null)
            {
                error = $"Color with index {index} does not exist.";
                return false;
            }
            thiscolor.Alpha = color.Alpha;
            thiscolor.Red = color.Red;
            thiscolor.Green = color.Green;
            thiscolor.Blue = color.Blue;
            return true;
        }

        /// <summary>
        /// Attempts to set new <see cref="FEngColor"/> at specific color.
        /// </summary>
        /// <param name="colortext">String of Color[X] format.</param>
        /// <param name="color">New <see cref="FEngColor"/> to set.</param>
        /// <param name="error">Error occured when trying to set one color.</param>
        /// <returns>True if setting new color was successful; false otherwise.</returns>
        public virtual bool TrySetOne(string colortext, FEngColor color, out string error)
        {
            error = null;
            var thiscolor = this.GetColor(colortext);
            if (thiscolor == null)
            {
                error = $"Unable to find color {colortext}.";
                return false;
            }
            thiscolor.Alpha = color.Alpha;
            thiscolor.Red = color.Red;
            thiscolor.Green = color.Green;
            thiscolor.Blue = color.Blue;
            return true;
        }

        public virtual bool TrySetSame(FEngColor sample, FEngColor newbase, bool keepalpha) { return false; }

        public virtual bool TrySetSame(FEngColor sample, FEngColor newbase, bool keepalpha, out string error)
        {
            error = null;
            return false;
        }

        public virtual bool TrySetAll(FEngColor color, bool keepalpha) { return false; }

        public virtual bool TrySetAll(FEngColor color, bool keepalpha, out string error)
        {
            error = null;
            return false;
        }

        #endregion
    }
}