namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private byte _roofscoop_style = 0;
        private Reflection.Enum.eBoolean _is_autosculpt_roofscoop = Reflection.Enum.eBoolean.False;
        private Reflection.Enum.eBoolean _is_dual_roofscoop = Reflection.Enum.eBoolean.False;
        private Reflection.Enum.eBoolean _is_carbonfibre_roofscoop = Reflection.Enum.eBoolean.False;

        /// <summary>
        /// RoofScoop style value of the preset ride. Range: 0-18.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte RoofScoopStyle
        {
            get => this._roofscoop_style;
            set
            {
                if (value > 18)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 18.");
                else
                    this._roofscoop_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if roof scoop is autosculpt, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eBoolean IsAutosculptRoofScoop
        {
            get => this._is_autosculpt_roofscoop;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_autosculpt_roofscoop = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if roof scoop is dual, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eBoolean IsDualRoofScoop
        {
            get => this._is_dual_roofscoop;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_dual_roofscoop = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }

        /// <summary>
        /// True if roof scoop is carbonfibre, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eBoolean IsCarbonfibreRoofScoop
        {
            get => this._is_carbonfibre_roofscoop;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_carbonfibre_roofscoop = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}