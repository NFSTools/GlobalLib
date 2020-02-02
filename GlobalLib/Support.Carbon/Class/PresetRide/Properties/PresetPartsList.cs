namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide : Shared.Class.PresetRide, Reflection.Interface.ICastable<PresetRide>
    {
        public Parts.PresetParts.Vinyl[] Vinyls { get; set; }
        public Parts.PresetParts.Autosculpt FRONTBUMPER { get; set; }
        public Parts.PresetParts.Autosculpt REARBUMPER { get; set; }
        public Parts.PresetParts.Autosculpt SKIRT { get; set; }
        public Parts.PresetParts.Autosculpt WHEELS { get; set; }
        public Parts.PresetParts.Autosculpt HOOD { get; set; }
        public Parts.PresetParts.Autosculpt SPOILER { get; set; }
        public Parts.PresetParts.Autosculpt ROOFSCOOP { get; set; }
    }
}