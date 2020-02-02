namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private sbyte _exhaust_style = 0;
        private byte _exhaust_size = 0;
        private bool _is_center_exhaust = false;


        /// <summary>
        /// Exhaust style value of the preset ride. Possible values: 0-17, NULL.
        /// </summary>
        public string ExhaustStyle
        {
            get
            {
                if (this._exhaust_style == -1)
                    return Reflection.BaseArguments.NULL;
                else
                    return this._exhaust_style.ToString();
            }
            set
            {
                if (value == Reflection.BaseArguments.NULL)
                    this._exhaust_style = -1;
                else
                {
                    if (!byte.TryParse(value, out byte result) || result > 17)
                        throw new System.ArgumentOutOfRangeException();
                    else
                        this._exhaust_style = (sbyte)result;
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// Exhaust size value of the preset ride. Range: 0-100.
        /// </summary>
        public byte ExhaustSize
        {
            get => this._exhaust_size;
            set
            {
                if (value > 100)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._exhaust_size = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if exhaust is centered, false otherwise.
        /// </summary>
        public bool IsCenterExhaust
        {
            get => this._is_center_exhaust;
            set
            {
                this._is_center_exhaust = value;
                this.Modified = true;
            }
        }
    }
}