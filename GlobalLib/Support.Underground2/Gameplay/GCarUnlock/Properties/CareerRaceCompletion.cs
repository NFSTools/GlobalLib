namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		private string _req_event_completed1 = Reflection.BaseArguments.NULL;
		private string _req_event_completed2 = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string ReqEventCompleted1
		{
			get => this._req_event_completed1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (this.Database.GCareerRaces.Classes.ContainsKey(value))
					throw new Reflection.Exception.MappingFailException("Career Event with the given CollectionName does not exist.");
				this._req_event_completed1 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string ReqEventCompleted2
		{
			get => this._req_event_completed2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (this.Database.GCareerRaces.Classes.ContainsKey(value))
					throw new Reflection.Exception.MappingFailException("Career Event with the given CollectionName does not exist.");
				this._req_event_completed2 = value;
			}
		}
	}
}