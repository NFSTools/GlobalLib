using GlobalLib.Core;
using GlobalLib.Reflection.Enum;
using GlobalLib.Utils.EA;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Disassembles preset skin array into separate properties.
        /// </summary>
        /// <param name="byteptr_t">Pointer to the preset skin array.</param>
        protected override unsafe void Disassemble(byte* byteptr_t)
        {
            uint key = 0; // for reading hashes

            key = *(uint*)(byteptr_t + 0x28);
            if (Enum.IsDefined(typeof(eCarbonPaint), key))
                this.PaintType = (eCarbonPaint)key;
            else
                this.PaintType = eCarbonPaint.GLOSS;

            // Paint Swatch
            this.PaintSwatch = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x2C), false));

            // Saturation and Brightness
            this.PaintSaturation = *(float*)(byteptr_t + 0x30);
            this.PaintBrightness = *(float*)(byteptr_t + 0x34);

            // Generic vinyl
            key = *(uint*)(byteptr_t + 0x38);
            this._genericvinyl = Map.Lookup(key, true) ?? $"0x{key:X8}";

            // Vinyl
            key = *(uint*)(byteptr_t + 0x3C);
            this._vectorvinyl = Map.Lookup(key, true) ?? $"0x{key:X8}";
            this.PositionY = *(short*)(byteptr_t + 0x40);
            this.PositionX = *(short*)(byteptr_t + 0x42);
            this.Rotation = *(sbyte*)(byteptr_t + 0x44);
            this.Skew = *(sbyte*)(byteptr_t + 0x45);
            this.ScaleY = *(sbyte*)(byteptr_t + 0x46);
            this.ScaleX = *(sbyte*)(byteptr_t + 0x47);
            this.SwatchColor1 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x48), false));
            this.SwatchColor2 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x50), false));
            this.SwatchColor3 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x58), false));
            this.SwatchColor4 = Resolve.GetSwatchIndex(Map.Lookup(*(uint*)(byteptr_t + 0x60), false));
            this.Saturation1 = *(byteptr_t + 0x4C);
            this.Saturation2 = *(byteptr_t + 0x54);
            this.Saturation3 = *(byteptr_t + 0x5C);
            this.Saturation4 = *(byteptr_t + 0x64);
            this.Brightness1 = *(byteptr_t + 0x4D);
            this.Brightness2 = *(byteptr_t + 0x55);
            this.Brightness3 = *(byteptr_t + 0x5D);
            this.Brightness4 = *(byteptr_t + 0x65);
        }
    }
}