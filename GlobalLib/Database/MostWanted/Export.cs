namespace GlobalLib.Database
{
    public partial class MostWanted : Reflection.Interface.IGetIndex, Reflection.Interface.IOperative
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
                if (!System.IO.Path.HasExtension(filepath))
                    filepath += ".BIN";
                using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.Create)))
                {
                    switch (type)
                    {
                        case eClassType.Material:
                            var material = this.Materials.FindClass(CName);
                            if (material == null)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(material.Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.CarTypeInfo:
                            var car = this.CarTypeInfos.FindClass(CName);
                            if (car == null)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(car.Assemble(0xFF));
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.PresetRide:
                            var ride = this.PresetRides.FindClass(CName);
                            if (ride == null)
                                throw new Reflection.Exception.CollectionExistenceException();
                            bw.Write(ride.Assemble());
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
                            if (index < 0 || index >= this.Materials.Length)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.Materials.Classes[index].CollectionName;
                            bw.Write(this.Materials.Classes[index].Assemble());
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.CarTypeInfo:
                            if (index < 0 || index >= this.CarTypeInfos.Length)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.CarTypeInfos.Classes[index].CollectionName;
                            bw.Write(this.CarTypeInfos.Classes[index].Assemble(0xFF));
                            this.ShowSuccessMessage(CName);
                            return;

                        case eClassType.PresetRide:
                            if (index < 0 || index >= this.PresetRides.Length)
                                throw new System.ArgumentOutOfRangeException();
                            CName = this.PresetRides.Classes[index].CollectionName;
                            bw.Write(this.PresetRides.Classes[index].Assemble());
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
        /// <param name="CName">Collection Name of the class to be exported.</param>
        /// <param name="root">Root of the class to be exported.</param>
        /// <param name="filepath">Filepath path where data should be exported.</param>
        public void Export(string CName, string root, string filepath)
        {
            try
            {
                var type = (eClassType)System.Enum.Parse(typeof(eClassType), root);
                this.Export(CName, type, filepath);
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