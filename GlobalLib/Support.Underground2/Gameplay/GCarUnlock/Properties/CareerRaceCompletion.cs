using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCarUnlock
	{
		private string _req_event_completed1 = BaseArguments.NULL;
		private string _req_event_completed2 = BaseArguments.NULL;

		[AccessModifiable()]
		[StaticModifiable()]
		public string ReqEventCompleted1
		{
			get => this._req_event_completed1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._req_event_completed1 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string ReqEventCompleted2
		{
			get => this._req_event_completed2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._req_event_completed2 = value;
			}
		}
	}
}