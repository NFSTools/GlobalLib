namespace GlobalLib.Support.Underground2.Gameplay
{
    public partial class Track : Reflection.Interface.ICastable<Track>, Reflection.Interface.IGetValue,
        Reflection.Interface.ISetValue
    {
        /* 0x0090 */ private string _sun_info_name_hash = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Represents sun type during race.
        /// </summary>
        public string SunInfoNameHash
        {
            get => this._sun_info_name_hash;
            set
            {
                if (value.StartsWith("0x") && Utils.ConvertX.ToUInt32(value) != 0)
                    this._sun_info_name_hash = value;
                else
                {
                    if (this.Database.GetClassIndex(value, GlobalLib.Database.ClassType.SunInfoType) == -1)
                        throw new Reflection.Exception.MappingFailException();
                    this._sun_info_name_hash = value;
                }
            }
        }
    }
}