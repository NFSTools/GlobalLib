using System;
using GlobalLib.Utils.EA;



namespace GlobalLib.Support.Shared.Parts.FNGParts
{
    public class FEngColor
    {
        public byte Red    { get; set; } = 0;
        public byte Green  { get; set; } = 0;
        public byte Blue   { get; set; } = 0;
        public byte Alpha  { get; set; } = 0;
        public uint Offset { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return obj is FEngColor && this == (FEngColor)obj;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(this.Alpha, this.Red, this.Green, this.Blue, this.Offset).GetHashCode();
        }

        public static bool operator== (FEngColor c1, FEngColor c2)
        {
            return c1.Red == c2.Red && c1.Green == c2.Green && c1.Blue == c2.Blue;
        }

        public static bool operator!= (FEngColor c1, FEngColor c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"Offset: {this.Offset:X8} | Color: " +
                $"{SAT.ColorToHex(this.Alpha, this.Red, this.Green, this.Blue)}";
        }
    }
}
