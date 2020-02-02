namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _collision_external_name = Reflection.BaseArguments.NULL;

        /// <summary>
        /// Represents external collision name of the cartypeinfo.
        /// </summary>
        public string CollisionExternalName
        {
            get => this._collision_external_name;
            set
            {
                if (value != Reflection.BaseArguments.NULL && value != this._collection_name)
                    throw new Reflection.Exception.MappingFailException();
                else
                    this._collision_external_name = value;
            }
        }
    }
}