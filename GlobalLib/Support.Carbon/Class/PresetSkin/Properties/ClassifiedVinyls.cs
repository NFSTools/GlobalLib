namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin, Reflection.Interface.ICastable<PresetSkin>
    {
        private string _genericvinyl = Reflection.BaseArguments.NULL;
        private string _vectorvinyl = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Generic vinyl value of the preset skin.
        /// </summary>
        public string GenericVinyl
        {
            get => this._genericvinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._genericvinyl = value;
            }
        }

        /// <summary>
        /// Vector vinyl value of the preset skin.
        /// </summary>
        public string VectorVinyl
        {
            get => this._vectorvinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                this._vectorvinyl = value;
            }
        }
    }
}