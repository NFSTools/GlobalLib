﻿namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private byte _engine_style = 0;

        /// <summary>
        /// Engine style value of the preset ride. Range: 0-3.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public byte EngineStyle
        {
            get => this._engine_style;
            set
            {
                if (value > 3)
                    throw new System.ArgumentOutOfRangeException("This value should be in range 0 to 3.");
                else
                    this._engine_style = value;
                this.Modified = true;
            }
        }
    }
}