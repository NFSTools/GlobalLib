namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private string _perf_brand_1 = Reflection.BaseArguments.NULL;
		private string _perf_brand_2 = Reflection.BaseArguments.NULL;
		private string _perf_brand_3 = Reflection.BaseArguments.NULL;
		private string _perf_brand_4 = Reflection.BaseArguments.NULL;
		private string _perf_brand_5 = Reflection.BaseArguments.NULL;
		private string _perf_brand_6 = Reflection.BaseArguments.NULL;
		private string _perf_brand_7 = Reflection.BaseArguments.NULL;
		private string _perf_brand_8 = Reflection.BaseArguments.NULL;

		[Reflection.Attributes.AccessModifiable()]
		public int NumberOfBrands { get; set; }

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand1
		{
			get => this._perf_brand_1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_1 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_1 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand2
		{
			get => this._perf_brand_2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_2 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_2 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand3
		{
			get => this._perf_brand_3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_3 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_3 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand4
		{
			get => this._perf_brand_4;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_4 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_4 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand5
		{
			get => this._perf_brand_5;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_5 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_5 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand6
		{
			get => this._perf_brand_6;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_6 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_6 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand7
		{
			get => this._perf_brand_7;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_7 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_7 = value;
			}
		}

		[Reflection.Attributes.AccessModifiable()]
		public string PerfPartBrand8
		{
			get => this._perf_brand_8;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new System.ArgumentNullException("This value cannot be left empty.");
				else if (value == Reflection.BaseArguments.NULL)
					this._perf_brand_8 = value;
				else if (this.Database.GCareerBrands.GetClassIndex(value) == -1)
					throw new Reflection.Exception.MappingFailException();
				else
					this._perf_brand_8 = value;
			}
		}
	}
}