namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class Specialties : Reflection.Abstract.SubPart, Reflection.Interface.ICopyable<Specialties>
	{
		#region Private Fields

		private string _neon_body = Reflection.BaseArguments.NULL;
		private string _neon_engine = Reflection.BaseArguments.NULL;
		private string _neon_cabin = Reflection.BaseArguments.NULL;
		private string _neon_trunk = Reflection.BaseArguments.NULL;
		private byte _neon_cabin_style = 0;
		private string _headlight_bulb = Reflection.BaseArguments.STOCK;
		private string _door_style = Reflection.BaseArguments.STOCK;
		private string _hydraulics_style = Reflection.BaseArguments.NULL;
		private string _nos_purge_style = Reflection.BaseArguments.NULL;

		#endregion

		#region Public Properties

		public string NeonBody
		{
			get => this._neon_body;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.NULL && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._neon_body = value;
			}
		}

		public string NeonEngine
		{
			get => this._neon_engine;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.NULL && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._neon_engine = value;
			}
		}

		public string NeonCabin
		{
			get => this._neon_cabin;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.NULL && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._neon_cabin = value;
			}
		}

		public string NeonTrunk
		{
			get => this._neon_trunk;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.NULL && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._neon_trunk = value;
			}
		}

		public byte NeonCabinStyle
		{
			get => this._neon_cabin_style;
			set
			{
				if (value > 3)
					throw new System.ArgumentOutOfRangeException("This value should be in range 0-3.");
				else
					this._neon_cabin_style = value;
			}
		}

		public string HeadlightBulbStyle
		{
			get => this._headlight_bulb;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.STOCK && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._headlight_bulb = value;
			}
		}

		public string DoorOpeningStyle
		{
			get => this._door_style;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.STOCK && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._door_style = value;
			}
		}

		public string HydraulicsStyle
		{
			get => this._hydraulics_style;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.NULL && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._hydraulics_style = value;
			}
		}

		public string NOSPurgeStyle
		{
			get => this._nos_purge_style;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value != Reflection.BaseArguments.NULL && !Core.Map.BinKeys.ContainsValue(value))
					throw new Reflection.Exception.MappingFailException();
				else
					this._nos_purge_style = value;
			}
		}

		#endregion

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public Specialties PlainCopy()
		{
			var result = new Specialties();
			var ThisType = this.GetType();
			var ResultType = result.GetType();
			foreach (var ThisField in ThisType.GetProperties())
			{
				var ResultField = ResultType.GetProperty(ThisField.Name);
				ResultField.SetValue(result, ThisField.GetValue(this));
			}
			return result;
		}
	}
}
