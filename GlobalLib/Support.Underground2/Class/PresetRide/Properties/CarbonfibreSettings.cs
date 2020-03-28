namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private Reflection.Enum.eBoolean _carbon_body = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _carbon_hood = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _carbon_doors = Reflection.Enum.eBoolean.False;
		private Reflection.Enum.eBoolean _carbon_trunk = Reflection.Enum.eBoolean.False;

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eBoolean HasCarbonfibreBody
		{
			get => this._carbon_body;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
				{
					this._carbon_body = value;
					this.Modified = true;
				}
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eBoolean HasCarbonfibreHood
		{
			get => this._carbon_hood;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
				{
					this._carbon_hood = value;
					this.Modified = true;
				}
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eBoolean HasCarbonfibreDoors
		{
			get => this._carbon_doors;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
				{
					this._carbon_doors = value;
					this.Modified = true;
				}
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		[Reflection.Attributes.StaticModifiable()]
		public Reflection.Enum.eBoolean HasCarbonfibreTrunk
		{
			get => this._carbon_trunk;
			set
			{
				if (System.Enum.IsDefined(typeof(Reflection.Enum.eBoolean), value))
				{
					this._carbon_trunk = value;
					this.Modified = true;
				}
				else
					throw new System.ArgumentOutOfRangeException("Value passed is not of boolean type.");
			}
		}
	}
}