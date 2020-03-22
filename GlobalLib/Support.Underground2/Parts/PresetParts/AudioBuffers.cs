namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class AudioBuffers : Framework.VirtualPart, Reflection.Interface.ICopyable<AudioBuffers>
	{
		#region Private Fields

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

		#endregion

		#region Public Properties

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

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
			}
		}

		#endregion

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public AudioBuffers PlainCopy()
		{
			var result = new AudioBuffers();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisField in ThisType.GetFields())
			{
				var ResultField = ResultType.GetProperty(ThisField.Name);
				ResultField.SetValue(result, ThisField.GetValue(this));
			}
			return result;
		}
	}
}
