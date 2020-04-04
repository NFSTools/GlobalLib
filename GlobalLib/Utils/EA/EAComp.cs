using System.IO;
using GlobalLib.Core;
using GlobalLib.Utils.DDS;
using GlobalLib.Reflection.ID;



namespace GlobalLib.Utils.EA
{
    /// <summary>
    /// Collection of functions for EA compressed texture files.
    /// </summary>
    public static class Comp
    {
        private const string DXT1 = "DXT1";
        private const string DXT3 = "DXT3";
        private const string DXT5 = "DXT5";
        private const string ARGB = "ARGB";
        private const string P8   = "P8";

        /// <summary>
        /// Determines if an unsigned integer passed is an EA compression.
        /// </summary>
        /// <param name="value">Unsigned integer to be based on.</param>
        /// <returns>True if the value passed is an EA compression.</returns>
        public static bool IsComp(uint value)
        {
            switch (value)
            {
                case EAComp.P8_32:
                case EAComp.RGBA_32:
                case EAComp.DXT1_32:
                case EAComp.DXT3_32:
                case EAComp.DXT5_32:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Get EA compression byte from EA compression uint.
        /// </summary>
        /// <param name="value">Value from which get the result.</param>
        /// <returns>EA compression as a byte value.</returns>
        public static byte GetByte(uint value)
        {
            switch (value)
            {
                case EAComp.DXT1_32:
                    return EAComp.DXT1_08;
                case EAComp.DXT3_32:
                    return EAComp.DXT3_08;
                case EAComp.DXT5_32:
                    return EAComp.DXT5_08;
                case EAComp.P8_32:
                    return EAComp.P8_08;
                default:
                    return EAComp.RGBA_08;
            }
        }

        /// <summary>
        /// Get EA compression byte from EA compression string.
        /// </summary>
        /// <param name="value">Value from which get the result.</param>
        /// <returns>EA compression as a byte value.</returns>
        public static byte GetByte(string value)
        {
            switch (value)
            {
                case DXT1:
                    return EAComp.DXT1_08;
                case DXT3:
                    return EAComp.DXT3_08;
                case DXT5:
                    return EAComp.DXT5_08;
                case P8:
                    return EAComp.P8_08;
                default:
                    return EAComp.RGBA_08;
            }
        }

        /// <summary>
        /// Get EA compression string from EA compression byte.
        /// </summary>
        /// <param name="value">Value from which get the result.</param>
        /// <returns>EA compression as a string value.</returns>
        public static string GetString(byte value)
        {
            switch (value)
            {
                case EAComp.DXT1_08:
                    return DXT1;
                case EAComp.DXT3_08:
                    return DXT3;
                case EAComp.DXT5_08:
                    return DXT5;
                case EAComp.P8_08:
                    return P8;
                default:
                    return ARGB;
            }
        }

        /// <summary>
        /// Get EA compression string from EA compression uint.
        /// </summary>
        /// <param name="value">Value from which get the result.</param>
        /// <returns>EA compression as a string value.</returns>
        public static string GetString(uint value)
        {
            switch (value)
            {
                case EAComp.DXT1_32:
                    return DXT1;
                case EAComp.DXT3_32:
                    return DXT3;
                case EAComp.DXT5_32:
                    return DXT5;
                case EAComp.P8_32:
                    return P8;
                default:
                    return ARGB;
            }
        }

        /// <summary>
        /// Get EA compression uint from EA compression string.
        /// </summary>
        /// <param name="value">Value from which get the result.</param>
        /// <returns>EA compression as a uint value.</returns>
        public static uint GetInt(string value)
        {
            switch (value)
            {
                case DXT1:
                    return EAComp.DXT1_32;
                case DXT3:
                    return EAComp.DXT3_32;
                case DXT5:
                    return EAComp.DXT5_32;
                case P8:
                    return EAComp.P8_32;
                default:
                    return EAComp.RGBA_32;
            }
        }

        /// <summary>
        /// Get EA compression uint from EA compression byte.
        /// </summary>
        /// <param name="value">Value from which get the result.</param>
        /// <returns>EA compression as a uint value.</returns>
        public static uint GetInt(byte value)
        {
            switch (value)
            {
                case EAComp.DXT1_08:
                    return EAComp.DXT1_32;
                case EAComp.DXT3_08:
                    return EAComp.DXT3_32;
                case EAComp.DXT5_08:
                    return EAComp.DXT5_32;
                case EAComp.P8_08:
                    return EAComp.P8_32;
                default:
                    return EAComp.RGBA_32;
            }
        }

        /// <summary>
        /// Calculates base of 2 image area based on the actual size passed.
        /// </summary>
        /// <param name="size">Size in pixels.</param>
        /// <returns>Base of 2 image size in pixels.</returns>
        public static int FlipToBase(int size)
        {
            uint x = (uint)size;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x -= x >> 1;
            return (int)x;
        }

        /// <summary>
        /// Calculates .dds pitch or linear size.
        /// </summary>
        /// <param name="compression">.dds compression format as an EA compression byte.</param>
        /// <param name="width">Width of the image in pixels.</param>
        /// <param name="height">Height of the image in pixels.</param>
        /// <param name="bpp">Bytes per pixel in the image.</param>
        /// <returns>Pitch or linear size based on compression passed.</returns>
        public static uint PitchLinearSize(byte compression, short width, short height, uint bpp)
        {
            int result;
            switch (compression)
            {
                case EAComp.DXT1_08:
                    result = (1 > (width + 3) / 4) ? 1 : (width + 3) / 4;
                    result *= (1 > (height + 3) / 4) ? 1 : (height + 3) / 4;
                    result *= 8;
                    break;

                case EAComp.P8_08:
                case EAComp.RGBA_08:
                    result = (int)width * (int)bpp + 7;
                    result /= 8;
                    break;

                default:
                    result = (1 > (width + 3) / 4) ? 1 : (width + 3) / 4;
                    result *= (1 > (height + 3) / 4) ? 1 : (height + 3) / 4;
                    result *= 16;
                    break;
            }
            return (uint)result;
        }

        /// <summary>
        /// Edits .dds pixelformat based on compression passed.
        /// </summary>
        /// <param name="_PIXELFORMAT">.dds pixelformat of the .dds header passed as a reference type.</param>
        /// <param name="compression">EA compression byte of the image.</param>
        public static void GetPixelFormat(ref DDS_PIXELFORMAT _PIXELFORMAT, byte compression)
        {
            switch (compression)
            {
                case EAComp.DXT1_08:
                    DDS_CONST.DDSPF_DXT1(ref _PIXELFORMAT);
                    break;

                case EAComp.DXT3_08:
                    DDS_CONST.DDSPF_DXT3(ref _PIXELFORMAT);
                    break;

                case EAComp.DXT5_08:
                    DDS_CONST.DDSPF_DXT5(ref _PIXELFORMAT);
                    break;

                default: // set to be RGB in case of mismatch
                    DDS_CONST.DDSPF_A8R8G8B8(ref _PIXELFORMAT);
                    break;
            }
        }

        /// <summary>
        /// Determines if the file is a .dds texture.
        /// </summary>
        /// <param name="filename">Filename to be evaluated.</param>
        /// <returns>True if the texture is a .dds texture.</returns>
        public static bool IsDDSTexture(string filename)
        {
            using (var OpenReader = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read)))
            {
                string name = Path.GetFileNameWithoutExtension(filename);
                if (OpenReader.BaseStream.Length < 0x80) return false;
                if (OpenReader.ReadUInt32() != DDS_MAIN.MAGIC) return false;
                OpenReader.BaseStream.Position = 0x50;
                uint num1 = OpenReader.ReadUInt32();
                uint num2 = OpenReader.ReadUInt32();
                if (!IsComp(num2) && (num1 != DDS_TYPE.RGBA)) return false;
            }
            return true;
        }

        /// <summary>
        /// Determines if the file is a .dds texture.
        /// </summary>
        /// <param name="filename">Filename to be evaluated.</param>
        /// <param name="error">Specifies failure reason in case file is not a .dds texture.</param>
        /// <returns>True if the texture is a .dds texture.</returns>
        public static bool IsDDSTexture(string filename, ref string error)
        {
            using (var OpenReader = new BinaryReader(File.Open(filename, FileMode.Open, FileAccess.Read)))
            {
                string name = Path.GetFileNameWithoutExtension(filename);
                if (OpenReader.BaseStream.Length < 0x80)
                {
                    error = "Texture " + name + " has invalid header type.";
                    return false;
                }
                if (OpenReader.ReadUInt32() != DDS_MAIN.MAGIC)
                {
                    error = "Texture " + name + " has invalid header type.";
                    return false;
                }
                OpenReader.BaseStream.Position = 0x50;
                uint num1 = OpenReader.ReadUInt32();
                uint num2 = OpenReader.ReadUInt32();
                if (!IsComp(num2) && (num1 != DDS_TYPE.RGBA))
                {
                    error = name + ": invalid DDS compression type";
                    return false;
                }
            }
            return true;
        }
    
        /// <summary>
        /// Gets the default .tpk name by index passed.
        /// </summary>
        /// <param name="index">Index of the .tpk in the array.</param>
        /// <returns>Collection Name of the .tpk</returns>
        public static string GetTPKName(int index, GameINT game)
        {
            switch (game)
            {
                case GameINT.Carbon:
                    switch (index)
                    {
                        case 0:
                            return "GLOBALMESSAGETEXTURES";
                        case 1:
                            return "GLOBALTEXTURES";
                        case 2:
                            return "FLARETEXTURES";
                        case 3:
                            return "GLOBALTEXTURESPC";
                        case 4:
                            return "EMITTER_SYSTEM_TEXTURE_PAGE";
                        case 5:
                            return "EMITTER_SYSTEM_NORMALMAPS_P";
                        case 6:
                            return "FLARE_TEXTURE_PAGE";
                        default:
                            return null;
                    }


                case GameINT.MostWanted:
                    switch (index)
                    {
                        case 0:
                            return "GLOBALMESSAGE";
                        case 1:
                        case 2:
                        case 3:
                            return "GLOBAL";
                        default:
                            return null;
                    }

                case GameINT.Underground2:
                    switch (index)
                    {
                        case 0:
                            return "GLOBALMESSAGE";
                        case 1:
                        case 2:
                            return "GLOBAL";
                        default:
                            return null;
                    }

                default:
                    return null;
            }
        }
    }
}