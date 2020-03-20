namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private string _wing_mirror_style = Reflection.BaseArguments.STOCK;

        /// <summary>
        /// Wing mirror style value of the preset ride. Range: 0-40.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string WingMirrorStyle
        {
            get => this._wing_mirror_style;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value == Reflection.BaseArguments.NULL)
                    throw new System.Exception("This value can be only STOCK or a hexadecimal hash of a mirror style.");
                this._wing_mirror_style = value;
                this.Modified = true;
            }
        }
    }
}