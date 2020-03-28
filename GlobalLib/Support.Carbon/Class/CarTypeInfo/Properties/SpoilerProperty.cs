namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        private Reflection.Enum.eSpoiler _spoiler = Reflection.Enum.eSpoiler.SPOILER;

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
    }
}