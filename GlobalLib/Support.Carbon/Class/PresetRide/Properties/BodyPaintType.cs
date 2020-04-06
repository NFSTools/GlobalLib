using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private eCarbonPaint _paint_type = eCarbonPaint.GLOSS;

        /// <summary>
        /// Paint type value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eCarbonPaint PaintType
        {
            get => this._paint_type;
            set
            {
                if (Enum.IsDefined(typeof(eCarbonPaint), value))
                {
                    this._paint_type = value;
                    this.Modified = true;
                }
                else
                    throw new MappingFailException();
            }
        }
    }
}