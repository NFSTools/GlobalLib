using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;



namespace GlobalLib.Utils
{
	public class MemoryWriter
	{
		private byte[] stream;
		public int Position { get; set; }
		public int Length { get => this.stream.Length; }
		public byte[] Data { get => this.stream; }

		public MemoryWriter()
		{
			this.stream = new byte[0]; // empty initializer
			this.Position = 0;
		}
		public MemoryWriter(int count)
		{
			this.stream = new byte[count];
			this.Position = 0;
		}
		public MemoryWriter(byte[] array)
		{
			this.stream = array;
			this.Position = 0;
		}

		private bool IsEnumerableType(PropertyInfo property)
		{
			return (!typeof(string).Equals(property.PropertyType) &&
				typeof(IEnumerable).IsAssignableFrom(property.PropertyType));
		}
		private bool IsEnumerableType(FieldInfo field)
		{
			return (!typeof(string).Equals(field.FieldType) &&
				typeof(IEnumerable).IsAssignableFrom(field.FieldType));
		}
		private void CheckLength(int length)
		{
			if (this.Position + length > this.Length)
				Array.Resize(ref this.stream, this.Position + length);
		}
		private unsafe void WriteObject(object value, bool propertyonly)
		{
			if (value is string)
				this.WriteNullTerminated((string)value);
			else if (value is bool)
				this.Write((bool)value);
			else if (value is byte)
				this.Write((byte)value);
			else if (value is sbyte)
				this.Write((sbyte)value);
			else if (value is char)
				this.Write((char)value);
			else if (value is short)
				this.Write((short)value);
			else if (value is ushort)
				this.Write((ushort)value);
			else if (value is int)
				this.Write((int)value);
			else if (value is uint)
				this.Write((uint)value);
			else if (value is long)
				this.Write((long)value);
			else if (value is ulong)
				this.Write((ulong)value);
			else if (value is float)
				this.Write((float)value);
			else if (value is double)
				this.Write((double)value);
			else if (value is decimal)
				this.Write((decimal)value);
			else
			{
				var memtype = typeof(MemoryWriter);
				var thistype = value.GetType();
				var method = memtype.GetMethod("WriteClass");
				var gmethod = method.MakeGenericMethod(thistype);
				object[] objs = new object[2] { value, propertyonly };
				gmethod.Invoke(this, objs);
			}
		}

		/// <summary>
		/// Writes a one-byte Boolean value to the current stream, with 0 representing false 
		/// and 1 representing true.
		/// </summary>
		/// <param name="value">The Boolean value to write (0 or 1).</param>
		public unsafe void Write(bool value)
		{
			this.CheckLength(sizeof(bool));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*dataptr_t = value ? (byte)1 : (byte)0;
			}
			this.Position += sizeof(bool);
		}
		/// <summary>
		/// Writes an unsigned byte to the current stream and advances the stream position 
		/// by one byte.
		/// </summary>
		/// <param name="value">The unsigned byte to write.</param>
		public unsafe void Write(byte value)
		{
			this.CheckLength(sizeof(byte));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*dataptr_t = value;
			}
			this.Position += sizeof(byte);
		}
		/// <summary>
		/// Writes a signed byte to the current stream and advances the stream position by 
		/// one byte.
		/// </summary>
		/// <param name="value">The signed byte to write.</param>
		public unsafe void Write(sbyte value)
		{
			this.CheckLength(sizeof(sbyte));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(sbyte*)dataptr_t = value;
			}
			this.Position += sizeof(sbyte);
		}
		/// <summary>
		/// Writes a Unicode character to the to the current stream and advances the stream 
		/// position by two bytes.
		/// </summary>
		/// <param name="value">The character to write.</param>
		public unsafe void Write(char value)
		{
			this.CheckLength(sizeof(char));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(char*)dataptr_t = value;
			}
			this.Position += sizeof(char);
		}
		/// <summary>
		/// Writes a byte array to the underlying stream.
		/// </summary>
		/// <param name="array">A byte array containing the data to write.</param>
		public unsafe void Write(byte[] array)
		{
			if (array == null) return;
			this.CheckLength(sizeof(byte) * array.Length);
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				for (int a1 = 0; a1 < array.Length; ++a1)
					*(dataptr_t + a1) = array[a1];
			}
			this.Position += array.Length;
		}
		/// <summary>
		/// Writes a character array to the current stream and advances the current position
		/// of the stream by the length of the array times size of one character (usually 2 bytes).
		/// </summary>
		/// <param name="array">A character array containing the data to write.</param>
		public unsafe void Write(char[] array)
		{
			if (array == null) return;
			this.CheckLength(sizeof(char) * array.Length);
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				for (int a1 = 0; a1 < array.Length; ++a1)
					*(char*)(dataptr_t + a1 * sizeof(char)) = array[a1];
			}
			this.Position += array.Length * sizeof(char);
		}
		/// <summary>
		/// Writes a region of a byte array to the current stream.
		/// </summary>
		/// <param name="array">A byte array containing the data to write.</param>
		/// <param name="offset">The index of the first byte to read from buffer and to write to the stream.</param>
		/// <param name="count">The number of bytes to read from buffer and to write to the stream.</param>
		public unsafe void Write(byte[] array, int offset, int count)
		{
			if (array == null || offset < 0 || count <= 0 || offset + count > array.Length)
				return;
			this.CheckLength(count * sizeof(byte));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				for (int a1 = 0; a1 < count; ++a1)
					*(dataptr_t + a1) = array[offset + a1];
			}
			this.Position += count;
		}
		/// <summary>
		/// Writes a region of a character array to the current stream.
		/// </summary>
		/// <param name="array">A character array containing the data to write.</param>
		/// <param name="offset">The index of the first character to read from chars and to write to the stream.</param>
		/// <param name="count">The number of characters to read from chars and to write to the stream.</param>
		public unsafe void Write(char[] array, int offset, int count)
		{
			if (array == null || offset < 0 || count <= 0 || offset + count > array.Length)
				return;
			this.CheckLength(count * sizeof(char));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				for (int a1 = 0; a1 < count; ++a1)
					*(char*)(dataptr_t + a1 * sizeof(char)) = array[offset + a1];
			}
			this.Position += count * sizeof(char);
		}
		/// <summary>
		/// Writes a two-byte signed integer to the current stream and advances the stream 
		/// position by two bytes.
		/// </summary>
		/// <param name="value">The two-byte signed integer to write.</param>
		public unsafe void Write(short value)
		{
			this.CheckLength(sizeof(short));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(short*)dataptr_t = value;
			}
			this.Position += sizeof(short);
		}
		/// <summary>
		/// Writes a two-byte unsigned integer to the current stream and advances the stream 
		/// position by two bytes.
		/// </summary>
		/// <param name="value">The two-byte unsigned integer to write.</param>
		public unsafe void Write(ushort value)
		{
			this.CheckLength(sizeof(ushort));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(ushort*)dataptr_t = value;
			}
			this.Position += sizeof(ushort);
		}
		/// <summary>
		/// Writes a four-byte signed integer to the current stream and advances the stream 
		/// position by four bytes.
		/// </summary>
		/// <param name="value">The four-byte signed integer to write.</param>
		public unsafe void Write(int value)
		{
			this.CheckLength(sizeof(int));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(int*)dataptr_t = value;
			}
			this.Position += sizeof(int);
		}
		/// <summary>
		/// Writes a four-byte unsigned integer to the current stream and advances the stream 
		/// position by four bytes.
		/// </summary>
		/// <param name="value">The four-byte unsigned integer to write.</param>
		public unsafe void Write(uint value)
		{
			this.CheckLength(sizeof(uint));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(uint*)dataptr_t = value;
			}
			this.Position += sizeof(uint);
		}
		/// <summary>
		/// Writes an eight-byte signed integer to the current stream and advances the stream 
		/// position by eight bytes.
		/// </summary>
		/// <param name="value">The eight-byte signed integer to write.</param>
		public unsafe void Write(long value)
		{
			this.CheckLength(sizeof(long));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(long*)dataptr_t = value;
			}
			this.Position += sizeof(long);
		}
		/// <summary>
		/// Writes an eight-byte unsigned integer to the current stream and advances the 
		/// stream position by eight bytes.
		/// </summary>
		/// <param name="value">The eight-byte unsigned integer to write.</param>
		public unsafe void Write(ulong value)
		{
			this.CheckLength(sizeof(ulong));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(ulong*)dataptr_t = value;
			}
			this.Position += sizeof(ulong);
		}
		/// <summary>
		/// Writes a four-byte floating-point value to the current stream and advances the 
		/// stream position by four bytes.
		/// </summary>
		/// <param name="value">The four-byte floating-point value to write.</param>
		public unsafe void Write(float value)
		{
			this.CheckLength(sizeof(float));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(float*)dataptr_t = value;
			}
			this.Position += sizeof(float);
		}
		/// <summary>
		/// Writes an eight-byte floating-point value to the current stream and advances 
		/// the stream position by eight bytes.
		/// </summary>
		/// <param name="value">The eight-byte floating-point value to write.</param>
		public unsafe void Write(double value)
		{
			this.CheckLength(sizeof(double));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(double*)dataptr_t = value;
			}
			this.Position += sizeof(double);
		}
		/// <summary>
		/// Writes a decimal value to the current stream and advances the stream position 
		/// by sixteen bytes.
		/// </summary>
		/// <param name="value">The decimal value to write.</param>
		public unsafe void Write(decimal value)
		{
			this.CheckLength(sizeof(decimal));
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*(decimal*)dataptr_t = value;
			}
			this.Position += sizeof(decimal);
		}
		/// <summary>
		/// Writes a length-prefixed string to this stream and advances the current position 
		/// of the stream by the length of the string plus one byte.
		/// </summary>
		/// <param name="value">The value to write.</param>
		public unsafe void Write(string value)
		{
			if (value == null)
			{
				this.Write((byte)0);
				++this.Position;
				return;
			}
			this.CheckLength(value.Length + 1);
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				*dataptr_t = (byte)value.Length;
				for (int a1 = 0; a1 < value.Length; ++a1)
					*(dataptr_t + a1 + 1) = (byte)value[a1];
			}
			this.Position += value.Length + 1;
		}
		/// <summary>
		/// Writes a null-terminated string to this stream and advances the current position 
		/// of the stream by the length of the string plus one byte.
		/// </summary>
		/// <param name="value">The value to write.</param>
		public unsafe void WriteNullTerminated(string value)
		{
			if (value == null)
			{
				this.Write((byte)0);
				++this.Position;
				return;
			}
			this.CheckLength(value.Length + 1);
			fixed (byte* dataptr_t = &this.stream[this.Position])
			{
				for (int a1 = 0; a1 < value.Length; ++a1)
					*(dataptr_t + a1) = (byte)value[a1];
			}
			this.Position += value.Length + 1;
		}
		/// <summary>
		/// Writes a null-terminated string to this stream and advances the current position 
		/// of the stream by the padding length specified. If padding is less than length of 
		/// the string, string gets truncated.
		/// </summary>
		/// <param name="value">The value to write.</param>
		/// <param name="padding">Amount of padding to add after null-termination, or the 
		/// maximum length of the string allowed.</param>
		public unsafe void WriteNullTerminated(string value, int padding)
		{
			if (value == null)
			{
				this.Write((byte)0);
				++this.Position;
			}
			else
			{
				this.CheckLength(padding);
				fixed (byte* dataptr_t = &this.stream[this.Position])
				{
					for (int a1 = 0; a1 < padding - 1 && a1 < value.Length; ++a1)
						*(dataptr_t + a1) = (byte)value[a1];
				}
				this.Position += padding;
			}
		}
		/// <summary>
		/// Writes array of certain type to the current stream and advances position by the 
		/// size of the array times size of the type passed.
		/// </summary>
		/// <typeparam name="TypeID">Type of variables of the array.</typeparam>
		/// <param name="array">The array to write.</param>
		public unsafe void WriteArray<TypeID>(TypeID[] array)
		{
			foreach (var obj in array)
				this.WriteObject(obj, false);
		}
		/// <summary>
		/// Writes enumerable of certain type to the current stream and advances position by the 
		/// size of the enumerable times size of the type passed.
		/// </summary>
		/// <typeparam name="TypeID">Type of the variables of the enumerable.</typeparam>
		/// <param name="enumerable">The enumerable to write.</param>
		public unsafe void WriteEnumerable<TypeID>(IEnumerable<TypeID> enumerable)
		{
			foreach (var obj in enumerable)
				this.WriteObject(obj, false);
		}
		/// <summary>
		/// Writes a class or a struct to the current stream, including all its static, public, 
		/// protected, private, and instance members, as well as all enumerables and subclass, 
		/// and advances position of the stream by the relative marshal size of the class. Note: 
		/// this is a very dangerous function, you should never use it if classes contain dictionary 
		/// types in the them, as well as reflective fields pointing to the parents of the class.
		/// </summary>
		/// <typeparam name="TypeID">Type of the class or struct to write.</typeparam>
		/// <param name="value">Class or struct to write.</param>
		/// <param name="propertyonly">If set to true, writes down only absolute properties 
		/// of the class or struct and all its subclasses. If set to false, writes down all 
		/// fields and properties of the class or struct and its subclasses.</param>
		public unsafe void WriteClass<TypeID>(TypeID value, bool propertyonly)
		{
			var ThisType = typeof(TypeID);
			if (propertyonly)
			{
				foreach (var ThisProperty in ThisType.GetProperties(BindingFlags.Public |
						 BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
				{
					if (this.IsEnumerableType(ThisProperty))
					{
						var enumerator = ThisProperty.GetValue(value) as IEnumerable;
						if (enumerator == null) continue;
						foreach (var obj in enumerator)
							this.WriteObject(obj, propertyonly);

					}
					else
						this.WriteObject(ThisProperty.GetValue(value), propertyonly);
				}
			}
			else
			{
				foreach (var ThisField in ThisType.GetFields(BindingFlags.Public |
						 BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic))
				{
					if (this.IsEnumerableType(ThisField))
					{
						var enumerator = ThisField.GetValue(value) as IEnumerable;
						if (enumerator == null) continue;
						foreach (var obj in enumerator)
							this.WriteObject(obj, propertyonly);

					}
					else
						this.WriteObject(ThisField.GetValue(value), propertyonly);
				}
			}
		}
		/// <summary>
		/// Saves current stream to the file specified.
		/// </summary>
		/// <param name="filename">The file to open.</param>
		public void SaveToFile(string filename)
		{
			this.SaveToFile(filename, FileMode.Open, FileAccess.Write);
		}
		/// <summary>
		/// Saves current stream to the file specified.
		/// </summary>
		/// <param name="filename">The file to open.</param>
		/// <param name="mode">A System.IO.FileMode value that specifies whether a file is 
		/// created if one does not exist, and determines whether the contents of existing 
		/// files are retained or overwritten.</param>
		public void SaveToFile(string filename, FileMode mode)
		{
			this.SaveToFile(filename, mode, FileAccess.Write);
		}
		/// <summary>
		/// Saves current stream to the file specified.
		/// </summary>
		/// <param name="filename">The file to open.</param>
		/// <param name="mode">A System.IO.FileMode value that specifies whether a file is 
		/// created if one does not exist, and determines whether the contents of existing 
		/// files are retained or overwritten.</param>
		/// <param name="access">A System.IO.FileAccess value that specifies the operations 
		/// that can be performed on the file.</param>
		public void SaveToFile(string filename, FileMode mode, FileAccess access)
		{
			if (access == FileAccess.Read)
				throw new FieldAccessException("Unable to write to the file specified because access was not granted");
			using (var bw = new BinaryWriter(File.Open(filename, mode, access)))
			{
				bw.Write(this.stream);
			}
		}
		/// <summary>
		/// Sets the position within the current stream.
		/// </summary>
		/// <param name="offset">A byte offset relative to the origin parameter.</param>
		/// <param name="origin">A value of type System.IO.SeekOrigin indicating the 
		/// reference point used to obtain the new position.</param>
		public void Seek(int offset, SeekOrigin origin)
		{
			switch (origin)
			{
				case SeekOrigin.Begin:
					if (offset <= this.Length)
						this.Position = offset;
					return;
				case SeekOrigin.End:
					if (offset <= this.Length)
						this.Position = this.Length - offset;
					return;
				case SeekOrigin.Current:
					if (this.Position + offset <= this.Length)
						this.Position += offset;
					else this.Position = this.Length;
					return;
			}
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
}