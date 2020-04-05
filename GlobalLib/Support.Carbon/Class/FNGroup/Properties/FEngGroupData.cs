using System;

namespace GlobalLib.Support.Carbon.Class
{
    public partial class FNGroup
    {
        private byte[] _DATA;

        /// <summary>
        /// Data of the FEng file.
        /// </summary>
        public byte[] Data
        {
            get => this._DATA;
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("This value cannot be left empty.");
                else
                    this._DATA = value;
            }
        }
    }
}