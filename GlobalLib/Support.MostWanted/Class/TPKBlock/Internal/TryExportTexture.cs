namespace GlobalLib.Support.MostWanted.Class
{
    public partial class TPKBlock
    {
        /// <summary>
        /// Attemps to export <see cref="Texture"/> specified to the path and mode provided.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be exported.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="path">Path where the texture should be exported.</param>
        /// <param name="mode">Mode in which export the texture. Range: ".dds", ".png", ".jpg", ".tiff", ".bmp".</param>
        /// <returns>True if texture export was successful, false otherwise.</returns>
        public override bool TryExportTexture(uint key, Reflection.Enum.eKeyType type,
            string path, string mode)
        {
            DevIL.ImageType ddstype;
            switch (mode)
            {
                case ".dds":
                    ddstype = DevIL.ImageType.Dds;
                    break;
                case ".png":
                    ddstype = DevIL.ImageType.Png;
                    break;
                case ".jpg":
                    ddstype = DevIL.ImageType.Jpg;
                    break;
                case ".tiff":
                    ddstype = DevIL.ImageType.Tiff;
                    break;
                case ".bmp":
                    ddstype = DevIL.ImageType.Bmp;
                    break;
                default:
                    return false;
            }

            var tex = (Texture)this.FindTexture(key, type);
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
                            ex.SaveImage(image, ddstype, path);
                        }
                    }
                }
                return true;
            }
            catch (System.Exception) { return false; }
        }

        /// <summary>
        /// Attemps to export <see cref="Texture"/> specified to the path and mode provided.
        /// </summary>
        /// <param name="key">Key of the Collection Name of the <see cref="Texture"/> to be exported.</param>
        /// <param name="type">Type of the key passed.</param>
        /// <param name="path">Path where the texture should be exported.</param>
        /// <param name="mode">Mode in which export the texture. Range: ".dds", ".png", ".jpg", ".tiff", ".bmp".</param>
        /// <param name="error">Error occured when trying to clone a texture.</param>
        /// <returns>True if texture export was successful, false otherwise.</returns>
        public override bool TryExportTexture(uint key, Reflection.Enum.eKeyType type,
            string path, string mode, out string error)
        {
            error = null;
            DevIL.ImageType ddstype;
            switch (mode)
            {
                case ".dds":
                    ddstype = DevIL.ImageType.Dds;
                    break;
                case ".png":
                    ddstype = DevIL.ImageType.Png;
                    break;
                case ".jpg":
                    ddstype = DevIL.ImageType.Jpg;
                    break;
                case ".tiff":
                    ddstype = DevIL.ImageType.Tiff;
                    break;
                case ".bmp":
                    ddstype = DevIL.ImageType.Bmp;
                    break;
                default:
                    error = $"{mode} is not a supported image type that can be exported.";
                    return false;
            }

            var tex = (Texture)this.FindTexture(key, type);
            if (tex == null)
            {
                error = $"Texture with key 0x{key:X8} does not exist.";
                return false;
            }

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
                            ex.SaveImage(image, ddstype, path);
                        }
                    }
                }
                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }
    }
}