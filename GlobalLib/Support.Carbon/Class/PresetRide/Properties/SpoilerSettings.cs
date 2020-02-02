namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _spoiler_style = 0;
        private string _spoiler_type = Reflection.BaseArguments.STOCK;
        private bool _is_autosculpt_spoiler = false;
        private bool _is_carbonfibre_spoiler = false;

        /// <summary>
        /// Spoiler style of the preset ride. Range: 0-29.
        /// </summary>
        public byte SpoilerStyle
        {
            get => this._spoiler_style;
            set
            {
                if (value > 29)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._spoiler_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Spoiler type of the preset ride. Range: STOCK, BASE, _HATCH, _PORSCHES, _CARRERA, NULL.
        /// </summary>
        public string SpoilerType
        {
            get => this._spoiler_type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                switch (value)
                {
                    case Reflection.BaseArguments.NULL:
                    case Reflection.BaseArguments.STOCK:
                    case Reflection.Info.STypes.BASE:
                    case Reflection.Info.STypes._HATCH:
                    case Reflection.Info.STypes._PORSCHES:
                    case Reflection.Info.STypes._CARRERA:
                        _spoiler_type = value;
                        break;
                    default:
                        throw new Reflection.Exception.MappingFailException();
                }
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if spoiler is autosculpt, false otherwise.
        /// </summary>
        public bool IsAutosculptSpoiler
        {
            get => this._is_autosculpt_spoiler;
            set
            {
                this._is_autosculpt_spoiler = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if spoiler is carbonfibre, false otherwise.
        /// </summary>
        public bool IsCarbonfibreSpoiler
        {
            get => this._is_carbonfibre_spoiler;
            set
            {
                this._is_carbonfibre_spoiler = value;
                this.Modified = true;
            }
        }
    }
}