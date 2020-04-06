using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private byte _trunk_audio_style = 0;

        /// <summary>
        /// Hood style value of the preset ride. Range: 0-3.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte TrunkAudioStyle
        {
            get => this._trunk_audio_style;
            set
            {
                if (value > 3)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 3.");
                else
                    this._trunk_audio_style = value;
                this.Modified = true;
            }
        }

    }
}