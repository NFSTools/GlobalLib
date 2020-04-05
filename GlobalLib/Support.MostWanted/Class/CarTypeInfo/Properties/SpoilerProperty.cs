using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
    {
        private eSpoiler _spoiler = eSpoiler.SPOILER;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eSpoiler Spoiler
        {
            get => this._spoiler;
            set
            {
                if (Enum.IsDefined(typeof(eSpoiler), value))
                    this._spoiler = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}