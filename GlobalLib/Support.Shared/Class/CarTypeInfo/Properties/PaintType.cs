namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo
    {
        private string _defaultbasepaint = Reflection.BaseArguments.BPAINT;

        /// <summary>
        /// Represents paint type of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string DefaultBasePaint
        {
            get => this._defaultbasepaint;
            set
            {
                if (Core.Map.BinKeys.ContainsValue(value))
                    this._defaultbasepaint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}