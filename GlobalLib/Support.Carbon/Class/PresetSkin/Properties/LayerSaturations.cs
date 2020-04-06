using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin
    {
        /// <summary>
        /// Saturation value of the first color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte Saturation1 { get; set; } = 0;

        /// <summary>
        /// Saturation value of the second color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte Saturation2 { get; set; } = 0;

        /// <summary>
        /// Saturation value of the third color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte Saturation3 { get; set; } = 0;

        /// <summary>
        /// Saturation value of the fourth color of the vector vinyl of the preset skin.
        /// </summary>
        [AccessModifiable()]
        [StaticModifiable()]
        public byte Saturation4 { get; set; } = 0;
    }
}