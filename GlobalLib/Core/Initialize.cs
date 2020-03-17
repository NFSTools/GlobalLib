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
        }

        /// <summary>
        /// Initializes all paint type strings into raider memory map.
        /// </summary>
        private static void PaintTypes()
        {
            // Paint types
            string GLOSS = "GLOSS";
            string METAL = "METAL";
            string PEARL = "PEARL";
            string MATTE = "MATTE";
            string CHROME = "CHROME";

            // Extra strings
            string COLOR00 = "_L1_COLOR0";
            string COLOR10 = "_L1_COLOR";
            string _PAINT = "_PAINT";
            string _0 = "0";

            // Main strings
            string _paint_1;
            string _paint_2;

            // GLOSS/METAL + _L1_COLOR + 00-80
            for (int a1 = 0; a1 < 81; ++a1)
            {
                _paint_1 = (a1 < 10)
                    ? GLOSS + COLOR00 + a1.ToString()
                    : GLOSS + COLOR10 + a1.ToString();
                _paint_2 = (a1 < 10)
                    ? METAL + COLOR00 + a1.ToString()
                    : METAL + COLOR10 + a1.ToString();
                Map.BinKeys[Utils.Bin.Hash(_paint_1)] = _paint_1;
                Map.BinKeys[Utils.Bin.Hash(_paint_2)] = _paint_2;
            }

            // PEARL + 00-20 + _PAINT
            for (int a1 = 0; a1 < 21; ++a1)
            {
                _paint_1 = (a1 < 10)
                    ? PEARL + _0 + a1.ToString() + _PAINT
                    : PEARL + a1.ToString() + _PAINT;
                Map.BinKeys[Utils.Bin.Hash(_paint_1)] = _paint_1;
            }

            // MATTE/CHROME + 00-10 + _PAINT
            for (int a1 = 0; a1 < 11; ++a1)
            {
                _paint_1 = (a1 < 10)
                    ? MATTE + _0 + a1.ToString() + _PAINT
                    : MATTE + a1.ToString() + _PAINT;
                _paint_2 = (a1 < 10)
                    ? CHROME + _0 + a1.ToString() + _PAINT
                    : CHROME + a1.ToString() + _PAINT;
                Map.BinKeys[Utils.Bin.Hash(_paint_1)] = _paint_1;
                Map.BinKeys[Utils.Bin.Hash(_paint_2)] = _paint_2;
            }

            // Cop and Traffic paint types
            _paint_1 = "COP_L1_COLOR01";
            _paint_2 = "TRAFFIC_L1_COLOR01";
            Map.BinKeys[Utils.Bin.Hash(_paint_1)] = _paint_1;
            Map.BinKeys[Utils.Bin.Hash(_paint_2)] = _paint_2;
        }

        /// <summary>
        /// Initializes medium and light windshields for UG2 and MW
        /// </summary>
        private static void Windshields()
        {
            Map.WindowTintMap.Add("WINDSHIELD_TINT_L1_BLACK");
            Map.WindowTintMap.Add("WINDSHIELD_TINT_L1_GREEN");
            Map.WindowTintMap.Add("WINDSHIELD_TINT_L1_BLUE");
            Map.WindowTintMap.Add("WINDSHIELD_TINT_L1_RED");
            Map.WindowTintMap.Add("WINDSHIELD_TINT_L1_MED_BLACK");
            Map.WindowTintMap.Add("WINDSHIELD_TINT_L1_MED_GREEN");
            for (int a1 = 0; a1 < Map.WindowTintMap.Count; ++a1)
                Utils.Bin.Hash(Map.WindowTintMap[a1]);
        }

        /// <summary>
        /// Initializes all body paint types into raider memory map.
        /// </summary>
        private static void BodyPaints()
        {
            var paints = System.Enum.GetNames(typeof(Reflection.Enum.eCarbonPaint));
            foreach (var paint in paints)
                Utils.Bin.Hash(paint);
        }

        /// <summary>
        /// Initializes all rim brands into rim brand memory array.
        /// </summary>
        private static void RimBrandArray()
        {
            Map.RimBrands.Add("AUTOSCLPT");
            Map.RimBrands.Add("5ZIGEN");
            Map.RimBrands.Add("ADR");
            Map.RimBrands.Add("AR");
            Map.RimBrands.Add("BBS");
            Map.RimBrands.Add("CL");
            Map.RimBrands.Add("ENKEI");
            Map.RimBrands.Add("GIOVANNA");
            Map.RimBrands.Add("HRE");
            Map.RimBrands.Add("IFORGED");
            Map.RimBrands.Add("KONIG");
            Map.RimBrands.Add("LOWENHART");
            Map.RimBrands.Add("OZ");
            Map.RimBrands.Add("RACINGHART");
            Map.RimBrands.Add("ROJA");
            Map.RimBrands.Add("TENZO");
            Map.RimBrands.Add("TSW");
            Map.RimBrands.Add("VOLK");
            Map.RimBrands.Add("WORK");
        }
    
        /// <summary>
        /// Initializes all UG2 paint type strings into its paint memory map.
        /// </summary>
        private static void UG2PaintTypes()
        {
            // Paint types
            string GLOSS = "GLOSS";
            string METAL = "METAL";
            string PEARL = "PEARL";
            string HOSES = "HOSES";
            string MUFFLERS = "MUFFLERS";
            string CUSTOMPAINT = "CUSTOMPAINT_";

            // Extra strings
            string COLOR00 = "_COLOR0";
            string COLOR10 = "_COLOR";
            string TEST00 = "_TEST0";
            string TEST10 = "_TEST";
            string NEW00 = "_NEW_0";
            string NEW10 = "_NEW_";
            string _PAINT = "_PAINT";
            string _1 = "1";
            string _2 = "2";
            string _3 = "3";
            string _L = "_L";

            // L1 Concatenation and mapping
            for (int a1 = 1; a1 < 11; ++a1)
            {
                if (a1 < 10)
                {
                    Map.UG2PaintTypes.Add(string.Concat(GLOSS, _L, _1, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _2, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(HOSES, _L, _1, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(MUFFLERS, _L, _1, COLOR00, a1.ToString()));
                }
                else
                {
                    Map.UG2PaintTypes.Add(string.Concat(GLOSS, _L, _1, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _2, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(HOSES, _L, _1, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(MUFFLERS, _L, _1, COLOR10, a1.ToString()));
                }
                Map.UG2PaintTypes.Add(string.Concat(PEARL, a1.ToString(), _PAINT));
            }

            // L2 Concatenation and mapping
            for (int a1 = 1; a1 < 21; ++a1)
            {
                if (a1 < 10)
                {
                    Map.UG2PaintTypes.Add(string.Concat(GLOSS, _L, _2, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _2, NEW00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _3, TEST00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(HOSES, _L, _2, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(MUFFLERS, _L, _2, COLOR00, a1.ToString()));
                }
                else
                {
                    Map.UG2PaintTypes.Add(string.Concat(GLOSS, _L, _2, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _2, NEW10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _3, TEST10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(HOSES, _L, _2, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(MUFFLERS, _L, _2, COLOR10, a1.ToString()));
                }
                Map.UG2PaintTypes.Add(string.Concat(CUSTOMPAINT, a1.ToString()));
            }

            // L3 Concatenation and mapping
            for (int a1 = 1; a1 < 31; ++a1)
            {
                if (a1 < 10)
                {
                    Map.UG2PaintTypes.Add(string.Concat(GLOSS, _L, _3, TEST00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _3, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(HOSES, _L, _3, COLOR00, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(MUFFLERS, _L, _3, COLOR00, a1.ToString()));
                }
                else
                {
                    Map.UG2PaintTypes.Add(string.Concat(GLOSS, _L, _3, TEST10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _3, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(HOSES, _L, _3, COLOR10, a1.ToString()));
                    Map.UG2PaintTypes.Add(string.Concat(MUFFLERS, _L, _3, COLOR10, a1.ToString()));
                }
            }

            // Extra L3 Concatenation and mapping
            for (int a1 = 21; a1 < 31; ++a1)
            {
                Map.UG2PaintTypes.Add(string.Concat(METAL, _L, _3, NEW10, a1.ToString()));

            }

            // Fix of one of colors
            Map.UG2PaintTypes.Remove("HOSES_L3_COLOR01");
            Map.UG2PaintTypes.Add("HOSES_L3_TEST01");

            // Hashing of all paint types
            foreach (var paint in Map.UG2PaintTypes)
                Utils.Bin.Hash(paint);
        }
    
        /// <summary>
        /// Hashes most important strings used when processing data.
        /// </summary>
        private static void HashImportantStrings()
        {
            Utils.Bin.Hash(Reflection.BaseArguments.RANDOM);
            Utils.Bin.Hash(Reflection.BaseArguments.GLOBAL);
            Utils.Bin.Hash(Reflection.BaseArguments.DEFAULT);
        }
    
        /// <summary>
        /// Hashes all labels for bank triggers.
        /// </summary>
        private static void UG2BankTriggers()
        {
            for (int a1 = 0; a1 < 100; ++a1)
                Utils.Bin.Hash($"BANK_TRIGGER_{a1:00}");
        }
    }
}
