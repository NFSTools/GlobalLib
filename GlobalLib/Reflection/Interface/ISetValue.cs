namespace GlobalLib.Reflection.Interface
{
    public interface ISetValue
    {
        bool SetValue(string PropertyName, object value);
        bool SetValue(string PropertyName, object value, ref string error);
    }
}