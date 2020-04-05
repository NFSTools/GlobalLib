using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        private string _specific_vinyl = BaseArguments.NULL;
        private string _generic_vinyl = BaseArguments.NULL;

        /// <summary>
        /// Specific vinyl value of the preset ride.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string SpecificVinyl
        {
            get => this._specific_vinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._specific_vinyl = value;
                this.Modified = true;
            }
        }

        /// <summary>
        /// Generic vinyl value of the preset car.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public string GenericVinyl
        {
            get => this._generic_vinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be left empty.");
                this._generic_vinyl = value;
                this.Modified = true;
            }
        }
    }
}