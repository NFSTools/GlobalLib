using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLib.Utils.HTML
{
	public partial class HTMLTextBox : IDisposable
	{
		public HTMLTagType GetSettingTag(string tag, ref string setting)
		{
			tag = EA.Resolve.RemoveWhiteSpace(tag);

			if (tag.StartsWith("!--") && tag.EndsWith("--"))
				return HTMLTagType.Comment;

			string format = "{X}" + Rule.Quote;
			var sett = typeof(SettingTags);
			foreach (var field in sett.GetFields())
			{
				string nfield = (string)field.GetValue(sett) + Rule.Equal + Rule.Quote;
				if (tag.StartsWith(nfield))
				{
					setting = FormatX.GetString(tag, nfield + format);
					return (HTMLTagType)Enum.Parse(typeof(HTMLTagType), field.Name);
				}
			}
			return HTMLTagType.Default;
		}

		public HTMLTagType GetTagType(string tag, ref string setting)
		{
			var start = StartTags.GetFieldName(tag);
			if (start != null)
				return (HTMLTagType)Enum.Parse(typeof(HTMLTagType), start);
			var end = EndTags.GetFieldName(tag);
			if (end != null)
				return (HTMLTagType)Enum.Parse(typeof(HTMLTagType), end);
			return this.GetSettingTag(tag, ref setting);
		}

		private int FindIndexByEndTag(string tag, List<TagFormatter> tags)
		{
			string setting = null;
			var find = this.GetTagType(tag, ref setting);
			for (int a1 = tags.Count - 1; a1 >= 0; ++a1) // start from the end
				if (find == tags[a1].TagType) return a1;
			return -1;
		}
	}
}