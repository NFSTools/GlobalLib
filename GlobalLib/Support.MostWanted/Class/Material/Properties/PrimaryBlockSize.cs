namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        /// <summary>
        /// Size of one material block.
        /// </summary>
        public int Size { get; } = 0xA8;
    }
}