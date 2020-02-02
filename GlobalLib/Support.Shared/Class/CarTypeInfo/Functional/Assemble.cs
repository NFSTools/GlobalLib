namespace GlobalLib.Support.Shared.Class
{
    public partial class CarTypeInfo : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        /// <summary>
        /// Assembles cartypeinfo into a byte array.
        /// </summary>
        /// <param name="index">Index of the cartypeinfo.</param>
        /// <returns>Byte array of the cartypeinfo.</returns>
        public virtual unsafe byte[] Assemble(int index) { return null; }
    }
}