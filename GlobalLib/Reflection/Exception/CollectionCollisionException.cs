namespace GlobalLib.Reflection.Exception
{
    public class CollectionExistanceException : System.Exception
    {
        public CollectionExistanceException()
            : base("Class with the collection name provided does not exists.") { }
    }
}
