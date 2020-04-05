using GlobalLib.Reflection.Attributes;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Exception;
using System;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private eDecalType _decaltype_hood = eDecalType.MEDIUM;
		private eDecalType _decaltype_leftquarter = eDecalType.MEDIUM;
		private eDecalType _decaltype_rightquarter = eDecalType.MEDIUM;
		private eWideDecalType _decalwide_leftdoor = eWideDecalType.NONE;
		private eWideDecalType _decalwide_rightdoor = eWideDecalType.NONE;
		private eWideDecalType _decalwide_leftquarter = eWideDecalType.NONE;
		private eWideDecalType _decalwide_rightquarter = eWideDecalType.NONE;

		[AccessModifiable()]
		[StaticModifiable()]
		public eDecalType DecalTypeHood
		{
			get => this._decaltype_hood;
			set
			{
				if (!Enum.IsDefined(typeof(eDecalType), value))
					throw new MappingFailException();
				this._decaltype_hood = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eDecalType DecalTypeLeftQuarter
		{
			get => this._decaltype_leftquarter;
			set
			{
				if (!Enum.IsDefined(typeof(eDecalType), value))
					throw new MappingFailException();
				this._decaltype_leftquarter = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eDecalType DecalTypeRightQuarter
		{
			get => this._decaltype_rightquarter;
			set
			{
				if (!Enum.IsDefined(typeof(eDecalType), value))
					throw new MappingFailException();
				this._decaltype_rightquarter = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eWideDecalType DecalWideLeftDoor
		{
			get => this._decalwide_leftdoor;
			set
			{
				if (!Enum.IsDefined(typeof(eWideDecalType), value))
					throw new MappingFailException();
				this._decalwide_leftdoor = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eWideDecalType DecalWideRightDoor
		{
			get => this._decalwide_rightdoor;
			set
			{
				if (!Enum.IsDefined(typeof(eWideDecalType), value))
					throw new MappingFailException();
				this._decalwide_rightdoor = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eWideDecalType DecalWideLeftQuarter
		{
			get => this._decalwide_leftquarter;
			set
			{
				if (!Enum.IsDefined(typeof(eWideDecalType), value))
					throw new MappingFailException();
				this._decalwide_leftquarter = value;
				this.Modified = true;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public eWideDecalType DecalWideRightQuarter
		{
			get => this._decalwide_rightquarter;
			set
			{
				if (!Enum.IsDefined(typeof(eWideDecalType), value))
					throw new MappingFailException();
				this._decalwide_rightquarter = value;
				this.Modified = true;
			}
		}
	}
}