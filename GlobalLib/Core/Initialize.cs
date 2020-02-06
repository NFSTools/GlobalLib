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
            Utils.Bin.Hash(Reflection.Info.Paint.GLOSS);
            Utils.Bin.Hash(Reflection.Info.Paint.METALLIC);
            Utils.Bin.Hash(Reflection.Info.Paint.PEARL);
            Utils.Bin.Hash(Reflection.Info.Paint.MATTE);
            Utils.Bin.Hash(Reflection.Info.Paint.CHROME);
            Utils.Bin.Hash(Reflection.Info.Paint.CANDY);
            Utils.Bin.Hash(Reflection.Info.Paint.IRIDESCENT);
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
    }
}
