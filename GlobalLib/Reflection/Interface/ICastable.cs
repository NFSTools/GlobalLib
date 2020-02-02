namespace GlobalLib.Reflection.Interface
{
    public interface ICastable<TypeID>
    {
        unsafe TypeID MemoryCast(string CName);
    }
}