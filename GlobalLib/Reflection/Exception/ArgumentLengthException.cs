namespace GlobalLib.Reflection.Exception
{
    public class ArgumentLengthException : System.Exception
    {
        public ArgumentLengthException()
            : base("Length of the passed argument exceeds the maximum allowed value.") { }

        public ArgumentLengthException(string message)
            : base(message) { }
    }
}
