﻿using GlobalLib.Reflection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;
using System;

namespace GlobalLib.Support.Underground2.Parts.GameParts
{
	public class Opponent : SubPart, ICopyable<Opponent>
	{
		private string _name = BaseArguments.NULL;
		private string _preset_ride = BaseArguments.RANDOM;

		public string Name
		{
			get => this._name;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._name = value;
			}
		}

		public ushort StatsMultiplier { get; set; }
		
		public string PresetRide
		{
			get => this._preset_ride;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._preset_ride = value;
			}
		}
		
		public byte SkillEasy { get; set; }
		public byte SkillMedium { get; set; }
		public byte SkillHard { get; set; }
		public byte CatchUp { get; set; }

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Opponent PlainCopy()
		{
			var result = new Opponent();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisProperty in ThisType.GetProperties())
			{
				var ResultField = ResultType.GetProperty(ThisProperty.Name);
				ResultField.SetValue(result, ThisProperty.GetValue(this));
			}
			return result;
		}
	}
}
