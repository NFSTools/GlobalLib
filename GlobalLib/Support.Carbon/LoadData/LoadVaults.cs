using System;
using System.IO;
using System.Windows.Forms;



namespace GlobalLib.Support.Carbon
{
	public static partial class LoadData
	{
		/// <summary>
		/// Loads vault data files and processes all strings that are contained in them.
		/// </summary>
		/// <param name="Vault_Dir">Directory of the game.</param>
		/// <returns>True if success.</returns>
		public static unsafe bool LoadVaults(string Vault_Dir)
		{
			string AttribDir = Vault_Dir + @"\GLOBAL\attributes.bin";
			string FEAttrDir = Vault_Dir + @"\GLOBAL\fe_attrib.bin";

			byte[] Attributes;
			byte[] FE_Attrib;

			try
			{
				Attributes = File.ReadAllBytes(AttribDir);
				FE_Attrib = File.ReadAllBytes(FEAttrDir);
				Utils.Log.Write("Reading data from attributes.bin...");
				Utils.Log.Write("Reading data from fe_attrib.bin...");
			}
			catch (Exception) // If any of files is opened in editing mode in another program
			{
				if (Core.Process.MessageShow)
					MessageBox.Show("Unable to read vault file. Please close all\napplications that have it opened or\ncheck its internal data.", "Failure");
				else
					Console.WriteLine("Unable to read vault file.");
				return false;
			}

			fixed (byte* byteptr_t = &Attributes[0])
			{
				if (*(uint*)byteptr_t != 0x4B415056)
				{
					if (Core.Process.MessageShow)
						MessageBox.Show("attributes: invalid header definition.", "Failure");
					else
						Console.WriteLine("attributes: invalid header definition.");
					return false;
				}

				int packs = *(int*)(byteptr_t + 4);
				int cnameoff = *(int*)(byteptr_t + 8);

				for (int curpack = 0; curpack < packs; ++curpack)
				{
					int VaultNameOffset = *(int*)(byteptr_t + 0x10 + curpack * 0x14);
					int VaultOffset = *(int*)(byteptr_t + 0x1C + curpack * 0x14);
					string VaultCName = "";
					for (int a1 = VaultNameOffset + cnameoff; *(byteptr_t + a1) != 0; ++a1)
						VaultCName += ((char)*(byteptr_t + a1)).ToString();
					if (VaultCName == "db")
					{
						E_VaultKeys(byteptr_t + VaultOffset);
						break;
					}
				}
			}

			fixed (byte* byteptr_t = &FE_Attrib[0])
			{
				if (*(uint*)byteptr_t != 0x4B415056)
				{
					if (Core.Process.MessageShow)
						MessageBox.Show("fe_attrib: invalid header definition.", "Failure");
					else
						Console.WriteLine("fe_attrib: invalid header definition.");
					return false;
				}

				int packs = *(int*)(byteptr_t + 4);
				int cnameoff = *(int*)(byteptr_t + 8);

				for (int curpack = 0; curpack < packs; ++curpack)
				{
					int VaultNameOffset = *(int*)(byteptr_t + 0x10 + curpack * 0x14);
					int VaultOffset = *(int*)(byteptr_t + 0x1C + curpack * 0x14);
					string VaultCName = "";
					for (int a1 = VaultNameOffset + cnameoff; *(byteptr_t + a1) != 0; ++a1)
						VaultCName += ((char)*(byteptr_t + a1)).ToString();
					if (VaultCName == "frontend")
					{
						E_VaultKeys(byteptr_t + VaultOffset);
						break;
					}
				}
			}

			return true;
		}
	}
}
