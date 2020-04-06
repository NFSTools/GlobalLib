using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class CarTypeInfo
    {
        private string _collision_external_name = BaseArguments.NULL;

        /// <summary>
        /// Represents external collision name of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        public string CollisionExternalName
        {
            get => this._collision_external_name;
            set
            {
                if (value != BaseArguments.NULL && value != this._collection_name)
                    throw new MappingFailException("Value passed should be either equal to CollectionName, or be NULL.");
                else
                    this._collision_external_name = value;
            }
        }

        /// <summary>
        /// Represents internal collision name of the cartypeinfo.
        /// </summary>
        [AccessModifiable()]
        public override string CollisionInternalName { get => base.CollisionInternalName; set => base.CollisionInternalName = value; }
    }
}