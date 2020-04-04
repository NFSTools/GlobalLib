namespace GlobalLib.Utils.DDS
{
    public static class DDS_MAIN
    {
        public const uint MAGIC = 0x20534444; // "DDS "
    }

    public class DDS_PIXELFORMAT
    {
        /* 0x4C - 0x4F */ public uint dwSize;
        /* 0x50 - 0x53 */ public uint dwFlags;
        /* 0x50 - 0x57 */ public uint dwFourCC;
        /* 0x50 - 0x5B */ public uint dwRGBBitCount;
        /* 0x50 - 0x5F */ public uint dwRBitMask;
        /* 0x60 - 0x63 */ public uint dwGBitMask;
        /* 0x60 - 0x67 */ public uint dwBBitMask;
        /* 0x60 - 0x6B */ public uint dwABitMask;
    }

    public class DDS_HEADER
    {
        /* 0x04 - 0x07 */ public uint dwSize;
        /* 0x08 - 0x0B */ public uint dwFlags;
        /* 0x0C - 0x0F */ public uint dwHeight;
        /* 0x10 - 0x13 */ public uint dwWidth;
        /* 0x14 - 0x17 */ public uint dwPitchOrLinearSize;
        /* 0x17 - 0x1B */ public uint dwDepth; // only if DDS_HEADER_FLAGS_VOLUME is set in dwFlags
        /* 0x1C - 0x1F */ public uint dwMipMapCount;
        /* 0x20 - 0x4B */ public uint[] dwReserved1 = new uint[11];
        /* 0x4C - 0x6B */ public DDS_PIXELFORMAT ddspf = new DDS_PIXELFORMAT();
        /* 0x6C - 0x6F */ public uint dwCaps;
        /* 0x70 - 0x73 */ public uint dwCaps2;
        /* 0x74 - 0x77 */ public uint dwCaps3;
        /* 0x78 - 0x7B */ public uint dwCaps4;
        /* 0x7C - 0x7F */ public uint dwReserved2;
        
        /* Default constructor */ public DDS_HEADER()
        {
            for (int _loop_ = 0; _loop_ < 11; ++_loop_) this.dwReserved1[_loop_] = 0; // unused
            this.dwCaps2 = 0; // usually it is not a 3D texture
            this.dwCaps3 = 0; // unused
            this.dwCaps4 = 0; // unused
            this.dwReserved2 = 0; // unused
            this.dwSize = 0x7C; // always const, unless stated otherwise
        }
        /* Default destructor  */ ~DDS_HEADER() { }
    }

    public static class DDS_TYPE
    {
        public const uint FOURCC     = 0x00000004;  // DDPF_FOURCC
        public const uint RGB        = 0x00000040;  // DDPF_RGB
        public const uint RGBA       = 0x00000041;  // DDPF_RGB | DDPF_ALPHAPIXELS
        public const uint LUMINANCE  = 0x00020000;  // DDPF_LUMINANCE
        public const uint LUMINANCEA = 0x00020001;  // DDPF_LUMINANCE | DDPF_ALPHAPIXELS
        public const uint ALPHA      = 0x00000002;  // DDPF_ALPHA
        public const uint PAL8       = 0x00000020;  // DDPF_PALETTEINDEXED8
        public const uint PAL8A      = 0x00000021;  // DDPF_PALETTEINDEXED8 | DDPF_ALPHAPIXELS
        public const uint BUMPDUDV   = 0x00080000;  // DDPF_BUMPDUDV
    }

    public static class DDS_HEADER_FLAGS
    {
        public const uint TEXTURE    = 0x00001007;  // DDSD_CAPS | DDSD_HEIGHT | DDSD_WIDTH | DDSD_PIXELFORMAT
        public const uint MIPMAP     = 0x00020000;  // DDSD_MIPMAPCOUNT
        public const uint VOLUME     = 0x00800000;  // DDSD_DEPTH
        public const uint PITCH      = 0x00000008;  // DDSD_PITCH
        public const uint LINEARSIZE = 0x00080000;  // DDSD_LINEARSIZE
        public const uint DDS_HEIGHT = 0x00000002;  // DDSD_HEIGHT
        public const uint DDS_WIDTH  = 0x00000004;  // DDSD_WIDTH

    }

    public static class DDSCAPS
    {
        public const uint SURFACE_FLAGS_TEXTURE = 0x00001000; // DDSCAPS_TEXTURE
        public const uint SURFACE_FLAGS_MIPMAP  = 0x00400008; // DDSCAPS_COMPLEX | DDSCAPS_MIPMAP
        public const uint SURFACE_FLAGS_CUBEMAP = 0x00000008; // DDSCAPS_COMPLEX
    }

    public static class DDSCAPS2
    {
        public const uint CUBEMAP           = 0x00000200; // DDSCAPS2_CUBEMAP
        public const uint FLAGS_VOLUME      = 0x00200000; // DDSCAPS2_VOLUME
        public const uint CUBEMAP_POSITIVEX = 0x00000600; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEX
        public const uint CUBEMAP_NEGATIVEX = 0x00000a00; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEX
        public const uint CUBEMAP_POSITIVEY = 0x00001200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEY
        public const uint CUBEMAP_NEGATIVEY = 0x00002200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEY
        public const uint CUBEMAP_POSITIVEZ = 0x00004200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_POSITIVEZ
        public const uint CUBEMAP_NEGATIVEZ = 0x00008200; // DDSCAPS2_CUBEMAP | DDSCAPS2_CUBEMAP_NEGATIVEZ
        public const uint CUBEMAP_ALLFACES  = CUBEMAP_POSITIVEX | CUBEMAP_POSITIVEY | CUBEMAP_POSITIVEZ |
                                                CUBEMAP_NEGATIVEX | CUBEMAP_NEGATIVEY | CUBEMAP_NEGATIVEZ;
    }

    // Subset here matches D3D10_RESOURCE_DIMENSION and D3D11_RESOURCE_DIMENSION
    public enum DDS_RESOURCE_DIMENSION
    {
        DDS_DIMENSION_TEXTURE1D = 2,
        DDS_DIMENSION_TEXTURE2D = 3,
        DDS_DIMENSION_TEXTURE3D = 4,
    };

    // Subset here matches D3D10_RESOURCE_MISC_FLAG and D3D11_RESOURCE_MISC_FLAG
    public enum DDS_RESOURCE_MISC_FLAG
    {
        DDS_RESOURCE_MISC_TEXTURECUBE = 0x4,
    };

    public enum DDS_MISC_FLAGS2
    {
        DDS_MISC_FLAGS2_ALPHA_MODE_MASK = 0x7,
    };

    public enum DDS_ALPHA_MODE
    {
        DDS_ALPHA_MODE_UNKNOWN       = 0,
        DDS_ALPHA_MODE_STRAIGHT      = 1,
        DDS_ALPHA_MODE_PREMULTIPLIED = 2,
        DDS_ALPHA_MODE_OPAQUE        = 3,
        DDS_ALPHA_MODE_CUSTOM        = 4,
    };

    public static class DDS_CONST
    {
        // Standard MAKEFOURCC that requires bytes to be passed
        public static uint MAKEFOURCC(byte c1, byte c2, byte c3, byte c4)
        {
            return (uint)(c1) | ((uint)(c2) << 8) | ((uint)(c3) << 16) | ((uint)(c4) << 24);
        }

        // MAKEFOURCC that uses ReinterpretCast to cast any passed objects to it into uint
        public static uint MAKEFOURCC_R(object c1, object c2, object c3, object c4)
        {
            var a1 = (uint)Cast.ReinterpretCast(c1, typeof(uint));
            var a2 = (uint)Cast.ReinterpretCast(c2, typeof(uint));
            var a3 = (uint)Cast.ReinterpretCast(c3, typeof(uint));
            var a4 = (uint)Cast.ReinterpretCast(c4, typeof(uint));
            return a1 | a2 << 8 | a3 << 16 | a4 << 24;
        }

        public static void DDSPF_DXT1(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('D', 'X', 'T', '1');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_DXT2(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('D', 'X', 'T', '2');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_DXT3(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('D', 'X', 'T', '3');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_DXT4(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('D', 'X', 'T', '4');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_DXT5(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('D', 'X', 'T', '5');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_DX10(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('D', 'X', '1', '0');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_BC4_UNORM(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('B', 'C', '4', 'U');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_BC4_SNORM(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('B', 'C', '4', 'S');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_BC5_UNORM(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('B', 'C', '5', 'U');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_BC5_SNORM(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('B', 'C', '5', 'S');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_R8G8_B8G8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('R', 'G', 'B', 'G');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_G8R8_G8B8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('G', 'R', 'G', 'B');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_YUY2(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.FOURCC;
            _PIXELFORMAT.dwFourCC = MAKEFOURCC_R('Y', 'U', 'Y', '2');
            _PIXELFORMAT.dwRGBBitCount = 0;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_A8R8G8B8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGBA;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x00FF0000;
            _PIXELFORMAT.dwGBitMask = 0x0000FF00;
            _PIXELFORMAT.dwBBitMask = 0x000000FF;
            _PIXELFORMAT.dwABitMask = 0xFF000000;
        }

        public static void DDSPF_X8R8G8B8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGB;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x00FF0000;
            _PIXELFORMAT.dwGBitMask = 0x0000FF00;
            _PIXELFORMAT.dwBBitMask = 0x000000FF;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_A8B8G8R8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGBA;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x000000FF;
            _PIXELFORMAT.dwGBitMask = 0x0000FF00;
            _PIXELFORMAT.dwBBitMask = 0x00FF0000;
            _PIXELFORMAT.dwABitMask = 0xFF000000;
        }

        public static void DDSPF_X8B8G8R8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGB;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x000000FF;
            _PIXELFORMAT.dwGBitMask = 0x0000FF00;
            _PIXELFORMAT.dwBBitMask = 0x00FF0000;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_G16R16(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGB;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x0000FFFF;
            _PIXELFORMAT.dwGBitMask = 0xFFFF0000;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_R5G6B5(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGB;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 16;
            _PIXELFORMAT.dwRBitMask = 0x0000F800;
            _PIXELFORMAT.dwGBitMask = 0x000007E0;
            _PIXELFORMAT.dwBBitMask = 0x0000001F;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_A1R5G5B5(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGBA;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 16;
            _PIXELFORMAT.dwRBitMask = 0x00007C00;
            _PIXELFORMAT.dwGBitMask = 0x000003E0;
            _PIXELFORMAT.dwBBitMask = 0x0000001F;
            _PIXELFORMAT.dwABitMask = 0x00008000;
        }

        public static void DDSPF_R8G8B8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.RGB;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 24;
            _PIXELFORMAT.dwRBitMask = 0x00FF0000;
            _PIXELFORMAT.dwGBitMask = 0x0000FF00;
            _PIXELFORMAT.dwBBitMask = 0x000000FF;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_L8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.LUMINANCE;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 8;
            _PIXELFORMAT.dwRBitMask = 0x00FF;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_L16(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.LUMINANCE;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 16;
            _PIXELFORMAT.dwRBitMask = 0xFFFF;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_A8L8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.LUMINANCEA;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 16;
            _PIXELFORMAT.dwRBitMask = 0x00FF;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0xFF00;
        }

        public static void DDSPF_A8L8_ALT(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.LUMINANCEA;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 8;
            _PIXELFORMAT.dwRBitMask = 0x00FF;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0xFF00;
        }

        public static void DDSPF_A8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.ALPHA;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 8;
            _PIXELFORMAT.dwRBitMask = 0;
            _PIXELFORMAT.dwGBitMask = 0;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0x00FF;
        }

        public static void DDSPF_V8U8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.BUMPDUDV;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 16;
            _PIXELFORMAT.dwRBitMask = 0x00FF;
            _PIXELFORMAT.dwGBitMask = 0xFF00;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_V16U16(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.BUMPDUDV;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x0000FFFF;
            _PIXELFORMAT.dwGBitMask = 0xFFFF0000;
            _PIXELFORMAT.dwBBitMask = 0;
            _PIXELFORMAT.dwABitMask = 0;
        }

        public static void DDSPF_Q8W8V8U8(ref DDS_PIXELFORMAT _PIXELFORMAT)
        {
            _PIXELFORMAT.dwSize = 0x20;
            _PIXELFORMAT.dwFlags = DDS_TYPE.BUMPDUDV;
            _PIXELFORMAT.dwFourCC = 0;
            _PIXELFORMAT.dwRGBBitCount = 32;
            _PIXELFORMAT.dwRBitMask = 0x000000FF;
            _PIXELFORMAT.dwGBitMask = 0x0000FF00;
            _PIXELFORMAT.dwBBitMask = 0x00FF0000;
            _PIXELFORMAT.dwABitMask = 0xFF000000;
        }
    }
}
