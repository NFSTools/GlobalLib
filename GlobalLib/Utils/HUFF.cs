using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLib.Utils
{
	public static class HUFF
	{
		private const int ZERO = 0;

		public static unsafe int Decompress(byte[] buffer, out byte[] array)
		{
			array = null;
			if (buffer == null || buffer.Length == 0) return 0;
			array = new byte[1];
			fixed (byte* _in = &buffer[0], _out = &array[0])
			{
				// Since buffers and their pointers are fixed, make new unmanaged pointers
				byte* _InBuffer = _in;
				byte* _OutBuffer = _out;

				int v4 = 0;
				int v5 = 0;
				int v6 = 0;
				int v11 = 0;
				int v12 = 0;
				int v13 = 0;
				int v14 = 0;
				var v15 = false;
				int v16 = 0;
				int v17 = 0;
				int v18 = 0;
				int v30 = 0;
				uint v103 = 0;
				int v104 = 0;
				var v106 = new int[15];
				int v108 = 0;
				var v112 = new int[16];

				// I guess it checks whether it is a HUFF ???
				v4 = v4.HIWORD(0);
				v4 = v4.BYTEn(*_InBuffer, 1);
				_InBuffer += 2;
				v4 = v4.LOBYTE(*(_InBuffer - 1));
				int v7 = (ushort)v4 << 16;

				int v8 = v7 >> 16; // right shift 2 bytes
				int v9 = v7 << 16; // left shift 2 bytes
				int v10 = 0;

				v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
				_InBuffer += 2;
				v9 = v4 << 16;

				// First if-else based on v8 value
				if ((v8 & 0x8000) == 0)
				{
					if ((v8 & 0x100) != 0)
					{
						v17 = v9 << 8;
						v18 = 8;

						v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
						_InBuffer += 2;
						v17 = v4 << 8;

						v9 = v17 << 16;
						v10 = 8;

						v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
						_InBuffer += 2;
						v9 = v4 << 8;
					}
					v103 = (uint)(v8 & 0xFFFFFEFF);
					v13 = v9 >> 24;
					v14 = v9 << 8;
				}
				else
				{
					if ((v8 & 0x100) != 0)
					{
						v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
						_InBuffer += 2;
						v11 = v4 << 16;

						v9 = v11 << 16;
						v10 = v12 - 16;

						v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
						_InBuffer += 2;
						v9 = v4 << 16;
					}
					v103 = (uint)(v8 & 0xFFFFFEFF);
					v13 = v9 >> 16;
					v14 = v9 << 16;
					v15 = true;
				}

				// If was else-statement previously
				if (v15)
				{
					v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
					_InBuffer += 2;
					v14 = v4 << 16;
				}

				int v19 = v14 >> 16;
				int v20 = v14 << 16;
				int v21 = 0;

				v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
				_InBuffer += 2;
				v20 = v4 << 16;

				int v22 = (v13 << 16) | v19;
				int v23 = v20 >> 24;
				int v24 = v20 << 8;
				int v25 = 8;
				int v90 = v22;
				byte v101 = (byte)v23;

				v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
				_InBuffer += 2;
				v24 = v4 << 8;

				int v26 = 0;
				int v94 = 0;
				int v92 = 1;

				while (true)
				{
					int v85 = 2 * v26;
					v112[v92] = 2 * v26 - v94;
					if ((v24 & 0x80000000) == 0)
					{
						int v28 = 2;
						if ((v24 & 0xFFFF0000) != 0)
						{
							do { v24 *= 2; ++v28; } while ((v24 & 0x80000000) == 0);
							v25 += 1 - v28;
							v24 *= 2;
							if (ZERO != 0)
							{
								v5 = v24 >> (32 - ZERO);
								v24 <<= ZERO;
								v25 -= ZERO;
							}
							if (v25 < 0)
							{
								v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
								_InBuffer += 2;
								v24 = v4 << -(byte)v25;
								v25 += 16;
							}
						}
						else
						{
							do
							{
								++v28;
								v5 = v24 >> 31;
								v24 *= 2;
								if (--v25 < 0)
								{
									v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
									_InBuffer += 2;
									v24 = v4 << -(byte)v25;
									v25 += 16;
								}
							} while (v5 == 0);
						}
						if (v28 <= 16)
						{
							if (v28 != 0)
							{
								v5 = v24 >> (32 - v28);
								v24 <<= v28;
								v25 -= v28;
							}
							if (v25 < 0)
							{
								v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
								_InBuffer += 2;
								v24 = v4 << -(byte)v25;
								v25 += 16;
							}
							v30 = v28;
						}
						else
						{
							if (v28 != 16)
							{
								v5 = v24 >> (48 - v28);
								v24 <<= v28 - 16;
								v25 += 16 - v28;
							}
							if (v25 < 0)
							{
								v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
								_InBuffer += 2;
								v24 = v4 << -(byte)v25;
								v25 += 16;
							}
							int v29 = v24 >> 16;
							v24 <<= 16;
							v25 -= 16;
							if (v25 < 0)
							{
								v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
								_InBuffer += 2;
								v24 = v4 << -(byte)v25;
								v25 += 16;
							}
							v5 = v29 | (v5 << 16);
							v30 = v28;
						}
						v5 = v5 + (1 << v30) - 4;
					}
					else
					{
						int v27 = v24 >> 29;
						v24 *= 8;
						v25 -= 3;
						if (v25 < 0)
						{
							v4 = _InBuffer[1] | ((*_InBuffer | (v4 << 8)) << 8);
							_InBuffer += 2;
							v24 = v4 << -(byte)v25;
							v25 += 16;
						}
						v5 = v27 - 4;
					}
					v106[v92] = v5;
					int v86 = v5 + v85;
					int v31 = 0;
					v94 += v5;
					if (v5 != 0)
						v31 = (v86 << (16 - v92)) & 0xFFFF;
					*(&v108 + v92++) = v31; // <----- wtf? questionable, super
					if (v5 != 0)
					{
						if (v31 == 0)
							break;
					}
					v26 = v86;
				}





			}
			return 0;
		}

		private static unsafe short LOBYTE(this short value, byte int8)
		{
			*(byte*)&value = int8;
			return value;
		}

		private static unsafe short HIBYTE(this short value, byte int8)
		{
			*((byte*)&value + 1) = int8;
			return value;
		}

		private static unsafe int LOBYTE(this int value, byte int8)
		{
			*(byte*)&value = int8;
			return value;
		}

		private static unsafe int HIBYTE(this int value, byte int8)
		{
			*((byte*)&value + 1) = int8;
			return value;
		}

		private static unsafe long LOBYTE(this long value, byte int8)
		{
			*(byte*)&value = int8;
			return value;
		}

		private static unsafe long HIBYTE(this long value, byte int8)
		{
			*((byte*)&value + 1) = int8;
			return value;
		}

		private static unsafe int LOWORD(this int value, short int16)
		{
			*(short*)&value = int16;
			return value;
		}

		private static unsafe int HIWORD(this int value, short int16)
		{
			*((short*)&value + 1) = int16;
			return value;
		}

		private static unsafe long LOWORD(this long value, short int16)
		{
			*(short*)&value = int16;
			return value;
		}

		private static unsafe long HIWORD(this long value, short int16)
		{
			*((short*)&value + 1) = int16;
			return value;
		}

		private static unsafe long LODWORD(this long value, short int32)
		{
			*(int*)&value = int32;
			return value;
		}

		private static unsafe long HIDWORD(this long value, short int32)
		{
			*((int*)&value + 1) = int32;
			return value;
		}

		private static unsafe int BYTEn(this int value, byte int8, int pos)
		{
			*((byte*)&value + pos) = int8;
			return value;
		}

		private static unsafe long BYTEn(this long value, byte int8, int pos)
		{
			*((byte*)&value + pos) = int8;
			return value;
		}

		private static unsafe long WORDn(this long value, short int16, int pos)
		{
			*((short*)&value + pos) = int16;
			return value;
		}
	}
}
