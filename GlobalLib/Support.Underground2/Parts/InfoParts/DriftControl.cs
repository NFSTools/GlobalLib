namespace GlobalLib.Support.Underground2.Parts.InfoParts
{
    public class DriftControl : VirtualBase, Reflection.Interface.ICopyable<DriftControl>
    {
        public float DriftAdditionalYawControl1 { get; set; } = 0.015F;
        public float DriftAdditionalYawControl2 { get; set; } = 0.2F;
        public float DriftAdditionalYawControl3 { get; set; } = 1.25F;
        public float DriftAdditionalYawControl4 { get; set; } = 0.05F;
        public float DriftAdditionalYawControl5 { get; set; } = 0.05F;
        public float DriftAdditionalYawControl6 { get; set; } = 0.05F;
        public float DriftAdditionalYawControl7 { get; set; } = 0.05F;
        public float DriftAdditionalYawControl8 { get; set; } = 0.05F;

        public DriftControl() { }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public DriftControl PlainCopy()
        {
            var result = new DriftControl();
            var ThisType = this.GetType();
            var ResultType = result.GetType();
            foreach (var ThisProperty in ThisType.GetProperties())
            {
                var ResultField = ResultType.GetProperty(ThisProperty.Name);
                ResultField.SetValue(result, ThisProperty.GetValue(this));
            }
            return result;
        }
    }
}