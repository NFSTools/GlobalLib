namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin
    {
        private string _painttype = Reflection.BaseArguments.PPAINT;

        /// <summary>
        /// Paint type value of the preset skin.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string PaintType
        {
            get => this._painttype;
            set
            {
                if (Core.Map.BinKeys.ContainsValue(value))
                    this._painttype = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}