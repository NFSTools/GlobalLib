using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        private eSpoilerAS2 _spoilerAS = eSpoilerAS2.SPOILER_AS2;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public eSpoilerAS2 SpoilerAS
        {
            get => this._spoilerAS;
            set
            {
                if (Enum.IsDefined(typeof(eSpoilerAS2), value))
                    this._spoilerAS = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}