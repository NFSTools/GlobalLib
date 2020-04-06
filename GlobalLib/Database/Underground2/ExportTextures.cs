using System;
using System.IO;
using System.Windows.Forms;
using DevIL;
using GlobalLib.Core;



namespace GlobalLib.Database
{
    public partial class Underground2
    {
        /// <summary>
        /// Exports all textures to the directory specified as .dds files.
        /// </summary>
        /// <param name="dir">Directory where all textures should be extracted.</param>
        /// <returns>True if export was successful.</returns>
        public override bool ExportTextures(string dir)
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
        public override bool ExportTextures(string dir, string mode)
        {
            ImageType type;
            switch (mode)
            {
                case ".dds":
                    type = ImageType.Dds;
                    break;
                case ".png":
                    type = ImageType.Png;
                    break;
                case ".jpg":
                    type = ImageType.Jpg;
                    break;
                case ".tiff":
                    type = ImageType.Tiff;
                    break;
                case ".bmp":
                    type = ImageType.Bmp;
                    break;
                default:
                    if (Process.MessageShow)
                        MessageBox.Show("Export mode provided is not supported.", "Warning");
                    else
                        Console.WriteLine("Export mode provided is not supported.");
                    return false;
            }

            if (!Directory.Exists(dir))
            {
                if (Process.MessageShow)
                    MessageBox.Show("Directory provided does not exist.", "Warning");
                else
                    Console.WriteLine("Directory provided does not exist.");
                return false;
            }

            try
            {
                foreach (var tpk in this.TPKBlocks.Collections)
                {
                    string tpkdir = tpk.CollectionName.Substring(2, tpk.CollectionName.Length - 2);
                    tpkdir = Path.Combine(dir, tpkdir);
                    if (!Directory.Exists(tpkdir))
                        Directory.CreateDirectory(tpkdir);
                    foreach (var tex in tpk.Textures)
                    {
                        string texdir = Path.Combine(tpkdir, tex.CollectionName);
                        texdir += mode;
                        var data = tex.GetDDSArray();
                        if (mode == ".dds")
                        {
                            using (var bw = new BinaryWriter(File.Open(texdir, FileMode.Create)))
                            {
                                bw.Write(data);
                            }
                        }
                        else
                        {
                            using (var sr = new MemoryStream(data))
                            using (var im = new ImageImporter())
                            using (var ex = new ImageExporter())
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
            catch (Exception e)
            {
                if (Process.MessageShow)
                    MessageBox.Show(e.Message, "Warning");
                else
                    Console.WriteLine($"{e.Message}");
                return false;
            }
        }
    }
}