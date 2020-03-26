namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class AudioBuffers : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<AudioBuffers>
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

		public string AudioCompSmall00
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

		public string AudioCompSmall01
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

		public string AudioCompMedium02
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

		public string AudioCompMedium03
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

		public string AudioCompLarge04
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

		public string AudioCompLarge05
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

		public string AudioCompSmall06
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

		public string AudioCompSmall07
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

		public string AudioCompSmall08
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

		public string AudioCompSmall09
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

		public string AudioCompMedium10
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

		public string AudioCompMedium11
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

		public unsafe void Read(byte* byteptr_t)
		{
			uint key = 0;

			key = *(uint*)byteptr_t;
			this._audio_comp_00 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x04);
			this._audio_comp_01 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x08);
			this._audio_comp_02 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x0C);
			this._audio_comp_03 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x10);
			this._audio_comp_04 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x14);
			this._audio_comp_05 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x18);
			this._audio_comp_06 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x1C);
			this._audio_comp_07 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x20);
			this._audio_comp_08 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x24);
			this._audio_comp_09 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x28);
			this._audio_comp_10 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x2C);
			this._audio_comp_11 = Core.Map.Lookup(key, true) ?? Reflection.BaseArguments.NULL;
		}

		public unsafe void Write(byte* byteptr_t)
		{
			*(uint*)byteptr_t = Utils.Bin.SmartHash(this._audio_comp_00);
			*(uint*)(byteptr_t + 0x04) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x08) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x0C) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x10) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x14) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x18) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x1C) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x20) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x24) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x28) = Utils.Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x2C) = Utils.Bin.SmartHash(this._audio_comp_01);
		}
	}
}
