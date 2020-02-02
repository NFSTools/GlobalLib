namespace GlobalLib.Support.Shared.Class
{
    public partial class Texture : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Represents data offset of the block in Global data.
        /// </summary>
        public int Offset { get; protected set; } = 0;

        /// <summary>
        /// Represents data size of the block in Global data.
        /// </summary>
        public int Size { get; protected set; } = 0;

        /// <summary>
        /// Represents palette offset of the block in Global data.
        /// </summary>
        public int PaletteOffset { get; protected set; } = 0;

        /// <summary>
        /// Represents palette size of the block in Global data.
        /// </summary>
        public int PaletteSize { get; protected set; } = 0;
    }
}