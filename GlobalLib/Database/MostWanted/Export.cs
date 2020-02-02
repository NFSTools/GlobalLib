namespace GlobalLib.Database
{
    public partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
    {
        /// <summary>
        /// Exports data of the class specified in a binary file.
        /// </summary>
        /// <param name="CName">Collection Name of the class to be exported.</param>
        /// <param name="type">Type of the class to be exported.</param>
        /// <param name="filepath">Filepath path where data should be exported.</param>
        public void Export(string CName, ClassType type, string filepath)
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
                        case ClassType.Material:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistanceException();
                            bw.Write(this.Materials[index].Assemble());
                            return;

                        case ClassType.CarTypeInfo:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistanceException();
                            bw.Write(this.CarTypeInfos[index].Assemble(0xFF));
                            return;

                        case ClassType.PresetRide:
                            index = this.GetClassIndex(CName, type);
                            if (index == -1)
                                throw new Reflection.Exception.CollectionExistanceException();
                            bw.Write(this.PresetRides[index].Assemble());
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
        public void Export(int index, ClassType type, string filepath)
        {
            try
            {
                if (!System.IO.Path.HasExtension(filepath))
                    filepath += ".BIN";
                using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.Create)))
                {
                    switch (type)
                    {
                        case ClassType.Material:
                            if (index < 0 || index >= this.Materials.Count)
                                throw new System.ArgumentOutOfRangeException();
                            bw.Write(this.Materials[index].Assemble());
                            return;

                        case ClassType.CarTypeInfo:
                            if (index < 0 || index >= this.CarTypeInfos.Count)
                                throw new System.ArgumentOutOfRangeException();
                            bw.Write(this.CarTypeInfos[index].Assemble(0xFF));
                            return;

                        case ClassType.PresetRide:
                            if (index < 0 || index >= this.PresetRides.Count)
                                throw new System.ArgumentOutOfRangeException();
                            bw.Write(this.PresetRides[index].Assemble());
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