using GlobalLib.Reflection.Enum;
using GlobalLib.Utils;
using System;

namespace GlobalLib.Core
{
    static class Initialize
    {
        public static void Init()
        {
            Map.RimBrands.Clear();
            Map.WindowTintMap.Clear();
            Map.CollisionMap.Clear();
            PaintTypes();
            BodyPaints();
            Windshields();
            RimBrandArray();
            HashImportantStrings();
        }

        public static void InitUG2()
        {
            Map.RimBrands.Clear();
            Map.AudioTypes.Clear();
            Map.WindowTintMap.Clear();
            Map.CollisionMap.Clear();
            UG2PaintTypes();
            UG2BankTriggers();
            Windshields();
            HashImportantStrings();
            Map.PerfPartTable = new uint[10, 3, 4];
        }

        /// <summary>
        /// Initializes all paint type strings into raider memory map.
        /// </summary>
        private static void PaintTypes()
        {
            // Paint types
            var GLOSS = "GLOSS";
            var METAL = "METAL";
            var PEARL = "PEARL";
            var MATTE = "MATTE";
            var CHROME = "CHROME";

            // Extra strings
            var COLOR = "_L1_COLOR";
            var COLOR00 = "_L1_COLOR0";
            var COLOR10 = "_L1_COLOR";
            var _PAINT = "_PAINT";

            // Main strings
            string _paint_1;
            string _paint_2;

            // GLOSS/METAL + _L1_COLOR + 00-80
            for (int a1 = 0; a1 < 81; ++a1)
            {
                var a1Padding = a1.ToString("D2");

                _paint_1 = $"{GLOSS}{COLOR}{a1Padding}";
                Map.BinKeys[Bin.Hash(_paint_1)] = _paint_1;

                _paint_1 = $"{METAL}{COLOR}{a1Padding}";
                Map.BinKeys[Bin.Hash(_paint_1)] = _paint_1;

                if (a1 < 21)
                {
                    _paint_1 = $"{PEARL}{a1Padding}";
                    Map.BinKeys[Bin.Hash(_paint_1)] = _paint_1;

                    if (a1 < 11)
                    {
                        _paint_1 = $"{MATTE}{a1Padding}";
                        Map.BinKeys[Bin.Hash(_paint_1)] = _paint_1;

                        _paint_1 = $"{CHROME}{a1Padding}";
                        Map.BinKeys[Bin.Hash(_paint_1)] = _paint_1;
                    }
                }
            }

            // Cop and Traffic paint types
            _paint_1 = "COP_L1_COLOR01";
            _paint_2 = "TRAFFIC_L1_COLOR01";
            Map.BinKeys[Bin.Hash(_paint_1)] = _paint_1;
            Map.BinKeys[Bin.Hash(_paint_2)] = _paint_2;
        }

        /// <summary>
        /// Initializes medium and light windshields for UG2 and MW
        /// </summary>
        private static void Windshields()
        {
            Map.WindowTintMap.AddRange(new string[]
            {
                "WINDSHIELD_TINT_L1_BLACK",
                "WINDSHIELD_TINT_L1_GREEN",
                "WINDSHIELD_TINT_L1_BLUE",
                "WINDSHIELD_TINT_L1_RED",
                "WINDSHIELD_TINT_L1_MED_BLACK",
                "WINDSHIELD_TINT_L1_MED_GREEN",
            });

            for (int a1 = 0; a1 < Map.WindowTintMap.Count; ++a1)
                Bin.Hash(Map.WindowTintMap[a1]);
        }

        /// <summary>
        /// Initializes all body paint types into raider memory map.
        /// </summary>
        private static void BodyPaints()
        {
            var paints = Enum.GetNames(typeof(eCarbonPaint));
            foreach (var paint in paints)
                Bin.Hash(paint);
        }

        /// <summary>
        /// Initializes all rim brands into rim brand memory array.
        /// </summary>
        private static void RimBrandArray()
        {
            Map.RimBrands.AddRange(new string[] 
            {
                "AUTOSCLPT",
                "5ZIGEN",
                "ADR",
                "AR",
                "BBS",
                "CL",
                "ENKEI",
                "GIOVANNA",
                "HRE",
                "IFORGED",
                "KONIG",
                "LOWENHART",
                "OZ",
                "RACINGHART",
                "ROJA",
                "TENZO",
                "TSW",
                "VOLK",
                "WORK",
            });
        }

        /// <summary>
        /// Initializes all UG2 paint type strings into its paint memory map.
        /// </summary>
        private static void UG2PaintTypes()
        {
            // Paint types
            var GLOSS = "GLOSS";
            var METAL = "METAL";
            var PEARL = "PEARL";
            var HOSES = "HOSES";
            var MUFFLERS = "MUFFLERS";
            var CUSTOMPAINT = "CUSTOMPAINT_";

            // Extra strings
            var COLOR = "_COLOR";
            var NEW = "_NEW_";
            var TEST = "_TEST";
            var _PAINT = "_PAINT";
            var _1 = "1";
            var _2 = "2";
            var _3 = "3";
            var _L = "_L";

            for (int a1 = 1; a1 < 31; ++a1)
            {
                var a1Padding = a1.ToString("D2");

                if (a1 < 21)
                {
                    Map.UG2PaintTypes.AddRange(new string[]
                    {
                          $"{GLOSS}{_L}{_2}{COLOR}{a1Padding}",
                          $"{METAL}{_L}{_2}{NEW}{a1Padding}",
                          $"{METAL}{_L}{_3}{TEST}{a1Padding}",
                          $"{HOSES}{_L}{_2}{COLOR}{a1Padding}",
                          $"{MUFFLERS}{_L}{_2}{COLOR}{a1Padding}",
                          $"{CUSTOMPAINT}{a1}",
                    });

                    if (a1 < 11)
                    {
                        Map.UG2PaintTypes.AddRange(new string[]
                        {
                        $"{GLOSS}{_L}{_1}{COLOR}{a1Padding}",
                        $"{METAL}{_L}{_2}{COLOR}{a1Padding}",
                        $"{HOSES}{_L}{_1}{COLOR}{a1Padding}",
                        $"{MUFFLERS}{_L}{_1}{COLOR}{a1Padding}",
                        $"{PEARL}{a1}{_PAINT}",
                        });
                    }
                }

                if (a1 > 20)
                {
                    Map.UG2PaintTypes.Add($"{METAL}{_L}{_3}{NEW}{a1Padding}");
                }

                Map.UG2PaintTypes.AddRange(new string[]
                {
                    $"{GLOSS}{_L}{_3}{TEST}{a1Padding}",
                    $"{METAL}{_L}{_3}{COLOR}{a1Padding}",
                    $"{HOSES}{_L}{_3}{COLOR}{a1Padding}",
                    $"{MUFFLERS}{_L}{_3}{COLOR}{a1Padding}",
                });
            }

            // Fix of one of colors
            Map.UG2PaintTypes.Remove("HOSES_L3_COLOR01");
            Map.UG2PaintTypes.Add("HOSES_L3_TEST01");

            // Hashing of all paint types
            foreach (var paint in Map.UG2PaintTypes)
                Bin.Hash(paint);
        }

        /// <summary>
        /// Hashes most important strings used when processing data.
        /// </summary>
        private static void HashImportantStrings()
        {
            Bin.Hash(Reflection.BaseArguments.RANDOM);
            Bin.Hash(Reflection.BaseArguments.GLOBAL);
            Bin.Hash(Reflection.BaseArguments.DEFAULT);
        }

        /// <summary>
        /// Hashes all labels for bank triggers.
        /// </summary>
        private static void UG2BankTriggers()
        {
            for (int a1 = 0; a1 < 100; ++a1)
                Bin.Hash($"BANK_TRIGGER_{a1:00}");
        }
    }
}
