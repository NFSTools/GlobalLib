namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		private unsafe void Disassemble(byte* ptr_header, byte* ptr_string)
		{
			// CollectionName
			ushort pointer = *(ushort*)ptr_header;
			this._collection_name = Utils.ScriptX.NullTerminatedString(ptr_string + pointer);
			
			// Cash Values
			this.CashValuePerWin = *(short*)(ptr_header + 2);
			this.SignCashBonus = *(short*)(ptr_header + 12);
			this.PotentialCashBonus = *(short*)(ptr_header + 14);

			// Required Sponsor Races
			this.ReqSponsorRace1 = (Reflection.Enum.eSponsorRaceType)(*(ptr_header + 4));
			this.ReqSponsorRace2 = (Reflection.Enum.eSponsorRaceType)(*(ptr_header + 5));
			this.ReqSponsorRace3 = (Reflection.Enum.eSponsorRaceType)(*(ptr_header + 6));
		}
	}
}