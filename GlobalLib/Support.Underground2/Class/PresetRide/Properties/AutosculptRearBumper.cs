namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private sbyte _autosculpt_rearbumper = 0;

        /// <summary>
        /// Autosculpt rear bumper value of the preset ride. Range: 0-30, NULL.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
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
                    if (!byte.TryParse(value, out byte result) || result > 30)
                        throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 30, or NULL.");
                    else
                        this._autosculpt_rearbumper = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}