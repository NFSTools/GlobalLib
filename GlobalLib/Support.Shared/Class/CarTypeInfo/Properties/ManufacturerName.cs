﻿namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo
    {
        private string _manufacturer_name;

        /// <summary>
        /// Represents manufacturer name of the cartypeinfo.
        /// </summary>
        [Reflection.Attributes.AccessModifiable()]
        public string ManufacturerName
        {
            get => this._manufacturer_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                if (value.Length > 15)
                    throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 15 characters.");
                this._manufacturer_name = value;
            }
        }
    }
}