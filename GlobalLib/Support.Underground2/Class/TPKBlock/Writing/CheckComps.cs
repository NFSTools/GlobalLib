namespace GlobalLib.Support.Underground2.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Checks texture compressions and tpk compressions for matching.
        /// </summary>
        protected override void CheckComps()
        {
            this.compressions.Clear();
            for (int a1 = 0; a1 < this.Textures.Count; ++a1)
            {
                var Slot = new Shared.Parts.TPKParts.CompSlot();
                Slot.var1 = this.Textures[a1].CompVal1;
                Slot.var2 = this.Textures[a1].CompVal2;
                Slot.var3 = this.Textures[a1].CompVal3;
                Slot.comp = Utils.EA.Comp.GetInt(this.Textures[a1].Compression);
                this.compressions.Add(Slot);
            }
        }
    }
}