namespace GlobalLib.Reflection.Exception
{
    public class CollectionExistenceException : System.Exception
    {
        public CollectionExistenceException()
            : base("Class with the collection name provided already exists.") { }

        public CollectionExistenceException(string message)
            : base(message) { }
    }
}
