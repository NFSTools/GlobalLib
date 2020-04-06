using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
        private eSpoiler _spoiler = eSpoiler.SPOILER;
        private eMirrorTypes _mirrors = eMirrorTypes.MIRRORS;

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

        [AccessModifiable()]
        [StaticModifiable()]
        public eMirrorTypes Mirrors
        {
            get => this._mirrors;
            set
            {
                if (Enum.IsDefined(typeof(eMirrorTypes), value))
                    this._mirrors = value;
                else
                    throw new MappingFailException();
            }
        }
    }
}