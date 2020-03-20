namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private string _audio_comp_00 = Reflection.BaseArguments.NULL;
		private string _audio_comp_01 = Reflection.BaseArguments.NULL;
		private string _audio_comp_02 = Reflection.BaseArguments.NULL;
		private string _audio_comp_03 = Reflection.BaseArguments.NULL;
		private string _audio_comp_04 = Reflection.BaseArguments.NULL;
		private string _audio_comp_05 = Reflection.BaseArguments.NULL;
		private string _audio_comp_06 = Reflection.BaseArguments.NULL;
		private string _audio_comp_07 = Reflection.BaseArguments.NULL;
		private string _audio_comp_08 = Reflection.BaseArguments.NULL;
		private string _audio_comp_09 = Reflection.BaseArguments.NULL;
		private string _audio_comp_10 = Reflection.BaseArguments.NULL;
		private string _audio_comp_11 = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp00
		{
			get => this._audio_comp_00;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_00 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp01
		{
			get => this._audio_comp_01;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_01 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp02
		{
			get => this._audio_comp_02;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_02 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp03
		{
			get => this._audio_comp_03;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_03 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp04
		{
			get => this._audio_comp_04;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_04 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp05
		{
			get => this._audio_comp_05;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_05 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp06
		{
			get => this._audio_comp_06;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_06 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp07
		{
			get => this._audio_comp_07;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_07 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp08
		{
			get => this._audio_comp_08;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_08 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp09
		{
			get => this._audio_comp_09;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_09 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp10
		{
			get => this._audio_comp_10;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_10 = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string AudioComp11
		{
			get => this._audio_comp_11;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				if (value != Reflection.BaseArguments.NULL && !Core.Map.AudioTypes.Contains(value))
					throw new Reflection.Exception.MappingFailException();
				this._audio_comp_11 = value;
				this.Modified = true;
			}
		}
	}
}