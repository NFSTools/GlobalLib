namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class Track : Reflection.Interface.ICastable<Track>, Reflection.Interface.IGetValue,
		Reflection.Interface.ISetValue
	{
		/* 0x0084 */ public bool IsValidRace { get; set; } = true;
		/* 0x0085 */ public bool IsLoopingRace { get; set; } = false;
		/* 0x0086 */ public bool ReverseVersionExists { get; set; } = true;
		/* 0x0088 */ public bool IsPerformanceTuning { get; set; } = false;
		/* 0x008A - 0x008E */ private ushort _track_id;
	}
}