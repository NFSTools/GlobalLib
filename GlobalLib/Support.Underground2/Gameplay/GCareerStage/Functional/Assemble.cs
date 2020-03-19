﻿namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		public unsafe void Assemble(byte* byteptr_t)
		{
			Utils.FormatX.GetByte(this._collection_name, "STAGE_{X}", out byte stage);
			*byteptr_t = stage;
			*(byteptr_t + 0x01) = this.NumberOfSponsorsToChoose;
			*(short*)(byteptr_t + 0x02) = this.OutrunCashValue;
			*(short*)(byteptr_t + 0x04) = this.Unknown0x04;
			*(short*)(byteptr_t + 0x06) = this.Unknown0x06;

			*(uint*)(byteptr_t + 0x08) = Utils.Bin.SmartHash(this._stage_sponsor1);
			*(uint*)(byteptr_t + 0x0C) = Utils.Bin.SmartHash(this._stage_sponsor2);
			*(uint*)(byteptr_t + 0x10) = Utils.Bin.SmartHash(this._stage_sponsor3);
			*(uint*)(byteptr_t + 0x14) = Utils.Bin.SmartHash(this._stage_sponsor4);
			*(uint*)(byteptr_t + 0x18) = Utils.Bin.SmartHash(this._stage_sponsor5);

			*(short*)(byteptr_t + 0x1C) = this.AttribSponsor1;
			*(short*)(byteptr_t + 0x1E) = this.AttribSponsor2;
			*(short*)(byteptr_t + 0x20) = this.AttribSponsor3;
			*(short*)(byteptr_t + 0x22) = this.AttribSponsor4;
			*(short*)(byteptr_t + 0x24) = this.AttribSponsor5;
			*(short*)(byteptr_t + 0x26) = this.Unknown0x26;

			*(uint*)(byteptr_t + 0x28) = Utils.Bin.SmartHash(this.LastStageEvent);

			*(byteptr_t + 0x2C) = this.Unknown0x2C;
			*(byteptr_t + 0x2D) = this.Unknown0x2D;
			*(byteptr_t + 0x2E) = this.Unknown0x2E;
			*(byteptr_t + 0x2F) = this.Unknown0x2F;

			*(byteptr_t + 0x30) = this.MaxCircuitsShownOnMap;
			*(byteptr_t + 0x31) = this.MaxDragsShownOnMap;
			*(byteptr_t + 0x32) = this.MaxStreetXShownOnMap;
			*(byteptr_t + 0x33) = this.MaxDriftsShownOnMap;
			*(byteptr_t + 0x34) = this.MaxSprintsShownOnMap;

			*(byteptr_t + 0x35) = this.Unknown0x35;
			*(byteptr_t + 0x36) = this.Unknown0x36;
			*(byteptr_t + 0x37) = this.Unknown0x37;
			*(byteptr_t + 0x38) = this.Unknown0x38;
			*(byteptr_t + 0x39) = this.Unknown0x39;
			*(byteptr_t + 0x3A) = this.Unknown0x3A;
			*(byteptr_t + 0x3B) = this.Unknown0x3B;
			*(byteptr_t + 0x3C) = this.Unknown0x3C;
			*(byteptr_t + 0x3D) = this.Unknown0x3D;
			*(byteptr_t + 0x3E) = this.Unknown0x3E;
			*(byteptr_t + 0x3F) = this.Unknown0x3F;

			*(byteptr_t + 0x40) = this.MaxOutrunEvents;
			*(byteptr_t + 0x41) = this.Unknown0x41;
			*(byteptr_t + 0x42) = this.Unknown0x42;
			*(byteptr_t + 0x43) = this.Unknown0x43;
			*(float*)(byteptr_t + 0x44) = this.Unknown0x44;
			*(float*)(byteptr_t + 0x48) = this.Unknown0x48;
			*(float*)(byteptr_t + 0x4C) = this.Unknown0x4C;
		}
	}
}