using GlobalLib.Reflection.Interface;



namespace GlobalLib.Support.Carbon.Parts.PresetParts
{
    public class Vinyl : ICopyable<Vinyl>, IGetValue, ISetValue
    {
        private string _vectorvinyl = Reflection.BaseArguments.NULL;
        private byte _swatch1 = 0;
        private byte _swatch2 = 0;
        private byte _swatch3 = 0;
        private byte _swatch4 = 0;

        public string VectorVinyl
        {
            get => this._vectorvinyl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                this._vectorvinyl = value;
            }
        }

        public short PositionY  { get; set; } = 0;
        public short PositionX  { get; set; } = 0;
        public sbyte Rotation   { get; set; } = 0;
        public sbyte Skew       { get; set; } = 0;
        public sbyte ScaleY     { get; set; } = 0;
        public sbyte ScaleX     { get; set; } = 0;
        public byte Saturation1 { get; set; } = 0;
        public byte Brightness1 { get; set; } = 0;
        public byte Saturation2 { get; set; } = 0;
        public byte Brightness2 { get; set; } = 0;
        public byte Saturation3 { get; set; } = 0;
        public byte Brightness3 { get; set; } = 0;
        public byte Saturation4 { get; set; } = 0;
        public byte Brightness4 { get; set; } = 0;

        public byte SwatchColor1
        {
            get => this._swatch1;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._swatch1 = value;
            }
        }

        public byte SwatchColor2
        {
            get => this._swatch2;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._swatch2 = value;
            }
        }

        public byte SwatchColor3
        {
            get => this._swatch3;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._swatch3 = value;
            }
        }

        public byte SwatchColor4
        {
            get => this._swatch4;
            set
            {
                if (value > 90)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._swatch4 = value;
            }
        }

        /// <summary>
        /// Creates a plane copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Vinyl PlainCopy()
        {
            var result = new Vinyl();
            var ThisType = this.GetType();
            var ResultType = result.GetType();
            foreach (var ThisProperty in ThisType.GetProperties())
            {
                var ResultField = ResultType.GetProperty(ThisProperty.Name);
                ResultField.SetValue(result, ThisProperty.GetValue(this));
            }
            return result;
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public string GetValue(string PropertyName)
        {
            var ThisType = this.GetType();
            foreach (var ThisProperty in ThisType.GetProperties())
            {
                if (ThisProperty.Name == PropertyName)
                    return ThisProperty.GetValue(this).ToString();
            }
            return null;
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public bool SetValue(string PropertyName, object value)
        {
            try
            {
                var ThisType = this.GetType();
                foreach (var ThisProperty in ThisType.GetProperties())
                {
                    if (ThisProperty.Name == PropertyName)
                    {
                        ThisProperty.SetValue(this, Utils.Cast.RuntimeCast(value, ThisProperty.GetValue(this)));
                        return true;
                    }
                }
                return false;
            }
            catch (System.Exception e)
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message);
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        /// <param name="error">Error occured in case setting value fails.</param>
        public virtual bool SetValue(string PropertyName, object value, ref string error)
        {
            try
            {
                var ThisType = this.GetType();
                foreach (var ThisProperty in ThisType.GetProperties())
                {
                    if (ThisProperty.Name == PropertyName)
                    {
                        ThisProperty.SetValue(this, Utils.Cast.RuntimeCast(value, ThisProperty.GetValue(this)));
                        return true;
                    }
                }
                error = $"Field named {PropertyName} does not exist.";
                return false;
            }
            catch (System.Exception e)
            {
                error = e.Message;
                return false;
            }
        }
    }
}
