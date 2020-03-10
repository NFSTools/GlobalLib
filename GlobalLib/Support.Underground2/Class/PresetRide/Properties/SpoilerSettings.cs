﻿namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
	{
        private byte _spoiler_style = 0;
        private string _spoiler_type = Reflection.BaseArguments.STOCK;
        private Reflection.Enum.eBoolean _is_carbonfibre_spoiler = Reflection.Enum.eBoolean.False;

        /// <summary>
        /// Spoiler style of the preset ride. Range: 0-40.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public byte SpoilerStyle
        {
            get => this._spoiler_style;
            set
            {
                if (value > 40)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 40.");
                else
                    this._spoiler_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Spoiler type of the preset ride. Range: STOCK, BASE, _HATCH, _SUV, NULL.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string SpoilerType
        {
            get => this._spoiler_type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                switch (value)
                {
                    case Reflection.BaseArguments.NULL:
                    case Reflection.BaseArguments.STOCK:
                    case Reflection.Info.STypes.BASE:
                    case Reflection.Info.STypes._HATCH:
                    case Reflection.Info.STypes._SUV:
                        _spoiler_type = value;
                        break;
                    default:
                        throw new Reflection.Exception.MappingFailException();
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if spoiler is carbonfibre, false otherwise.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public Reflection.Enum.eBoolean IsCarbonfibreSpoiler
        {
            get => this._is_carbonfibre_spoiler;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
                {
                    this._is_carbonfibre_spoiler = value;
                    this.Modified = true;
                }
                else
                    throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
            }
        }
    }
}