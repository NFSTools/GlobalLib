namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private sbyte _aftermarket_bodykit = 0;

        /// <summary>
        /// Aftermarket bodykit value of the preset ride. Range: 0-4, NULL.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
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
                    if (!byte.TryParse(value, out byte result) || result > 4)
                        throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 4, or NULL.");
                    else
                        this._aftermarket_bodykit = (sbyte)result;
                }
                this.Modified = true;
            }
        }
    }
}