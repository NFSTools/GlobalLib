namespace GlobalLib.Database
{
    public partial class Carbon : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        private void ShowSuccessMessage(string CName)
        {
            if (Core.Process.MessageShow)
                System.Windows.Forms.MessageBox.Show($"Class {CName} has been exported.", "Success");
            else
                System.Console.WriteLine($"Class {CName} has been exported.");
        }

        /// <summary>
        /// Exports data of the class specified in a binary file.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be exported.</param>
        /// <param name="type">Type of the class to be exported.</param>
        /// <param name="filepath">Filepath path where data should be exported.</param>
        public void Export(string CName, eClassType type, string filepath)
        {
            try
            {
                int index = -1;
                if (!System.IO.Path.HasExtension(filepath))
                    filepath += ".BIN";
                using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.Create)))
                {
                    switch (type)
                    {
                        case eClassType.Material:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(this.Materials[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.CarTypeInfo:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(this.CarTypeInfos[index].Assemble(0xFF));
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.PresetRide:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(this.PresetRides[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.PresetSkin:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(this.PresetSkins[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        default:
                            throw new System.Exception("Could not export class specified.");
                    }
                }
            }
            catch (System.Exception e)
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message, "Failure");
                else
                    System.Console.WriteLine($"{e.Message}");
            }
        }

        /// <summary>
        /// Exports data of the class specified in a binary file.
        /// </summary>
        /// <param name="index">Index of the class to be exported in the database.</param>
        /// <param name="type">Type of the class to be exported.</param>
        /// <param name="filepath">Filepath path where data should be exported.</param>
        public void Export(int index, eClassType type, string filepath)
        {
            try
            {
                string CName;
                if (!System.IO.Path.HasExtension(filepath))
                    filepath += ".BIN";
                using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.Create)))
                {
                    switch (type)
                    {
                        case eClassType.Material:
                            if (index < 0 || index >= this.Materials.Count)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.Materials[index].CollectionName;
                            bw.Write(this.Materials[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.CarTypeInfo:
                            if (index < 0 || index >= this.CarTypeInfos.Count)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.CarTypeInfos[index].CollectionName;
                            bw.Write(this.CarTypeInfos[index].Assemble(0xFF));
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.PresetRide:
                            if (index < 0 || index >= this.PresetRides.Count)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.PresetRides[index].CollectionName;
                            bw.Write(this.PresetRides[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.PresetSkin:
                            if (index < 0 || index >= this.PresetSkins.Count)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.PresetSkins[index].CollectionName;
                            bw.Write(this.PresetSkins[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        default:
                            throw new System.Exception("Could not export class specified.");
                    }
                }
            }
            catch (System.Exception e)
            {
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message, "Failure");
                else
                    System.Console.WriteLine($"{e.Message}");
            }
        }
    }
}