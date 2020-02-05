﻿namespace GlobalLib.Reflection.Interface
{
    interface IOperative
    {
        unsafe bool Import(Database.ClassType type, string filepath);
        void Export(string CName, Database.ClassType type, string filepath);
        void Export(int index, Database.ClassType type, string filepath);
    }
}