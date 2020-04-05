using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
    public partial class Track
    {
        private string _sun_info_name = BaseArguments.NULL;

        /// <summary>
        /// Represents sun type during race.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string SunInfoName
        {
            get => this._sun_info_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._sun_info_name = value;
            }
        }
    }
}