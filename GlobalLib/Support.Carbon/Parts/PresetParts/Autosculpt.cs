﻿using GlobalLib.Reflection.Abstract;
using GlobalLib.Reflection.Interface;
using System;

namespace GlobalLib.Support.Carbon.Parts.PresetParts
{
    public class Autosculpt : SubPart, ICopyable<Autosculpt>
    {
        private byte _zone1 = 0;
        private byte _zone2 = 0;
        private byte _zone3 = 0;
        private byte _zone4 = 0;
        private byte _zone5 = 0;
        private byte _zone6 = 0;
        private byte _zone7 = 0;
        private byte _zone8 = 0;
        private byte _zone9 = 0;

        public byte AutosculptZone1
        {
            get => this._zone1;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone1 = value;
            }
        }

        public byte AutosculptZone2
        {
            get => this._zone2;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone2 = value;
            }
        }

        public byte AutosculptZone3
        {
            get => this._zone3;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone3 = value;
            }
        }

        public byte AutosculptZone4
        {
            get => this._zone4;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone4 = value;
            }
        }

        public byte AutosculptZone5
        {
            get => this._zone5;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone5 = value;
            }
        }

        public byte AutosculptZone6
        {
            get => this._zone6;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone6 = value;
            }
        }

        public byte AutosculptZone7
        {
            get => this._zone7;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone7 = value;
            }
        }

        public byte AutosculptZone8
        {
            get => this._zone8;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone8 = value;
            }
        }

        public byte AutosculptZone9
        {
            get => this._zone9;
            set
            {
                if (value > 100)
                    throw new ArgumentOutOfRangeException("This value should be in range 0 to 100.");
                else
                    this._zone9 = value;
            }
        }

        /// <summary>
        /// Creates a plain copy of the objects that contains same values.
        /// </summary>
        /// <returns>Exact plain copy of the object.</returns>
        public Autosculpt PlainCopy()
        {
            var result = new Autosculpt();
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
