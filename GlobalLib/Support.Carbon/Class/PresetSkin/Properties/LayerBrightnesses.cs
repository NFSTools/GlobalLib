namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetSkin : Shared.Class.PresetSkin, Reflection.Interface.ICastable<PresetSkin>
    {
        /// <summary>
        /// Brightness value of the first color of the vector vinyl of the preset skin.
        /// </summary>
        public byte Brightness1 { get; set; } = 0;

        /// <summary>
        /// Brightness value of the second color of the vector vinyl of the preset skin.
        /// </summary>
        public byte Brightness2 { get; set; } = 0;

        /// <summary>
        /// Brightness value of the third color of the vector vinyl of the preset skin.
        /// </summary
        public byte Brightness3 { get; set; } = 0;

        /// <summary>
        /// Brightness value of the fourth color of the vector vinyl of the preset skin.
        /// </summary
        public byte Brightness4 { get; set; } = 0;
    }
}