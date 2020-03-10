namespace GlobalLib.Support.Carbon.Class
{
    public partial class PresetRide
    {
        [Reflection.Attributes.Expandable("VINYL")]
        public Parts.PresetParts.Vinyl[] Vinyls { get; set; }

        [Reflection.Attributes.Expandable("FRONTBUMPER")]
        public Parts.PresetParts.Autosculpt FRONTBUMPER { get; set; }

        [Reflection.Attributes.Expandable("REARBUMPER")]
        public Parts.PresetParts.Autosculpt REARBUMPER { get; set; }

        [Reflection.Attributes.Expandable("SKIRT")]
        public Parts.PresetParts.Autosculpt SKIRT { get; set; }

        [Reflection.Attributes.Expandable("WHEELS")]
        public Parts.PresetParts.Autosculpt WHEELS { get; set; }

        [Reflection.Attributes.Expandable("HOOD")]
        public Parts.PresetParts.Autosculpt HOOD { get; set; }

        [Reflection.Attributes.Expandable("SPOILER")]
        public Parts.PresetParts.Autosculpt SPOILER { get; set; }

        [Reflection.Attributes.Expandable("ROOFSCOOP")]
        public Parts.PresetParts.Autosculpt ROOFSCOOP { get; set; }
    }
}