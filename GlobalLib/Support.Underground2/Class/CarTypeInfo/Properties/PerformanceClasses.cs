using GlobalLib.Reflection.Attributes;
using GlobalLib.Support.Underground2.Parts.InfoParts;

namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        /* 0x01E0 - 0x0220 */
        [Expandable("Tires")]
        public Tires BASE_TIRES { get; set; }

        /* 0x0650 - 0x0690 */
        [Expandable("Tires")]
        public Tires TOP_TIRES { get; set; }

        /* 0x0280 - 0x02C0 */
        [Expandable("Suspension")]
        public Suspension BASE_SUSPENSION { get; set; }
        /* 0x06D0 - 0x0710 */
        [Expandable("Suspension")]
        public Suspension TOP_SUSPENSION { get; set; }

        /* 0x02C0 - 0x0300 */
        [Expandable("Transmission")]
        public Transmission BASE_TRANSMISSION { get; set; }
        /* 0x0460 - 0x04A0 */
        [Expandable("Transmission")]
        public Transmission STREET_TRANSMISSION { get; set; }
        /* 0x04A0 - 0x04E0 */
        [Expandable("Transmission")]
        public Transmission PRO_TRANSMISSION { get; set; }
        /* 0x04E0 - 0x0520 */
        [Expandable("Transmission")]
        public Transmission TOP_TRANSMISSION { get; set; }

        /* 0x0300 - 0x030C */
        [Expandable("RPM")]
        public RPM BASE_RPM { get; set; }
        /* 0x0560 - 0x056C */
        [Expandable("RPM")]
        public RPM STREET_RPM { get; set; }
        /* 0x05A0 - 0x05AC */
        [Expandable("RPM")]
        public RPM PRO_RPM { get; set; }
        /* 0x05E0 - 0x05EC */
        [Expandable("RPM")]
        public RPM TOP_RPM { get; set; }

        /* 0x0570 - 0x05A0 */
        [Expandable("ECU")]
        public ECU STREET_ECU { get; set; }
        /* 0x05B0 - 0x05E0 */
        [Expandable("ECU")]
        public ECU PRO_ECU { get; set; }
        /* 0x05F0 - 0x0620 */
        [Expandable("ECU")]
        public ECU TOP_ECU { get; set; }

        /* 0x030C - 0x0340 */
        [Expandable("Engine")]
        public Engine BASE_ENGINE { get; set; }
        /* 0x052C - 0x0560 */
        [Expandable("Engine")]
        public Engine TOP_ENGINE { get; set; }

        /* 0x0340 - 0x0370 */
        [Expandable("Turbo")]
        public Turbo BASE_TURBO { get; set; }
        /* 0x0620 - 0x0650 */
        [Expandable("Turbo")]
        public Turbo TOP_TURBO { get; set; }

        /* 0x0374 - 0x0390 */
        [Expandable("Brakes")]
        public Brakes BASE_BRAKES { get; set; }
        /* 0x06B0 - 0x06D0 */
        [Expandable("Brakes")]
        public Brakes TOP_BRAKES { get; set; }

        /* 0x0450 - 0x0460 */
        [Expandable("WeightReduction")]
        public WeightReduction TOP_WEIGHT_REDUCTION { get; set; }

        /* 0x0690 - 0x06A0 */
        [Expandable("NOS")]
        public Nitrous TOP_NITROUS { get; set; }

        /* 0x03C0 - 0x03E0 */
        [Expandable("DriftControl")]
        public DriftControl DRIFT_ADD_CONTROL { get; set; }
	}
}