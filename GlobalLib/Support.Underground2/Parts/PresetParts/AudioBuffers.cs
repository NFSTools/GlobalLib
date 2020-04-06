using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Exception;
using GlobalLib.Reflection.Interface;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class AudioBuffers : SubPart, ICopyable<AudioBuffers>
	{
		#region Private Fields

		private string _audio_comp_00 = BaseArguments.NULL;
		private string _audio_comp_01 = BaseArguments.NULL;
		private string _audio_comp_02 = BaseArguments.NULL;
		private string _audio_comp_03 = BaseArguments.NULL;
		private string _audio_comp_04 = BaseArguments.NULL;
		private string _audio_comp_05 = BaseArguments.NULL;
		private string _audio_comp_06 = BaseArguments.NULL;
		private string _audio_comp_07 = BaseArguments.NULL;
		private string _audio_comp_08 = BaseArguments.NULL;
		private string _audio_comp_09 = BaseArguments.NULL;
		private string _audio_comp_10 = BaseArguments.NULL;
		private string _audio_comp_11 = BaseArguments.NULL;

		#endregion

		#region Public Properties

		public string AudioCompSmall00
		{
			get => this._audio_comp_00;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_00 = value;
			}
		}

		public string AudioCompSmall01
		{
			get => this._audio_comp_01;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_01 = value;
			}
		}

		public string AudioCompMedium02
		{
			get => this._audio_comp_02;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_02 = value;
			}
		}

		public string AudioCompMedium03
		{
			get => this._audio_comp_03;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_03 = value;
			}
		}

		public string AudioCompLarge04
		{
			get => this._audio_comp_04;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_04 = value;
			}
		}

		public string AudioCompLarge05
		{
			get => this._audio_comp_05;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_05 = value;
			}
		}

		public string AudioCompSmall06
		{
			get => this._audio_comp_06;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_06 = value;
			}
		}

		public string AudioCompSmall07
		{
			get => this._audio_comp_07;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_07 = value;
			}
		}

		public string AudioCompSmall08
		{
			get => this._audio_comp_08;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_08 = value;
			}
		}

		public string AudioCompSmall09
		{
			get => this._audio_comp_09;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_09 = value;
			}
		}

		public string AudioCompMedium10
		{
			get => this._audio_comp_10;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_10 = value;
			}
		}

		public string AudioCompMedium11
		{
			get => this._audio_comp_11;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				if (value != BaseArguments.NULL && !Map.AudioTypes.Contains(value))
					throw new MappingFailException();
				this._audio_comp_11 = value;
			}
		}

		#endregion

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public AudioBuffers PlainCopy()
		{
			var result = new AudioBuffers();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisField in ThisType.GetProperties())
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
			this._audio_comp_00 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x04);
			this._audio_comp_01 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x08);
			this._audio_comp_02 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x0C);
			this._audio_comp_03 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x10);
			this._audio_comp_04 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x14);
			this._audio_comp_05 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x18);
			this._audio_comp_06 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x1C);
			this._audio_comp_07 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x20);
			this._audio_comp_08 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x24);
			this._audio_comp_09 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x28);
			this._audio_comp_10 = Map.Lookup(key, true) ?? BaseArguments.NULL;
			key = *(uint*)(byteptr_t + 0x2C);
			this._audio_comp_11 = Map.Lookup(key, true) ?? BaseArguments.NULL;
		}

		public unsafe void Write(byte* byteptr_t)
		{
			*(uint*)byteptr_t = Bin.SmartHash(this._audio_comp_00);
			*(uint*)(byteptr_t + 0x04) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x08) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x0C) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x10) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x14) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x18) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x1C) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x20) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x24) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x28) = Bin.SmartHash(this._audio_comp_01);
			*(uint*)(byteptr_t + 0x2C) = Bin.SmartHash(this._audio_comp_01);
		}
	}
}
