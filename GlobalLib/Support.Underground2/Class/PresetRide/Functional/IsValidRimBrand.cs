﻿using GlobalLib.Core;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
        /// <summary>
        /// Checks if a value passed is a valid rim brand that exists in the map.
        /// </summary>
        /// <param name="brand">Rim brand value to check.</param>
        /// <returns>True if value passed is valid, false otherwise.</returns>
        private bool IsValidRimBrand(string brand)
        {
            foreach (var str in Map.RimBrands)
            {
                if (str.StartsWith(brand))
                    return true;
            }
            return false;
        }
    }
}