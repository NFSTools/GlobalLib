using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Carbon.Parts.PresetParts
{
    public class Vinyl : SubPart, ICopyable<Vinyl>
    {
        private string _vectorvinyl = BaseArguments.NULL;
        private byte _swatch1 = 0;
        private byte _swatch2 = 0;
        private byte _swatch3 = 0;
        private byte _swatch4 = 0;

        public string VectorVinyl
        {
            get => this._vectorvinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._vectorvinyl = value;
            }
        }

        public short PositionY  { get; set; } = 0;
        public short PositionX  { get; set; } = 0;
        public sbyte Rotation   { get; set; } = 0;
        public sbyte Skew       { get; set; } = 0;
        public sbyte ScaleY     { get; set; } = 0;
        public sbyte ScaleX     { get; set; } = 0;
        public byte Saturation1 { get; set; } = 0;
        public byte Brightness1 { get; set; } = 0;
        public byte Saturation2 { get; set; } = 0;
        public byte Brightness2 { get; set; } = 0;
        public byte Saturation3 { get; set; } = 0;
        public byte Brightness3 { get; set; } = 0;
        public byte Saturation4 { get; set; } = 0;
        public byte Brightness4 { get; set; } = 0;

        public byte SwatchColor1
        {
            get => this._swatch1;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch1 = value;
            }
        }

        public byte SwatchColor2
        {
            get => this._swatch2;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch2 = value;
            }
        }

        public byte SwatchColor3
        {
            get => this._swatch3;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch3 = value;
            }
        }

        public byte SwatchColor4
        {
            get => this._swatch4;
            set
            {
                if (value > 90)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 90.");
                else
                    this._swatch4 = value;
            }
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Vinyl PlainCopy()
        {
            var result = new Vinyl();
            var ThisType = this.GetType();
            var ResultType = result.GetType();
            foreach (var ThisProperty in ThisType.GetProperties())
            {
                var ResultField = ResultType.GetProperty(ThisProperty.Name);
                ResultField.SetValue(result, ThisProperty.GetValue(this));
            }
            return result;
        }
    
        public unsafe void Read(byte* byteptr_t)
        {
            var key = *(uint*)byteptr_t;
            this._vectorvinyl = Map.Lookup(key, true) ?? $"0x{key:X8}";
            this.PositionY = *(short*)(byteptr_t + 0x04);
            this.PositionX = *(short*)(byteptr_t + 0x06);
            this.Rotation = *(sbyte*)(byteptr_t + 0x08);
            this.Skew = *(sbyte*)(byteptr_t + 0x09);
            this.ScaleY = *(sbyte*)(byteptr_t + 0x0A);
            this.ScaleX = *(sbyte*)(byteptr_t + 0x0B);
            this.SwatchColor1 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x0C), false));
            this.SwatchColor2 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x14), false));
            this.SwatchColor3 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x1C), false));
            this.SwatchColor4 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x24), false));
            this.Saturation1 = *(byteptr_t + 0x10);
            this.Saturation2 = *(byteptr_t + 0x18);
            this.Saturation3 = *(byteptr_t + 0x20);
            this.Saturation4 = *(byteptr_t + 0x28);
            this.Brightness1 = *(byteptr_t + 0x11);
            this.Brightness2 = *(byteptr_t + 0x19);
            this.Brightness3 = *(byteptr_t + 0x21);
            this.Brightness4 = *(byteptr_t + 0x29);
        }

        public unsafe void Write(byte* byteptr_t)
        {
            *(uint*)byteptr_t = Bin.SmartHash(this.VectorVinyl);
            *(short*)(byteptr_t + 0x04) = this.PositionY;
            *(short*)(byteptr_t + 0x06) = this.PositionX;
            *(byteptr_t + 0x08) = (byte)this.Rotation;
            *(byteptr_t + 0x09) = (byte)this.Skew;
            *(byteptr_t + 0x0A) = (byte)this.ScaleY;
            *(byteptr_t + 0x0B) = (byte)this.ScaleX;
            *(uint*)(byteptr_t + 0x0C) = Bin.Hash(Resolve.GetVinylString(this.SwatchColor1));
            *(uint*)(byteptr_t + 0x14) = Bin.Hash(Resolve.GetVinylString(this.SwatchColor2));
            *(uint*)(byteptr_t + 0x1C) = Bin.Hash(Resolve.GetVinylString(this.SwatchColor3));
            *(uint*)(byteptr_t + 0x24) = Bin.Hash(Resolve.GetVinylString(this.SwatchColor4));
            *(byteptr_t + 0x10) = this.Saturation1;
            *(byteptr_t + 0x18) = this.Saturation2;
            *(byteptr_t + 0x20) = this.Saturation3;
            *(byteptr_t + 0x28) = this.Saturation4;
            *(byteptr_t + 0x11) = this.Brightness1;
            *(byteptr_t + 0x19) = this.Brightness2;
            *(byteptr_t + 0x21) = this.Brightness3;
            *(byteptr_t + 0x29) = this.Brightness4;
        }
    }
}
