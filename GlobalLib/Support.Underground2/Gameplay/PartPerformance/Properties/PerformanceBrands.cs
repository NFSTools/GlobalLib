using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;
using System;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartPerformance
	{
		private string _perf_brand_1 = BaseArguments.NULL;
		private string _perf_brand_2 = BaseArguments.NULL;
		private string _perf_brand_3 = BaseArguments.NULL;
		private string _perf_brand_4 = BaseArguments.NULL;
		private string _perf_brand_5 = BaseArguments.NULL;
		private string _perf_brand_6 = BaseArguments.NULL;
		private string _perf_brand_7 = BaseArguments.NULL;
		private string _perf_brand_8 = BaseArguments.NULL;

		[AccessModifiable()]
		[StaticModifiable()]
		public int NumberOfBrands { get; set; }

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand1
		{
			get => this._perf_brand_1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_1 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand2
		{
			get => this._perf_brand_2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_2 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand3
		{
			get => this._perf_brand_3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_3 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand4
		{
			get => this._perf_brand_4;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_4 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand5
		{
			get => this._perf_brand_5;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_5 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand6
		{
			get => this._perf_brand_6;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_6 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand7
		{
			get => this._perf_brand_7;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_7 = value;
			}
		}

		[AccessModifiable()]
		[StaticModifiable()]
		public string PerfPartBrand8
		{
			get => this._perf_brand_8;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._perf_brand_8 = value;
			}
		}
	}
}