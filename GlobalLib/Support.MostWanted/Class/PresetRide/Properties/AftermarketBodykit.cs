namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private sbyte _aftermarket_bodykit = 0;

        /// <summary>
        /// Aftermarket bodykit value of the preset ride. Range: 0-5, NULL.
        /// </summary>
        public string AftermarketBodykit
        {
            get
            {
                if (this._aftermarket_bodykit == -1)
                    return Reflection.BaseArguments.NULL;
                else
                    return this._aftermarket_bodykit.ToString();
            }
            set
            {
                if (value == Reflection.BaseArguments.NULL)
                    this._aftermarket_bodykit = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 5)
                        throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 5, or NULL.");
                    else
                    {
                        this._aftermarket_bodykit = (sbyte)result;
                    }
                    this.Modified = true;
                }
            }
        }
    }
}