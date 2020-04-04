using GlobalLib.Database;



namespace GlobalLib.Reflection.Interface
{
    public interface IGetIndex
    {
        int GetClassIndex(string CName, eClassType ClassType);
    }
}