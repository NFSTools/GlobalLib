using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		private string _stage_sponsor1 = BaseArguments.NULL;
		private string _stage_sponsor2 = BaseArguments.NULL;
		private string _stage_sponsor3 = BaseArguments.NULL;
		private string _stage_sponsor4 = BaseArguments.NULL;
		private string _stage_sponsor5 = BaseArguments.NULL;

		[AccessModifiable()]
		public string StageSponsor1
		{
			get => this._stage_sponsor1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor1 = value;
			}
		}

		[AccessModifiable()]
		public string StageSponsor2
		{
			get => this._stage_sponsor2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor2 = value;
			}
		}

		[AccessModifiable()]
		public string StageSponsor3
		{
			get => this._stage_sponsor3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor3 = value;
			}
		}

		[AccessModifiable()]
		public string StageSponsor4
		{
			get => this._stage_sponsor4;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor4 = value;
			}
		}

		[AccessModifiable()]
		public string StageSponsor5
		{
			get => this._stage_sponsor5;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor5 = value;
			}
		}
	}
}