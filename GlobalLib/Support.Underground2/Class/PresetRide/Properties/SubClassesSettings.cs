namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		[Reflection.Attributes.Expandable("Visuals")]
		public Parts.PresetParts.PaintTypes PAINT_TYPES { get; set; }

		[Reflection.Attributes.Expandable("Visuals")]
		public Parts.PresetParts.VinylSets VINYL_SETS { get; set; }

		[Reflection.Attributes.Expandable("Visuals")]
		public Parts.PresetParts.Specialties SPECIALTIES { get; set; }

		[Reflection.Attributes.Expandable("Visuals")]
		public Parts.PresetParts.AudioBuffers AUDIO_COMP { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_HOOD { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_FRONT_WINDOW { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_REAR_WINDOW { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_LEFT_DOOR { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_RIGHT_DOOR { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_LEFT_QUARTER { get; set; }

		[Reflection.Attributes.Expandable("Decals")]
		public Parts.PresetParts.DecalArray DECALS_RIGHT_QUARTER { get; set; }
	}
}