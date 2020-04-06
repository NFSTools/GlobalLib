using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        private string _wing_mirror_style = BaseArguments.STOCK;

        /// <summary>
        /// Wing mirror style value of the preset ride. Range: 0-40.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string WingMirrorStyle
        {
            get => this._wing_mirror_style;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                if (value == BaseArguments.NULL)
                    throw new Exception("This value can be only STOCK or a hexadecimal hash of a mirror style.");
                this._wing_mirror_style = value;
                this.Modified = true;
            }
        }
    }
}