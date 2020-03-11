namespace GlobalLib.Reflection.Interface
{
    public interface IGetIndex
    {
        int GetClassIndex(string CName, Database.eClassType ClassType);
    }
}