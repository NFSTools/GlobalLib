﻿namespace GlobalLib.Support.Underground2.Class
{
    public partial class CarTypeInfo : Shared.Class.CarTypeInfo, Reflection.Interface.ICastable<CarTypeInfo>
    {
        private string _defaultbasepaint = Reflection.BaseArguments.UGPAINT;
        private string _defaultbasepaint2 = Reflection.BaseArguments.UGPAINT;

        /// <summary>
        /// Represents first paint type of the cartypeinfo.
        /// </summary>
        public new string DefaultBasePaint
        {
            get => this._defaultbasepaint;
            set
            {
                if (Core.Map.UG2PaintTypes.Contains(value))
                    this._defaultbasepaint = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }

        /// <summary>
        /// Represents second paint type of the cartypeinfo.
        /// </summary>
        public string DefaultBasePaint2
        {
            get => this._defaultbasepaint2;
            set
            {
                if (Core.Map.UG2PaintTypes.Contains(value))
                    this._defaultbasepaint2 = value;
                else
                    throw new Reflection.Exception.MappingFailException();
            }
        }
    }
}