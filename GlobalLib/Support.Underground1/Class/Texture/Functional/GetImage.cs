using System.Drawing;
using System.IO;

namespace GlobalLib.Support.Underground1.Class
{
    public partial class Texture
    {
        /// <summary>
        /// Gets .png format image of the .dds texture.
        /// </summary>
        /// <returns>.png format image of the .dds texture.</returns>
        public override unsafe Image GetImage()
        {
            var data = this.GetDDSArray();

            using (var DataStream = new MemoryStream(data))
            using (var ResultStream = new MemoryStream())
            using (var importer = new DevIL.ImageImporter())
            using (var exporter = new DevIL.ImageExporter())
            {
                using (var InterImage = importer.LoadImageFromStream(DataStream))
                {
                    exporter.SaveImageToStream(InterImage, DevIL.ImageType.Png, ResultStream);
                    var result = Image.FromStream(ResultStream);
                    return result;
                }
            }
        }
    }
}