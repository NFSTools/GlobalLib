namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        private string _spoiler = Reflection.Info.Spoiler.BASE;

        /// <summary>
        /// Aftermarket spoiler type of the cartypeinfo.
        /// </summary>
        public string Spoiler
        {
            get => this._spoiler;
            set
            {
                switch (value)
                {
                    case Reflection.Info.Spoiler.BASE:
                    case Reflection.Info.Spoiler._HATCH:
                    case Reflection.Info.Spoiler._PORSCHES:
                    case Reflection.Info.Spoiler._CARRERA:
                        this._spoiler = value;
                        break;
                    default:
                        throw new Reflection.Exception.MappingFailException();
                }
            }
        }
    }
}