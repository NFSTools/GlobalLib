using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLib.Database
{
	public partial class Underground2
	{
		public bool SetByPath(string PropertyPath, object value)
		{
			try
			{
				var tokens = PropertyPath.Split(new char[] { ' ', '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
				var type = (ClassType)Enum.Parse(typeof(ClassType), tokens[0]);
				foreach (var pro_1 in this.GetType().GetProperties())
				{
					
				}






				return true;
			}
			catch (Exception e)
			{
				while (e.InnerException != null) e = e.InnerException;
				if (Core.Process.MessageShow)
					System.Windows.Forms.MessageBox.Show(e.Message);
				else
					System.Console.WriteLine($"{e.Message}");
				return false;
			}
		}
	}
}
