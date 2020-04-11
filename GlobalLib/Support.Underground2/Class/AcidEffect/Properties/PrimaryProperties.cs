using System;
using GlobalLib.Reflection;
using GlobalLib.Reflection.Attributes;

namespace GlobalLib.Support.Underground2.Class
{
	public partial class AcidEffect
	{
        private string _inheritance_key = BaseArguments.NULL;

        [AccessModifiable()]
        [StaticModifiable()]
        public uint ClassKey { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public uint Flags { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public ushort NumEmitters { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public ushort SectionNumber { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public string InheritanceKey
        {
            get => this._inheritance_key;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("This value cannot be empty or whitespace.");
                this._inheritance_key = value;
            }
        }

        [AccessModifiable()]
        [StaticModifiable()]
        public float FarClip { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public float Intensity { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public float LastPositionX { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public float LastPositionY { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public float LastPositionZ { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public float LastPositionW { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public uint NumZeroParticleFrames { get; set; }

        [AccessModifiable()]
        [StaticModifiable()]
        public uint CreationTimeStamp { get; set; }
    }
}