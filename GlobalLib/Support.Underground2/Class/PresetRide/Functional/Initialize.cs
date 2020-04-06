using GlobalLib.Support.Underground2.Parts.PresetParts;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class PresetRide
	{
		private void Initialize()
		{
			this.AUDIO_COMP = new AudioBuffers();
			this.DECALS_FRONT_WINDOW = new DecalArray();
			this.DECALS_HOOD = new DecalArray();
			this.DECALS_LEFT_DOOR = new DecalArray();
			this.DECALS_LEFT_QUARTER = new DecalArray();
			this.DECALS_REAR_WINDOW = new DecalArray();
			this.DECALS_RIGHT_DOOR = new DecalArray();
			this.DECALS_RIGHT_QUARTER = new DecalArray();
			this.PAINT_TYPES = new PaintTypes();
			this.SPECIALTIES = new Specialties();
			this.VINYL_SETS = new VinylSets();
		}
	}
}