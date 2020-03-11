namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Imports class data from a file specified.
        /// </summary>
        /// <param name="type">Class type to be imported. Range: Material, CarTypeInfo, PresetRide, PresetSkin.</param>
        /// <param name="filepath">File with data to be imported.</param>
        public unsafe bool Import(eClassType type, string filepath)
        {
            if (!System.IO.File.Exists(filepath))
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show("File specified does not exist.", "Warning");
                else
                    System.Console.WriteLine("File specified does not exist.");
                return false;
            }

            byte[] data;
            string CName = "";

            try
            {
                data = System.IO.File.ReadAllBytes(filepath);
            }
            catch (System.Exception e)
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message, "Warning");
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }

            fixed (byte* dataptr_t = &data[0])
            {
                switch (type)
                {
                    case eClassType.Material:
                        if (data.Length != 0xF4)
                            goto LABEL_LENGTHEXCEPT;
                        if (*(uint*)dataptr_t != Reflection.ID.Global.Materials)
                            goto LABEL_IDEXCEPT;
                        CName = Utils.ScriptX.NullTerminatedString(dataptr_t + 0x1C, 0x1C);
                        if (this.GetClassIndex(CName, type) != -1)
                            goto LABEL_EXISTEXCEPT;
                        var material = new Support.Carbon.Class.Material(dataptr_t, CName, this);
                        this.Materials.Classes.Add(material);
                        return true;

                    case eClassType.CarTypeInfo:
                        if (data.Length != 0xD0)
                            goto LABEL_LENGTHEXCEPT;
                        CName = Utils.ScriptX.NullTerminatedString(dataptr_t, 0x10);
                        if (this.GetClassIndex(CName, type) != -1)
                            goto LABEL_EXISTEXCEPT;
                        var cartypeinfo = new Support.Carbon.Class.CarTypeInfo(dataptr_t, CName, this);
                        cartypeinfo.Modified = true;
                        cartypeinfo.Deletable = true;
                        cartypeinfo.CollisionExternalName = CName;
                        cartypeinfo.CollisionInternalName = "CARRERAGT";
                        this.CarTypeInfos.Classes.Add(cartypeinfo);
                        return true;

                    case eClassType.PresetRide:
                        if (data.Length != 0x600)
                            goto LABEL_LENGTHEXCEPT;
                        CName = Utils.ScriptX.NullTerminatedString(dataptr_t + 0x28, 0x20);
                        if (this.GetClassIndex(CName, type) != -1)
                            goto LABEL_EXISTEXCEPT;
                        var presetride = new Support.Carbon.Class.PresetRide(dataptr_t, CName, this);
                        this.PresetRides.Classes.Add(presetride);
                        return true;

                    case eClassType.PresetSkin:
                        if (data.Length != 0x68)
                            goto LABEL_LENGTHEXCEPT;
                        CName = Utils.ScriptX.NullTerminatedString(dataptr_t + 0x8, 0x1C);
                        if (this.GetClassIndex(CName, type) != -1)
                            goto LABEL_EXISTEXCEPT;
                        var presetskin = new Support.Carbon.Class.PresetSkin(dataptr_t, CName, this);
                        this.PresetSkins.Classes.Add(presetskin);
                        return true;

                    default:
                        if (Core.Process.MessageShow)
                            System.Windows.Forms.MessageBox.Show("Unable to import class specified.", "Warning");
                        else
                            System.Console.WriteLine("Unable to import class specified.");
                        return false;
                }
            }

        LABEL_LENGTHEXCEPT:
            if (Core.Process.MessageShow)
                System.Windows.Forms.MessageBox.Show("File length is invalid for importing.", "Warning");
            else
                System.Console.WriteLine("File length is invalid for importing.");
            return false;

        LABEL_IDEXCEPT:
            if (Core.Process.MessageShow)
                System.Windows.Forms.MessageBox.Show("File ID is invalid for importing.", "Warning");
            else
                System.Console.WriteLine("File ID is invalid for importing.");
            return false;

        LABEL_EXISTEXCEPT:
            if (Core.Process.MessageShow)
                System.Windows.Forms.MessageBox.Show("Class with the same collection name already exists.", "Warning");
            else
                System.Console.WriteLine("Class with the same collection name already exists.");
            return false;
        }
    }
}