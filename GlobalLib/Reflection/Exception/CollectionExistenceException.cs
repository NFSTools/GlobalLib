namespace GlobalLib.Reflection.Exception
{
    public class CollectionExistenceException : System.Exception
    {
        public CollectionExistenceException()
            : base("Class with the collection name provided does not exists.") { }

        public CollectionExistenceException(string message)
            : base(message) { }
    }
}
