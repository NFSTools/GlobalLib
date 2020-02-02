namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        private string _spoilerAS = Reflection.Info.SpoilerAS.BASE;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        public string SpoilerAS
        {
            get => this._spoilerAS;
            set
            {
                switch (value)
                {
                    case Reflection.Info.SpoilerAS.BASE:
                    case Reflection.Info.SpoilerAS._HATCH:
                    case Reflection.Info.SpoilerAS._PORSCHES:
                    case Reflection.Info.SpoilerAS._CARRERA:
                        this._spoilerAS = value;
                        break;
                    default:
                        throw new Reflection.Exception.MappingFailException();
                }
            }
        }
    }
}