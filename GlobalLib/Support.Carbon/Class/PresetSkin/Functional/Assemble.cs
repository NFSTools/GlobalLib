namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Assembles preset skin into a byte array.
        /// </summary>
        /// <returns>Byte array of the preset skin.</returns>
        public override unsafe byte[] Assemble()
        {
            byte[] result = new byte[0x68];
            fixed (byte* byteptr_t = &result[0])
            {
                // Write CollectionName
                for (int a1 = 0; a1 < this.CollectionName.Length; ++a1)
                    *(byteptr_t + 8 + a1) = (byte)this.CollectionName[a1];

                // Write all main settings
                *(uint*)(byteptr_t + 0x28) = (uint)this.PaintType;
                *(uint*)(byteptr_t + 0x2C) = Utils.Bin.Hash(Utils.EA.Resolve.GetSwatchString(this.PaintSwatch));
                *(float*)(byteptr_t + 0x30) = this.PaintSaturation;
                *(float*)(byteptr_t + 0x34) = this.PaintBrightness;

                // Write Generic Vinyl
                *(uint*)(byteptr_t + 0x38) = Utils.Bin.SmartHash(this._genericvinyl);

                // Write Vector Vinyl
                *(uint*)(byteptr_t + 0x3C) = Utils.Bin.SmartHash(this._vectorvinyl);
                *(short*)(byteptr_t + 0x40) = this.PositionY;
                *(short*)(byteptr_t + 0x42) = this.PositionX;
                *(byteptr_t + 0x44) = (byte)this.Rotation;
                *(byteptr_t + 0x45) = (byte)this.Skew;
                *(byteptr_t + 0x46) = (byte)this.ScaleY;
                *(byteptr_t + 0x47) = (byte)this.ScaleX;
                *(uint*)(byteptr_t + 0x48) = Utils.Bin.Hash(Utils.EA.Resolve.GetVinylString(this.SwatchColor1));
                *(uint*)(byteptr_t + 0x50) = Utils.Bin.Hash(Utils.EA.Resolve.GetVinylString(this.SwatchColor2));
                *(uint*)(byteptr_t + 0x58) = Utils.Bin.Hash(Utils.EA.Resolve.GetVinylString(this.SwatchColor3));
                *(uint*)(byteptr_t + 0x60) = Utils.Bin.Hash(Utils.EA.Resolve.GetVinylString(this.SwatchColor4));
                *(byteptr_t + 0x4C) = this.Saturation1;
                *(byteptr_t + 0x54) = this.Saturation2;
                *(byteptr_t + 0x5C) = this.Saturation3;
                *(byteptr_t + 0x64) = this.Saturation4;
                *(byteptr_t + 0x4D) = this.Brightness1;
                *(byteptr_t + 0x55) = this.Brightness2;
                *(byteptr_t + 0x5D) = this.Brightness3;
                *(byteptr_t + 0x65) = this.Brightness4;
            }
            return result;
        }
    }
}