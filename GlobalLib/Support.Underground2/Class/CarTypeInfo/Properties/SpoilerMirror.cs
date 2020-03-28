﻿namespace GlobalLib.Support.Underground2.Class
{
	public partial class CarTypeInfo
	{
        private Reflection.Enum.eSpoiler _spoiler = Reflection.Enum.eSpoiler.SPOILER;
        private Reflection.Enum.eMirrorTypes _mirrors = Reflection.Enum.eMirrorTypes.MIRRORS;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eSpoiler Spoiler
        {
            get => this._spoiler;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eSpoiler), value))
                    this._spoiler = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }

        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eMirrorTypes Mirrors
        {
            get => this._mirrors;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eMirrorTypes), value))
                    this._mirrors = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}