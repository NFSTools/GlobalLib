namespace GlobalLib.Support.MostWanted.Class
{
    public partial class Texture : Shared.Class.Texture, Reflection.Interface.ICastable<Texture>
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
                    throw new System.ArgumentNullException("This value cannot be left empty.");
                if (value.Length > 0x17)
                    throw new Reflection.Exception.ArgumentLengthException("Length of the value passed should not exceed 23 characters.");
                int index = this.Database.GetClassIndex(this._parent_TPK, GlobalLib.Database.ClassType.TPKBlock);
                if (this.Database.TPKBlocks[index].GetTextureIndex(value) != -1)
                    throw new Reflection.Exception.CollectionExistenceException();
                this._collection_name = value;
            }
        }
    }
}