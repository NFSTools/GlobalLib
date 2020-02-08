namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
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