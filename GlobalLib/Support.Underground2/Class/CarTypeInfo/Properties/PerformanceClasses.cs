﻿namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo
    {
        /* 0x01E0 - 0x0220 */
        [Reflection.Attributes.Expandable("Tires")]
        public Parts.InfoParts.Tires BASE_TIRES { get; set; }

        /* 0x0650 - 0x0690 */
        [Reflection.Attributes.Expandable("Tires")]
        public Parts.InfoParts.Tires TOP_TIRES { get; set; }

        /* 0x0280 - 0x02C0 */
        [Reflection.Attributes.Expandable("Suspension")]
        public Parts.InfoParts.Suspension BASE_SUSPENSION { get; set; }
        /* 0x06D0 - 0x0710 */
        [Reflection.Attributes.Expandable("Suspension")]
        public Parts.InfoParts.Suspension TOP_SUSPENSION { get; set; }

        /* 0x02C0 - 0x0300 */
        [Reflection.Attributes.Expandable("Transmission")]
        public Parts.InfoParts.Transmission BASE_TRANSMISSION { get; set; }
        /* 0x0460 - 0x04A0 */
        [Reflection.Attributes.Expandable("Transmission")]
        public Parts.InfoParts.Transmission STREET_TRANSMISSION { get; set; }
        /* 0x04A0 - 0x04E0 */
        [Reflection.Attributes.Expandable("Transmission")]
        public Parts.InfoParts.Transmission PRO_TRANSMISSION { get; set; }
        /* 0x04E0 - 0x0520 */
        [Reflection.Attributes.Expandable("Transmission")]
        public Parts.InfoParts.Transmission TOP_TRANSMISSION { get; set; }

        /* 0x0300 - 0x030C */
        [Reflection.Attributes.Expandable("RPM")]
        public Parts.InfoParts.RPM BASE_RPM { get; set; }
        /* 0x0560 - 0x056C */
        [Reflection.Attributes.Expandable("RPM")]
        public Parts.InfoParts.RPM STREET_RPM { get; set; }
        /* 0x05A0 - 0x05AC */
        [Reflection.Attributes.Expandable("RPM")]
        public Parts.InfoParts.RPM PRO_RPM { get; set; }
        /* 0x05E0 - 0x05EC */
        [Reflection.Attributes.Expandable("RPM")]
        public Parts.InfoParts.RPM TOP_RPM { get; set; }

        /* 0x0570 - 0x05A0 */
        [Reflection.Attributes.Expandable("ECU")]
        public Parts.InfoParts.ECU STREET_ECU { get; set; }
        /* 0x05B0 - 0x05E0 */
        [Reflection.Attributes.Expandable("ECU")]
        public Parts.InfoParts.ECU PRO_ECU { get; set; }
        /* 0x05F0 - 0x0620 */
        [Reflection.Attributes.Expandable("ECU")]
        public Parts.InfoParts.ECU TOP_ECU { get; set; }

        /* 0x030C - 0x0340 */
        [Reflection.Attributes.Expandable("Engine")]
        public Parts.InfoParts.Engine BASE_ENGINE { get; set; }
        /* 0x052C - 0x0560 */
        [Reflection.Attributes.Expandable("Engine")]
        public Parts.InfoParts.Engine TOP_ENGINE { get; set; }

        /* 0x0340 - 0x0370 */
        [Reflection.Attributes.Expandable("Turbo")]
        public Parts.InfoParts.Turbo BASE_TURBO { get; set; }
        /* 0x0620 - 0x0650 */
        [Reflection.Attributes.Expandable("Turbo")]
        public Parts.InfoParts.Turbo TOP_TURBO { get; set; }

        /* 0x0374 - 0x0390 */
        [Reflection.Attributes.Expandable("Brakes")]
        public Parts.InfoParts.Brakes BASE_BRAKES { get; set; }
        /* 0x06B0 - 0x06D0 */
        [Reflection.Attributes.Expandable("Brakes")]
        public Parts.InfoParts.Brakes TOP_BRAKES { get; set; }

        /* 0x0450 - 0x0460 */
        [Reflection.Attributes.Expandable("WeightReduction")]
        public Parts.InfoParts.WeightReduction TOP_WEIGHT_REDUCTION { get; set; }

        /* 0x0690 - 0x06A0 */
        [Reflection.Attributes.Expandable("NOS")]
        public Parts.InfoParts.Nitrous TOP_NITROUS { get; set; }

        /* 0x03C0 - 0x03E0 */
        [Reflection.Attributes.Expandable("DriftControl")]
        public Parts.InfoParts.DriftControl DRIFT_ADD_CONTROL { get; set; }
	}
}