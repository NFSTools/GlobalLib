namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _defaultbasepaint = Reflection.BaseArguments.BPAINT;

        /// <summary>
        /// Represents paint type of the cartypeinfo.
        /// </summary>
        public string DefaultBasePaint
        {
            get => this._defaultbasepaint;
            set
            {
                if (Core.Map.RaiderKeys.ContainsValue(value))
                    this._defaultbasepaint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}