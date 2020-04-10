using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground1.Gameplay
{
	public partial class SunInfo
	{
        /// <summary>
        /// Casts all attributes from this object to another one.
        /// </summary>
        /// <param name="CName">CollectionName of the new created object.</param>
        /// <returns>Memory casted copy of the object.</returns>
        public override Collectable MemoryCast(string CName)
		{
			var result = new SunInfo(CName, this.Database);
            result.Version = this.Version;
            result.PositionX = this.PositionX;
            result.PositionY = this.PositionY;
            result.PositionZ = this.PositionZ;
            result.CarShadowPositionX = this.CarShadowPositionX;
            result.CarShadowPositionY = this.CarShadowPositionY;
            result.CarShadowPositionZ = this.CarShadowPositionZ;
            result.SUNLAYER1 = this.SUNLAYER1.PlainCopy();
            result.SUNLAYER2 = this.SUNLAYER2.PlainCopy();
            result.SUNLAYER3 = this.SUNLAYER3.PlainCopy();
            result.SUNLAYER4 = this.SUNLAYER4.PlainCopy();
            result.SUNLAYER5 = this.SUNLAYER5.PlainCopy();
            result.SUNLAYER6 = this.SUNLAYER6.PlainCopy();
            return result;
        }
    }
}