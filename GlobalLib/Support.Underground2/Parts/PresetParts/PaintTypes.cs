using GlobalLib.Core;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Exception;
using GlobalLib.Reflection.Interface;

namespace GlobalLib.Support.Underground2.Parts.PresetParts
{
	public class PaintTypes : SubPart, ICopyable<PaintTypes>
	{
		#region Private Fields

		private string _base_paint_type = BaseArguments.NULL;
		private string _engine_paint_type = BaseArguments.NULL;
		private string _spoiler_paint_type = BaseArguments.NULL;
		private string _brakes_paint_type = BaseArguments.NULL;
		private string _exhaust_paint_type = BaseArguments.NULL;
		private string _audio_paint_type = BaseArguments.NULL;
		private string _rims_paint_type = BaseArguments.NULL;
		private string _spinners_paint_type = BaseArguments.NULL;
		private string _roof_paint_type = BaseArguments.NULL;
		private string _mirrors_paint_type = BaseArguments.NULL;

		#endregion

		#region Public Properties

		public string BasePaintType
		{
			get => this._base_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._base_paint_type = value;
			}
		}

		public string EnginePaintType
		{
			get => this._engine_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._engine_paint_type = value;
			}
		}

		public string SpoilerPaintType
		{
			get => this._spoiler_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._spoiler_paint_type = value;
			}
		}

		public string BrakesPaintType
		{
			get => this._brakes_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2CaliperPaints.Contains(value))
					throw new MappingFailException();
				this._brakes_paint_type = value;
			}
		}

		public string ExhaustPaintType
		{
			get => this._exhaust_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._exhaust_paint_type = value;
			}
		}

		public string AudioPaintType
		{
			get => this._audio_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._audio_paint_type = value;
			}
		}

		public string RimsPaintType
		{
			get => this._rims_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2RimPaints.Contains(value))
					throw new MappingFailException();
				this._rims_paint_type = value;
			}
		}

		public string SpinnersPaintType
		{
			get => this._spinners_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2RimPaints.Contains(value))
					throw new MappingFailException();
				this._spinners_paint_type = value;
			}
		}

		public string RoofPaintType
		{
			get => this._roof_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._roof_paint_type = value;
			}
		}

		public string MirrorsPaintType
		{
			get => this._mirrors_paint_type;
			set
			{
				if (value != BaseArguments.NULL && !Map.UG2PaintTypes.Contains(value))
					throw new MappingFailException();
				this._mirrors_paint_type = value;
			}
		}

		#endregion

		/// <summary>
		/// Creates a plain copy of the objects that contains same values.
		/// </summary>
		/// <returns>Exact plain copy of the object.</returns>
		public PaintTypes PlainCopy()
		{
			var result = new PaintTypes();
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
