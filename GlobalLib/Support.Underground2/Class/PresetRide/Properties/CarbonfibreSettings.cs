using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private eBoolean _carbon_body = eBoolean.False;
		private eBoolean _carbon_hood = eBoolean.False;
		private eBoolean _carbon_doors = eBoolean.False;
		private eBoolean _carbon_trunk = eBoolean.False;

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean HasCarbonfibreBody
		{
			get => this._carbon_body;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
				{
					this._carbon_body = value;
					this.Modified = true;
				}
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean HasCarbonfibreHood
		{
			get => this._carbon_hood;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
				{
					this._carbon_hood = value;
					this.Modified = true;
				}
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean HasCarbonfibreDoors
		{
			get => this._carbon_doors;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
				{
					this._carbon_doors = value;
					this.Modified = true;
				}
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eBoolean HasCarbonfibreTrunk
		{
			get => this._carbon_trunk;
			set
			{
				if (Enum.IsDefined(typeof(eBoolean), value))
				{
					this._carbon_trunk = value;
					this.Modified = true;
				}
				else
					throw new ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}
	}
}