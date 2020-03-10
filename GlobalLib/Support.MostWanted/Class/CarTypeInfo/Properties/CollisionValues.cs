﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class CarTypeInfo
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
                    throw new Reflection.Exception.MappingFailException("Value passed should be either equal to CollectionName, or be NULL.");
                else
                    this._collision_external_name = value;
            }
        }

        /// <summary>
        /// Represents internal collision name of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public override string CollisionInternalName { get => base.CollisionInternalName; set => base.CollisionInternalName = value; }
    }
}