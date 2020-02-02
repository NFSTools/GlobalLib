namespace GlobalLib.Support.Shared.Class
{
    public partial class PresetSkin : Reflection.Interface.IGetValue, Reflection.Interface.ISetValue
    {
        private string _collection_name;

        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public string CollectionName
        {
            get => this._collection_name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentNullException();
                if (value.Length > 0x1F)
                    throw new Reflection.Exception.ArgumentLengthException();
                this._collection_name = value;
            }
        }
    }
}