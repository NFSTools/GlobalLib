namespace GlobalLib.Support.MostWanted.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        private byte _hood_style = 0;
        private bool _is_carbonfibre_hood = false;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-32.
        /// </summary>
        public byte HoodStyle
        {
            get => this._hood_style;
            set
            {
                if (value > 32)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._hood_style = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// True if hood is carbonfibre, false otherwise.
        /// </summary>
        public bool IsCarbonfibreHood
        {
            get => this._is_carbonfibre_hood;
            set
            {
                this._is_carbonfibre_hood = value;
                this.Modified = true;
            }
        }
    }
}