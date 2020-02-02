namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _collision_internal_name = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Represents internal collision name of the cartypeinfo.
        /// </summary>
        public string CollisionInternalName
        {
            get => this._collision_internal_name;
            set
            {
                if (value == Reflection.BaseArguments.NULL || Core.Map.CollisionMap.ContainsValue(value))
                    this._collision_internal_name = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}