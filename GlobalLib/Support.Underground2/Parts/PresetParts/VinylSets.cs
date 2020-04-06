using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Exception;
using GlobalLib.Reflection.Interface;
using System;

namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class VinylSets : SubPart, ICopyable<VinylSets>
	{
		#region Private Fields

		private string _vinyl_layer0 = BaseArguments.NULL;
		private string _vinyl_layer1 = BaseArguments.NULL;
		private string _vinyl_layer2 = BaseArguments.NULL;
		private string _vinyl_layer3 = BaseArguments.NULL;
		private string _vinyl0_color0 = BaseArguments.NULL;
		private string _vinyl0_color1 = BaseArguments.NULL;
		private string _vinyl0_color2 = BaseArguments.NULL;
		private string _vinyl0_color3 = BaseArguments.NULL;
		private string _vinyl1_color0 = BaseArguments.NULL;
		private string _vinyl1_color1 = BaseArguments.NULL;
		private string _vinyl1_color2 = BaseArguments.NULL;
		private string _vinyl1_color3 = BaseArguments.NULL;
		private string _vinyl2_color0 = BaseArguments.NULL;
		private string _vinyl2_color1 = BaseArguments.NULL;
		private string _vinyl2_color2 = BaseArguments.NULL;
		private string _vinyl2_color3 = BaseArguments.NULL;
		private string _vinyl3_color0 = BaseArguments.NULL;
		private string _vinyl3_color1 = BaseArguments.NULL;
		private string _vinyl3_color2 = BaseArguments.NULL;
		private string _vinyl3_color3 = BaseArguments.NULL;

		#endregion

		#region Public Properties

		public string VinylLayer0
		{
			get => this._vinyl_layer0;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._vinyl_layer0 = value;
			}
		}

		public string VinylLayer1
		{
			get => this._vinyl_layer1;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._vinyl_layer1 = value;
			}
		}

		public string VinylLayer2
		{
			get => this._vinyl_layer2;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._vinyl_layer2 = value;
			}
		}

		public string VinylLayer3
		{
			get => this._vinyl_layer3;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("This value cannot be left empty.");
				this._vinyl_layer3 = value;
			}
		}

		public string Vinyl0_Color0
		{
			get => this._vinyl0_color0;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl0_color0 = value;
			}
		}

		public string Vinyl0_Color1
		{
			get => this._vinyl0_color1;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl0_color1 = value;
			}
		}

		public string Vinyl0_Color2
		{
			get => this._vinyl0_color2;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl0_color2 = value;
			}
		}

		public string Vinyl0_Color3
		{
			get => this._vinyl0_color3;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl0_color3 = value;
			}
		}

		public string Vinyl1_Color0
		{
			get => this._vinyl1_color0;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl1_color0 = value;
			}
		}

		public string Vinyl1_Color1
		{
			get => this._vinyl1_color1;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl1_color1 = value;
			}
		}

		public string Vinyl1_Color2
		{
			get => this._vinyl1_color2;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl1_color2 = value;
			}
		}

		public string Vinyl1_Color3
		{
			get => this._vinyl1_color3;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl1_color3 = value;
			}
		}

		public string Vinyl2_Color0
		{
			get => this._vinyl2_color0;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl2_color0 = value;
			}
		}

		public string Vinyl2_Color1
		{
			get => this._vinyl2_color1;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl2_color1 = value;
			}
		}

		public string Vinyl2_Color2
		{
			get => this._vinyl2_color2;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl2_color2 = value;
			}
		}

		public string Vinyl2_Color3
		{
			get => this._vinyl2_color3;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl2_color3 = value;
			}
		}

		public string Vinyl3_Color0
		{
			get => this._vinyl3_color0;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl3_color0 = value;
			}
		}

		public string Vinyl3_Color1
		{
			get => this._vinyl3_color1;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl3_color1 = value;
			}
		}

		public string Vinyl3_Color2
		{
			get => this._vinyl3_color2;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl3_color2 = value;
			}
		}

		public string Vinyl3_Color3
		{
			get => this._vinyl3_color3;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2VinylPaints.Contains(value))
					throw new MappingFailException();
				this._vinyl3_color3 = value;
			}
		}

		#endregion

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public VinylSets PlainCopy()
		{
			var result = new VinylSets();
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
