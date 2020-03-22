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
        /// <param name="Audios_dir">Directory of the game.</param>
        /// <param name="db">Database of classes.</param>
        /// <returns>True if success.</returns>
        public static unsafe bool LoadAudios(string Audios_dir)
        {
            Audios_dir += @"\CARS\AUDIO\GEOMETRY.BIN";
            if (!File.Exists(Audios_dir))
			{
				if (Core.Process.MessageShow)
					MessageBox.Show(@"File CARS\AUDIO\GEOMETRY.BIN does not exist.", "Failure");
				else
					Console.WriteLine(@"File CARS\AUDIO\GEOMETRY.BIN does not exist.");
				return false;
			}

			try
			{
				using (var br = new BinaryReader(File.Open(Audios_dir, FileMode.Open, FileAccess.Read)))
				{
					if (br.ReadUInt32() != 0x80134000)
						throw new FileLoadException(@"File CARS\AUDIO\GEOMETRY.BIN is an invalid geometry file");
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
						string audio = Utils.ScriptX.NullTerminatedString(br);
						br.BaseStream.Position -= 0xB0 + audio.Length + 1;
						audio = audio.Substring(0, audio.LastIndexOf('_')); // throw away _A and _PAIN
						Utils.Bin.Hash(audio); // put in the map
						if (!Core.Map.AudioTypes.Contains(audio))
							Core.Map.AudioTypes.Add(audio);
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

			for (int a1 = 0; a1 < Core.Map.AudioTypes.Count; ++a1)
			{
				string audio = Core.Map.AudioTypes[a1];
				if (audio.StartsWith("AUDIO_COMP_SPEAKER"))
					Core.Map.AudioTypes[a1] = $"{audio.Substring(0, 18)}_{audio.Substring(18, audio.Length - 18)}";
			}
			return true;
        }
    }
}