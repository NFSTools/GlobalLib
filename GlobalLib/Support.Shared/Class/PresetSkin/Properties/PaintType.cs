namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _painttype = Reflection.BaseArguments.PPAINT;

        /// <summary>
        /// Paint type value of the preset skin.
        /// </summary>
        public string PaintType
        {
            get => this._painttype;
            set
            {
                if (Core.Map.RaiderKeys.ContainsValue(value))
                    this._painttype = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}