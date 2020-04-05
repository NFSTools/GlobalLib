using GlobalLib.Reflection.Abstract;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		public override Collectable MemoryCast(string CName)
		{
			var result = new GCarUnlock(CName, this.Database);
			result._req_event_completed1 = this._req_event_completed1;
			result._req_event_completed2 = this._req_event_completed2;
			return result;
		}
	}
}