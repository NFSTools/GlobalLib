﻿namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        private Reflection.Enum.eSpoilerAS2 _spoilerAS = Reflection.Enum.eSpoilerAS2.SPOILER_AS2;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        [Reflection.Attributes.StaticModifiable()]
        public Reflection.Enum.eSpoilerAS2 SpoilerAS
        {
            get => this._spoilerAS;
            set
            {
                if (System.Enum.IsDefined(typeof(Reflection.Enum.eSpoilerAS2), value))
                    this._spoilerAS = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}