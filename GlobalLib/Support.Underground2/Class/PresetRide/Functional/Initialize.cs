namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private void Initialize()
		{
			this.AUDIO_COMP = new Parts.PresetParts.AudioBuffers();
			this.DECALS_FRONT_WINDOW = new Parts.PresetParts.DecalArray();
			this.DECALS_HOOD = new Parts.PresetParts.DecalArray();
			this.DECALS_LEFT_DOOR = new Parts.PresetParts.DecalArray();
			this.DECALS_LEFT_QUARTER = new Parts.PresetParts.DecalArray();
			this.DECALS_REAR_WINDOW = new Parts.PresetParts.DecalArray();
			this.DECALS_RIGHT_DOOR = new Parts.PresetParts.DecalArray();
			this.DECALS_RIGHT_QUARTER = new Parts.PresetParts.DecalArray();
			this.PAINT_TYPES = new Parts.PresetParts.PaintTypes();
			this.SPECIALTIES = new Parts.PresetParts.Specialties();
			this.VINYL_SETS = new Parts.PresetParts.VinylSets();
		}
	}
}