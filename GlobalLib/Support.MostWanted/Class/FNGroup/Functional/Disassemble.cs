namespace GlobalLib.Support.MostWanted.Class
{
    public partial class FNGroup : Shared.Class.FNGroup
    {
        protected override unsafe void Disassemble(byte[] data)
        {
            this._DATA = new byte[data.Length];
            System.Buffer.BlockCopy(data, 0, this._DATA, 0, data.Length);

            fixed (byte* byteptr_t = &this._DATA[0])
            {
                this.Size = *(uint*)(byteptr_t + 4);

                // For some reason HUFF compression has the same ID as FEng files
                if (*(uint*)(byteptr_t + 8) == 0x46465548)
                {
                    this.Destroy = true;
                    return;
                }

                // Read CollectionName
                this.CollectionName = Utils.ScriptX.NullTerminatedString(byteptr_t + 0x30, this._DATA.Length - 0x30);
                if (this.CollectionName.EndsWith(".fng"))
                    this.CollectionName = Utils.FormatX.GetString(this.CollectionName, "{X}.fng");

                for (uint offset = 0x30; offset < this._DATA.Length; offset += 4)
                {
                    byte b1 = *(byteptr_t + offset);
                    byte b2 = *(byteptr_t + offset + 1);
                    byte b3 = *(byteptr_t + offset + 2);
                    byte b4 = *(byteptr_t + offset + 3);

                    // SAT, SAD, SA(0x90) or 1111
                    if ((b1 == 'S' && b2 == 'A') || (b1 == 0xFF && b2 == 0xFF && b3 == 0xFF && b4 == 0xFF))
                    {
                        uint Blue = *(uint*)(byteptr_t + offset + 4);
                        uint Green = *(uint*)(byteptr_t + offset + 8);
                        uint Red = *(uint*)(byteptr_t + offset + 12);
                        uint Alpha = *(uint*)(byteptr_t + offset + 16);

                        // If it is a color, add to the list
                        if (Utils.EA.Resolve.IsColor(Alpha, Red, Green, Blue))
                        {
                            var TempColor = new Shared.Parts.FNGParts.FEngColor();
                            TempColor.Offset = offset;
                            TempColor.Alpha = (byte)Alpha;
                            TempColor.Red = (byte)Red;
                            TempColor.Green = (byte)Green;
                            TempColor.Blue = (byte)Blue;
                            this._colorinfo.Add(TempColor);
                        }
                        offset += 0x14;
                    }
                }
            }
        }
    }
}