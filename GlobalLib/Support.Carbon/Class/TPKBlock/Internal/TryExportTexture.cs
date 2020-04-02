namespace GlobalLib.Support.Carbon.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attemps to export texture specified to the path and mode provided.
        /// </summary>
        /// <param name="CName">Collection Name of the texture to be exported.</param>
        /// <param name="path">Path where the texture should be exported.</param>
        /// <param name="mode">Mode in which export the texture. Range: ".dds", ".png", ".jpg", ".tiff", ".bmp".</param>
        /// <returns>True if texture export was successful, false otherwise.</returns>
        public override bool TryExportTexture(string CName, string path, string mode)
        {
            DevIL.ImageType type;
            switch (mode)
            {
                case ".dds":
                    type = DevIL.ImageType.Dds;
                    break;
                case ".png":
                    type = DevIL.ImageType.Png;
                    break;
                case ".jpg":
                    type = DevIL.ImageType.Jpg;
                    break;
                case ".tiff":
                    type = DevIL.ImageType.Tiff;
                    break;
                case ".bmp":
                    type = DevIL.ImageType.Bmp;
                    break;
                default:
                    if (Core.Process.MessageShow)
                        System.Windows.Forms.MessageBox.Show("Export mode provided is not supported.", "Warning");
                    else
                        System.Console.WriteLine("Export mode provided is not supported.");
                    return false;
            }

            var tex = this.FindTexture(CName);
            if (tex == null) return false;

            try
            {
                var data = tex.GetDDSArray();
                if (mode == ".dds")
                {
                    using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(path, System.IO.FileMode.Create)))
                    {
                        bw.Write(data);
                    }
                }
                else
                {
                    using (var sr = new System.IO.MemoryStream(data))
                    using (var im = new DevIL.ImageImporter())
                    using (var ex = new DevIL.ImageExporter())
                    {
                        using (var image = im.LoadImageFromStream(sr))
                        {
                            ex.SaveImage(image, type, path);
                        }
                    }
                }
                return true;
            }
            catch (System.Exception e)
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message, "Warning");
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }
    }
}