namespace GlobalLib.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private string _sun_info_name = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Represents sun type during race.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string SunInfoName
        {
            get => this._sun_info_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value == Reflection.BaseArguments.NULL)
                    this._sun_info_name = value;
                else if (value.StartsWith("0x") && Utils.ConvertX.ToUInt32(value) != 0)
                    this._sun_info_name = value;
                else
                {
                    if (this.Database.SunInfos.Classes.ContainsKey(value))
                        throw new Reflection.Exception.MappingFailException();
                    else
                        this._sun_info_name = value;
                }
            }
        }
    }
}