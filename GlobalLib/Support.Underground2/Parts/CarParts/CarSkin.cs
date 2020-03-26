namespace GlobalLib.Support.Underground2.Parts.CarParts
{
	public class CarSkin : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<CarSkin>
	{
		private string _skin_description = "Silver";
		private string _materialused = Reflection.BaseArguments.NULL;
		private Reflection.Enum.eCarSkinClass _skin_class_key = Reflection.Enum.eCarSkinClass.Racing; 

		public string SkinDescription
		{
			get => this._skin_description;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._skin_description = value;
			}
		}

		public string MaterialUsed
		{
			get => this._materialused;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				this._materialused = value;
			}
		}

		public Reflection.Enum.eCarSkinClass SkinClassKey
		{
			get => this._skin_class_key;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eCarSkinClass), value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._skin_class_key = value;
			}
		}

		/// <summary>
		/// Creates a plane copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public CarSkin PlainCopy()
		{
			var result = new CarSkin();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisProperty in ThisType.GetProperties())
			{
				var ResultField = ResultType.GetProperty(ThisProperty.Name);
				ResultField.SetValue(result, ThisProperty.GetValue(this));
			}
			return result;
		}

		public unsafe void Read(byte* byteptr_t, out int id, out int index)
		{
			uint key = 0;
			id = *(int*)byteptr_t;
			index = *(int*)(byteptr_t + 4);
			this._skin_description = Utils.ScriptX.NullTerminatedString(byteptr_t + 8, 0x20);
			key = *(uint*)(byteptr_t + 0x2C);
			this._materialused = Core.Map.Lookup(key, true) ?? $"0x{key:X8}";
			this._skin_class_key = (Reflection.Enum.eCarSkinClass)(*(uint*)(byteptr_t + 0x30));
		}

		public unsafe void Write(byte* byteptr_t, int id, int index)
		{
			*(int*)byteptr_t = id;
			*(int*)(byteptr_t + 4) = index;
			for (int a1 = 0; a1 < this._skin_description.Length; ++a1)
				*(byteptr_t + 8 + a1) = (byte)this._skin_description[a1];
			*(uint*)(byteptr_t + 0x2C) = Utils.Bin.SmartHash(this._materialused);
			*(uint*)(byteptr_t + 0x30) = (uint)this._skin_class_key;
		}
	}
}
