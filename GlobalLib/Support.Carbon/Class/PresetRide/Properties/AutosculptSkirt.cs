namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private sbyte _autosculpt_skirt = 0;

        /// <summary>
        /// Autosculpt skirt value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        public string AutosculptSkirt
        {
            get
            {
                if (this._autosculpt_skirt == -1)
                    return Reflection.BaseArguments.NULL;
                else
                    return this._autosculpt_skirt.ToString();
            }
            set
            {
                if (value == Reflection.BaseArguments.NULL)
                    this._autosculpt_skirt = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 14)
                        throw new System.ArgumentOutOfRangeException();
                    else
                        this._autosculpt_skirt = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}