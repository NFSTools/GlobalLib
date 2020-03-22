namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class DecalArray : Framework.VirtualPart, Reflection.Interface.ICopyable<DecalArray>
	{
		#region Private Fields

		private string _decal_slot0 = Reflection.BaseArguments.NULL;
		private string _decal_slot1 = Reflection.BaseArguments.NULL;
		private string _decal_slot2 = Reflection.BaseArguments.NULL;
		private string _decal_slot3 = Reflection.BaseArguments.NULL;
		private string _decal_slot4 = Reflection.BaseArguments.NULL;
		private string _decal_slot5 = Reflection.BaseArguments.NULL;
		private string _decal_slot6 = Reflection.BaseArguments.NULL;
		private string _decal_slot7 = Reflection.BaseArguments.NULL;

		#endregion

		#region Public Properties

		public string DecalSlot0
		{
			get => this._decal_slot0;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot0 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot0 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot1
		{
			get => this._decal_slot1;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot1 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot1 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot2
		{
			get => this._decal_slot2;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot2 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot2 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot3
		{
			get => this._decal_slot3;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot3 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot3 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot4
		{
			get => this._decal_slot4;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot4 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot4 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot5
		{
			get => this._decal_slot5;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot5 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot5 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot6
		{
			get => this._decal_slot6;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot6 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot6 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		public string DecalSlot7
		{
			get => this._decal_slot7;
			set
			{
				if (value == Reflection.BaseArguments.NULL)
					this._decal_slot7 = value;
				else if (value?.StartsWith("0x") ?? false)
					this._decal_slot7 = value;
				else
					throw new System.Exception("Value passed should be an 8-digit hexadecimal hash or NULL.");
			}
		}

		#endregion

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public DecalArray PlainCopy()
		{
			var result = new DecalArray();
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
			this._decal_slot0 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x04);
			this._decal_slot1 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x08);
			this._decal_slot2 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x0C);
			this._decal_slot3 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x10);
			this._decal_slot4 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x14);
			this._decal_slot5 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x18);
			this._decal_slot6 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
			key = *(uint*)(byteptr_t + 0x1C);
			this._decal_slot7 = (key == 0) ? Reflection.BaseArguments.NULL : $"0x{key:X8}";
		}

		public unsafe void Write(byte* byteptr_t)
		{
			*(uint*)byteptr_t = Utils.Bin.SmartHash(this._decal_slot0);
			*(uint*)(byteptr_t + 0x04) = Utils.Bin.SmartHash(this._decal_slot1);
			*(uint*)(byteptr_t + 0x08) = Utils.Bin.SmartHash(this._decal_slot2);
			*(uint*)(byteptr_t + 0x0C) = Utils.Bin.SmartHash(this._decal_slot3);
			*(uint*)(byteptr_t + 0x10) = Utils.Bin.SmartHash(this._decal_slot4);
			*(uint*)(byteptr_t + 0x14) = Utils.Bin.SmartHash(this._decal_slot5);
			*(uint*)(byteptr_t + 0x18) = Utils.Bin.SmartHash(this._decal_slot6);
			*(uint*)(byteptr_t + 0x1C) = Utils.Bin.SmartHash(this._decal_slot7);
		}
	}
}
