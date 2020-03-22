using System.Collections.Generic;



namespace GlobalLib.Support.Underground2.Class
{
    public partial class SlotType : Shared.Class.SlotType
    {
        public List<Parts.CarParts.Part56> Part56 { get; set; }
        public Parts.CarParts.SpoilMirr SpoilMirrs { get; set; }

        public override string ToString()
        {
            return $"Part56 Count: {Part56.Count}"; // change later
        }
    }
}