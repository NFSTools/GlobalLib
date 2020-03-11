namespace GlobalLib.Reflection.Interface
{
    interface IOperative
    {
        unsafe bool Import(Database.eClassType type, string filepath);
        void Export(string CName, Database.eClassType type, string filepath);
        void Export(int index, Database.eClassType type, string filepath);
    }
}