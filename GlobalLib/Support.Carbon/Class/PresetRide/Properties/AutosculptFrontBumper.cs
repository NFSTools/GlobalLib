namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private sbyte _autosculpt_frontbumper = 0;

        /// <summary>
        /// Autosculpt front bumper value of the preset ride. Range: 0-10, NULL.
        /// </summary>
        public string AutosculptFrontBumper
        {
            get
            {
                if (this._autosculpt_frontbumper == -1)
                    return Reflection.BaseArguments.NULL;
                else
                    return this._autosculpt_frontbumper.ToString();
            }
            set
            {
                if (value == Reflection.BaseArguments.NULL)
                    this._autosculpt_frontbumper = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 10)
                        throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 10, or NULL.");
                    else
                        this._autosculpt_frontbumper = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}