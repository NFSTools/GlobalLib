namespace GlobalLib.Database
{
    public partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Exports all textures to the directory specified as .dds files.
        /// </summary>
        /// <param name="dir">Directory where all textures should be extracted.</param>
        /// <returns>True if export was successful.</returns>
        public bool ExportTextures(string dir)
        {
            if (this.ExportTextures(dir, ".dds"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Exports all textures to the directory specified.
        /// </summary>
        /// <param name="dir">Directory where all textures should be extracted.</param>
        /// <param name="mode">Mode of extraction. Range: ".dds", ".png", ".jpg", ".tiff", ".bmp".</param>
        /// <returns>True if export was successful.</returns>
        public bool ExportTextures(string dir, string mode)
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

            if (!System.IO.Directory.Exists(dir))
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show("Directory provided does not exist.", "Warning");
                else
                    System.Console.WriteLine("Directory provided does not exist.");
                return false;
            }

            try
            {
                foreach (var tpk in this.TPKBlocks)
                {
                    string tpkdir = tpk.CollectionName.Substring(2, tpk.CollectionName.Length - 2);
                    tpkdir = System.IO.Path.Combine(dir, tpkdir);
                    if (!System.IO.Directory.Exists(tpkdir))
                        System.IO.Directory.CreateDirectory(tpkdir);
                    foreach (var tex in tpk.Textures)
                    {
                        string texdir = System.IO.Path.Combine(tpkdir, tex.CollectionName);
                        texdir += mode;
                        var data = tex.GetDDSArray();
                        if (mode == ".dds")
                        {
                            using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(texdir, System.IO.FileMode.Create)))
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
                                    ex.SaveImage(image, type, texdir);
                                }
                            }
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