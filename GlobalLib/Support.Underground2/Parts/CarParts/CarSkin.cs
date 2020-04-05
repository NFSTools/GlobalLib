using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using GlobalLib.Reflection.Interface;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Parts.CarParts
{
	public class CarSkin : SubPart, ICopyable<CarSkin>
	{
		private string _skin_description = "Silver";
		private string _materialused = BaseArguments.NULL;
		private eCarSkinClass _skin_class_key = eCarSkinClass.Racing; 

		public string SkinDescription
		{
			get => this._skin_description;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._skin_description = value;
			}
		}

		public string MaterialUsed
		{
			get => this._materialused;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._materialused = value;
			}
		}

		public eCarSkinClass SkinClassKey
		{
			get => this._skin_class_key;
			set
			{
				if (!Enum.IsDefined(typeof(eCarSkinClass), value))
					throw new MappingFailException();
				else
					this._skin_class_key = value;
			}
		}

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
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
			this._skin_description = ScriptX.NullTerminatedString(byteptr_t + 8, 0x20);
			key = *(uint*)(byteptr_t + 0x2C);
			this._materialused = Map.Lookup(key, true) ?? $"0x{key:X8}";
			this._skin_class_key = (eCarSkinClass)(*(uint*)(byteptr_t + 0x30));
		}

		public unsafe void Write(byte* byteptr_t, int id, int index)
		{
			*(int*)byteptr_t = id;
			*(int*)(byteptr_t + 4) = index;
			for (int a1 = 0; a1 < this._skin_description.Length; ++a1)
				*(byteptr_t + 8 + a1) = (byte)this._skin_description[a1];
			*(uint*)(byteptr_t + 0x2C) = Bin.SmartHash(this._materialused);
			*(uint*)(byteptr_t + 0x30) = (uint)this._skin_class_key;
		}
	}
}
