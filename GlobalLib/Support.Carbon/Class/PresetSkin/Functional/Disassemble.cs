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
            if (System.Enum.IsDefined(typeof(Reflection.Enum.eCarbonPaint), key))
                this.PaintType = (Reflection.Enum.eCarbonPaint)key;
            else
                this.PaintType = Reflection.Enum.eCarbonPaint.GLOSS;

            // Paint Swatch
            this.PaintSwatch = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x2C)));

            // Saturation and Brightness
            this.PaintSaturation = *(float*)(byteptr_t + 0x30);
            this.PaintBrightness = *(float*)(byteptr_t + 0x34);

            // Generic vinyl
            key = *(uint*)(byteptr_t + 0x38);
            if (key != 0)
                this._genericvinyl = Core.Map.Lookup(key) ?? ("0x" + key.ToString("X8"));

            // Vinyl
            key = *(uint*)(byteptr_t + 0x3C);
            if (key != 0)
            { // check if it exists
                this._vectorvinyl = Core.Map.Lookup(key) ?? ("0x" + key.ToString("X8"));
                this.PositionY = *(short*)(byteptr_t + 0x40);
                this.PositionX = *(short*)(byteptr_t + 0x42);
                this.Rotation = *(sbyte*)(byteptr_t + 0x44);
                this.Skew = *(sbyte*)(byteptr_t + 0x45);
                this.ScaleY = *(sbyte*)(byteptr_t + 0x46);
                this.ScaleX = *(sbyte*)(byteptr_t + 0x47);
                this.SwatchColor1 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x48)));
                this.SwatchColor2 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x50)));
                this.SwatchColor3 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x58)));
                this.SwatchColor4 = Utils.EA.Resolve.GetSwatchIndex(Core.Map.Lookup(*(uint*)(byteptr_t + 0x60)));
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
}