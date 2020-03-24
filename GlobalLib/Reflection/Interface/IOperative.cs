namespace GlobalLib.Reflection.Interface
{
    interface IOperative
    {
        bool TryAddClass(string CName, string root);
        bool TryAddClass(string CName, string root, out string error);
        bool TryRemoveClass(string CName, string root);
        bool TryRemoveClass(string CName, string root, out string error);
        bool TryCloneClass(string newname, string copyfrom, string root);
        bool TryCloneClass(string newname, string copyfrom, string root, out string error);
        bool TryImportClass(string root, string filepath);
        bool TryImportClass(string root, string filepath, out string error);
        //bool TryExportClass(string CName, string root, string filepath);
        //bool TryExportClass(string CName, string root, string filepath, out string error);
    }
}