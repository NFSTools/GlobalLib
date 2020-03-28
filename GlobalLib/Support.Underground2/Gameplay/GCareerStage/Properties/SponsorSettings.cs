namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class GCareerStage
	{
		private string _stage_sponsor1 = Reflection.BaseArguments.NULL;
		private string _stage_sponsor2 = Reflection.BaseArguments.NULL;
		private string _stage_sponsor3 = Reflection.BaseArguments.NULL;
		private string _stage_sponsor4 = Reflection.BaseArguments.NULL;
		private string _stage_sponsor5 = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string StageSponsor1
		{
			get => this._stage_sponsor1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor1 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string StageSponsor2
		{
			get => this._stage_sponsor2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor2 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string StageSponsor3
		{
			get => this._stage_sponsor3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor3 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string StageSponsor4
		{
			get => this._stage_sponsor4;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor4 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string StageSponsor5
		{
			get => this._stage_sponsor5;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._stage_sponsor5 = value;
			}
		}
	}
}