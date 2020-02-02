namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
    {
        /// <summary>
        /// Gets .png format image of the .dds texture.
        /// </summary>
        /// <returns>.png format image of the .dds texture.</returns>
        public override unsafe System.Drawing.Image GetImage()
        {
            var data = this.GetDDSArray();

            using (var DataStream = new System.IO.MemoryStream(data))
            using (var ResultStream = new System.IO.MemoryStream())
            using (var importer = new DevIL.ImageImporter())
            using (var exporter = new DevIL.ImageExporter())
            {
                using (var InterImage = importer.LoadImageFromStream(DataStream))
                {
                    exporter.SaveImageToStream(InterImage, DevIL.ImageType.Png, ResultStream);
                    var result = System.Drawing.Image.FromStream(ResultStream);
                    return result;
                }
            }
        }
    }
}