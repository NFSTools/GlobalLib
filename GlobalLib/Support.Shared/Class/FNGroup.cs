using System;
using System.Collections.Generic;
using GlobalLib.Core;
using GlobalLib.Utils;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Shared.Parts.FNGParts;

namespace GlobalLib.Support.Shared.Class
{
    public class FNGroup : Collectable
    {
        #region Main Properties

        /// <summary>
        /// Collection Name of the class.
        /// </summary>
        public override string CollectionName { get; set; }

        /// <summary>
        /// Game to which the class belongs to.
        /// </summary>
        public override GameINT GameINT { get => GameINT.None; }

        /// <summary>
        /// Game string to which the class belongs to.
        /// </summary>
        public override string GameSTR { get => GameINT.None.ToString(); }

        /// <summary>
        /// Binary memory hash of the Collection Name.
        /// </summary>
        public uint BinKey { get => Bin.Hash(this.CollectionName); }

        /// <summary>
        /// Vault memory hash of the Collection Name.
        /// </summary>
        public uint VltKey { get => Vlt.Hash(this.CollectionName); }

        /// <summary>
        /// Size of the <see cref="FNGroup"/> in Global memory.
        /// </summary>
        public uint Size { get; protected set; }

        /// <summary>
        /// Represents boolean of whether this <see cref="FNGroup"/> can be destroyed b/c it is repetitive.
        /// </summary>
        public bool Destroy { get; protected set; } = false;

        /// <summary>
        /// List of all <see cref="FEngColor"/> that <see cref="FNGroup"/> contains.
        /// </summary>
        protected List<FEngColor> _colorinfo = new List<FEngColor>();

        /// <summary>
        /// Length of the color information array.
        /// </summary>
        public int InfoLength { get => this._colorinfo.Count; }

        #endregion

        #region Methods

        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
        {
            throw new NotImplementedException();
        }

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
        /// Attempts to set same <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="index">Index of the <see cref="FEngColor"/> to match.</param>
        /// <param name="newbase">New <see cref="FEngColor"/> to set.</param>
        /// <param name="keepalpha">True if alpha value should be kept; false otherwise.</param>
        /// <returns>True if setting same colors was successful; false otherwise.</returns>
        public virtual bool TrySetSame(int index, FEngColor newbase, bool keepalpha)
        {
            var excolor = this.GetColor(index);
            if (excolor == null) return false;
            var sample = new FEngColor()
            {
                Alpha = excolor.Alpha,
                Red = excolor.Red,
                Green = excolor.Green,
                Blue = excolor.Blue
            };
            foreach (var color in this._colorinfo)
            {
                if (color == sample)
                {
                    color.Red = sample.Red;
                    color.Green = sample.Green;
                    color.Blue = sample.Blue;
                    if (!keepalpha) color.Alpha = sample.Alpha;
                }
            }
            return true;
        }

        /// <summary>
        /// Attempts to set same <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="index">Index of the <see cref="FEngColor"/> to match.</param>
        /// <param name="newbase">New <see cref="FEngColor"/> to set.</param>
        /// <param name="keepalpha">True if alpha value should be kept; false otherwise.</param>
        /// <param name="error">Error occured when trying to set same colors.</param>
        /// <returns>True if setting same colors was successful; false otherwise.</returns>
        public virtual bool TrySetSame(int index, FEngColor newbase, bool keepalpha, out string error)
        {
            error = null;
            var excolor = this.GetColor(index);
            if (excolor == null)
            {
                error = $"Color with index {index} does not exist.";
                return false;
            }
            var sample = new FEngColor()
            {
                Alpha = excolor.Alpha,
                Red = excolor.Red,
                Green = excolor.Green,
                Blue = excolor.Blue
            };
            foreach (var color in this._colorinfo)
            {
                if (color == sample)
                {
                    color.Red = sample.Red;
                    color.Green = sample.Green;
                    color.Blue = sample.Blue;
                    if (!keepalpha) color.Alpha = sample.Alpha;
                }
            }
            return true;
        }

        /// <summary>
        /// Attempts to set all <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="color"><see cref="FEngColor"/> to set for all colors.</param>
        /// <param name="keepalpha">True if alpha value should be kept; false otherwise.</param>
        /// <returns>True if setting all colors was successful; false otherwise.</returns>
        public virtual bool TrySetAll(FEngColor color, bool keepalpha)
        {
            foreach (var thiscolor in this._colorinfo)
            {
                thiscolor.Red = color.Red;
                thiscolor.Green = color.Green;
                thiscolor.Blue = color.Blue;
                if (!keepalpha) thiscolor.Alpha = color.Alpha;
            }
            return true;
        }

        /// <summary>
        /// Attempts to set all <see cref="FEngColor"/> to a specific color.
        /// </summary>
        /// <param name="color"><see cref="FEngColor"/> to set for all colors.</param>
        /// <param name="keepalpha">True if alpha value should be kept; false otherwise.</param>
        /// <param name="error">Error occured when trying to set all colors.</param>
        /// <returns>True if setting all colors was successful; false otherwise.</returns>
        public virtual bool TrySetAll(FEngColor color, bool keepalpha, out string error)
        {
            error = null;
            foreach (var thiscolor in this._colorinfo)
            {
                thiscolor.Red = color.Red;
                thiscolor.Green = color.Green;
                thiscolor.Blue = color.Blue;
                if (!keepalpha) thiscolor.Alpha = color.Alpha;
            }
            return true;
        }

        #endregion
    }
}