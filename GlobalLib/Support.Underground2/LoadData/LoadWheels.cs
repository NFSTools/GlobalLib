using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Underground2
{
    public static partial class LoadData
    {
        /// <summary>
        /// Loads Wheels files and reads its rim brand strings
        /// </summary>
        /// <param name="Wheels_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadWheels(string Wheels_dir)
        {
            Wheels_dir += @"\CARS\WHEELS";
            if (!Directory.Exists(Wheels_dir))
			{
				if (Core.Process.MessageShow)
					MessageBox.Show(@"Directory CARS\WHEELS does not exist.", "Failure");
				else
					Console.WriteLine(@"Directory CARS\WHEELS does not exist.");
				return false;
			}

			var files = Directory.GetFiles(Wheels_dir);
			if (files == null || files.Length == 0)
			{
				if (Core.Process.MessageShow)
					MessageBox.Show(@"Directory CARS\WHEELS is empty.", "Failure");
				else
					Console.WriteLine(@"Directory CARS\WHEELS is empty.");
				return false;
			}

			foreach (var file in files)
			{
				string ext = Path.GetExtension(file).ToUpper();
				if (!Path.GetFileName(file).StartsWith("GEOMETRY_") || (Path.GetExtension(file).ToUpper() != ".BIN"))
					continue;
				try
				{
					using (var br = new BinaryReader(File.Open(file, FileMode.Open, FileAccess.Read)))
					{
						if (br.ReadUInt32() != 0x80134000) continue; // if not a wheels file
						br.BaseStream.Position += 4; // skip size
						while (br.BaseStream.Position < br.BaseStream.Length)
						{
							uint ID = br.ReadUInt32();
							int size = br.ReadInt32();
							int off = (int)br.BaseStream.Position;
							if (ID != 0x80134010)
							{
								br.ReadBytes(size);
								continue;
							}
							while ((int)br.BaseStream.Position < off + size)
							{
								ID = br.ReadUInt32();
								size = br.ReadInt32();
								if (ID == 0x00134011) break;
							}
							if (ID != 0x00134011) continue;
							br.BaseStream.Position += 0xA4;
							string rim = Utils.ScriptX.NullTerminatedString(br);
							br.BaseStream.Position -= 0xB0 + rim.Length + 1;
							rim = Utils.FormatX.GetString(rim, "{X}_X");
							if (!Core.Map.RimBrands.Contains(rim))
								Core.Map.RimBrands.Add(rim);
							br.ReadBytes(br.ReadInt32());
						}
					}
				}
				catch (Exception e)
				{
					while (e.InnerException != null) e = e.InnerException;
					if (Core.Process.MessageShow)
						MessageBox.Show(e.Message, "Failure");
					else
						Console.WriteLine(e.Message);
					return false;
				}
			}
			foreach (var rim in Core.Map.RimBrands)
				Utils.Bin.Hash(rim);
			return true;
        }
    }
}