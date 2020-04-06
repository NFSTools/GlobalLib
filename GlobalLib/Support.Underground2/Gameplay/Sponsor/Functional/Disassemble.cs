using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Sponsor
	{
		private unsafe void Disassemble(byte* ptr_header, byte* ptr_string)
		{
			// CollectionName
			ushort pointer = *(ushort*)ptr_header;
			this._collection_name = ScriptX.NullTerminatedString(ptr_string + pointer);
			
			// Cash Values
			this.CashValuePerWin = *(short*)(ptr_header + 2);
			this.SignCashBonus = *(short*)(ptr_header + 12);
			this.PotentialCashBonus = *(short*)(ptr_header + 14);

			// Required Sponsor Races
			this.ReqSponsorRace1 = (eSponsorRaceType)(*(ptr_header + 4));
			this.ReqSponsorRace2 = (eSponsorRaceType)(*(ptr_header + 5));
			this.ReqSponsorRace3 = (eSponsorRaceType)(*(ptr_header + 6));
		}
	}
}