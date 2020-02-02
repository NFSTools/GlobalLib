using System.Collections.Generic;



namespace GlobalLib.Support.MostWanted.Class
{
    public partial class SlotType : Shared.Class.SlotType
    {
        public List<Parts.CarParts.Part56> Part56 { get; set; }
        public Parts.CarParts.Spoilers Spoilers { get; set; }
        public Dictionary<uint, Parts.CarParts.Collision> Collisions { get; set; }
    }
}