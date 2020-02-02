﻿namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Material : Shared.Class.Material, Reflection.Interface.ICastable<Material>
    {
        private float _reflection1 = 0;
        private float _reflection2 = 0;
        private float _reflection3 = 0;

        /// <summary>
        /// First reflection value of the material.
        /// </summary>
        public float Reflection1
        {
            get => this._reflection1;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._reflection1 = value;
            }
        }

        /// <summary>
        /// Second reflection value of the material.
        /// </summary>
        public float Reflection2
        {
            get => this._reflection2;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._reflection2 = value;
            }
        }

        /// <summary>
        /// Third reflection value of the material.
        /// </summary>
        public float Reflection3
        {
            get => this._reflection3;
            set
            {
                if (value < 0)
                    throw new System.ArgumentOutOfRangeException();
                else
                    this._reflection3 = value;
            }
        }
    }
}