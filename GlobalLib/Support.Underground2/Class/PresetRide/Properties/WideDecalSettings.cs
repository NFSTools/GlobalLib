namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private Reflection.Enum.eDecalType _decaltype_hood = Reflection.Enum.eDecalType.MEDIUM;
		private Reflection.Enum.eDecalType _decaltype_leftquarter = Reflection.Enum.eDecalType.MEDIUM;
		private Reflection.Enum.eDecalType _decaltype_rightquarter = Reflection.Enum.eDecalType.MEDIUM;
		private Reflection.Enum.eWideDecalType _decalwide_leftdoor = Reflection.Enum.eWideDecalType.NONE;
		private Reflection.Enum.eWideDecalType _decalwide_rightdoor = Reflection.Enum.eWideDecalType.NONE;
		private Reflection.Enum.eWideDecalType _decalwide_leftquarter = Reflection.Enum.eWideDecalType.NONE;
		private Reflection.Enum.eWideDecalType _decalwide_rightquarter = Reflection.Enum.eWideDecalType.NONE;

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eDecalType DecalTypeHood
		{
			get => this._decaltype_hood;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decaltype_hood = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eDecalType DecalTypeLeftQuarter
		{
			get => this._decaltype_leftquarter;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decaltype_leftquarter = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eDecalType DecalTypeRightQuarter
		{
			get => this._decaltype_rightquarter;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decaltype_rightquarter = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eWideDecalType DecalWideLeftDoor
		{
			get => this._decalwide_leftdoor;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eWideDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decalwide_leftdoor = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eWideDecalType DecalWideRightDoor
		{
			get => this._decalwide_rightdoor;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eWideDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decalwide_rightdoor = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eWideDecalType DecalWideLeftQuarter
		{
			get => this._decalwide_leftquarter;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eWideDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decalwide_leftquarter = value;
				this.Modified = true;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public Reflection.Enum.eWideDecalType DecalWideRightQuarter
		{
			get => this._decalwide_rightquarter;
			set
			{
				if (!System.Enum.IsDefined(typeof(Reflection.Enum.eWideDecalType), value))
					throw new Reflection.Exception.MappingFailException();
				this._decalwide_rightquarter = value;
				this.Modified = true;
			}
		}
	}
}