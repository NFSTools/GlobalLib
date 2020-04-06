using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private string _window_tint_type = BaseArguments.STOCK;

        /// <summary>
        /// Window tint type value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string WindowTintType
        {
            get => this._window_tint_type;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                if (value == BaseArguments.STOCK || Map.WindowTintMap.Contains(value))
                    this._window_tint_type = value;
                else
                    throw new MappingFailException("This value should be either a valid windshield type, or STOCK.");
                this.Modified = true;
            }
        }
    }
}