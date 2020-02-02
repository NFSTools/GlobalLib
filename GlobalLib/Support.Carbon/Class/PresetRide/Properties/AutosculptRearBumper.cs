namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private sbyte _autosculpt_rearbumper = 0;

        /// <summary>
        /// Autosculpt rear bumper value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        public string AutosculptRearBumper
        {
            get
            {
                if (this._autosculpt_rearbumper == -1)
                    return Reflection.BaseArguments.NULL;
                else
                    return this._autosculpt_rearbumper.ToString();
            }
            set
            {
                if (value == Reflection.BaseArguments.NULL)
                    this._autosculpt_rearbumper = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 10)
                        throw new System.ArgumentOutOfRangeException();
                    else
                        this._autosculpt_rearbumper = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}