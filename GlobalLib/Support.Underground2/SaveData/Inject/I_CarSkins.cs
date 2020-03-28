﻿namespace GlobalLib.Support.Underground2
{
	public static partial class SaveData
	{
		private static void I_CarSkins(Database.Underground2 db, System.IO.BinaryWriter bw)
		{
			bw.Write(Reflection.ID.Global.CarSkins);
			bw.Write(-1);
			var pos = bw.BaseStream.Position;
			int a1 = 0;
			foreach (var car in db.CarTypeInfos.Collections)
				bw.Write(car.GetCarSkins(a1++));
			bw.BaseStream.Position = pos - 4;
			bw.Write((int)(bw.BaseStream.Length - pos));
			bw.BaseStream.Position = bw.BaseStream.Length;
		}
	}
}