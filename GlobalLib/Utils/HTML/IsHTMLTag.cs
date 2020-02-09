namespace GlobalLib.Utils.HTML
{
	public partial class HTMLTextBox : System.IDisposable
	{
		public bool IsStartTag(string tag)
		{
			var type = typeof(StartTags);
			var sett = typeof(SettingTags);

			if (tag.StartsWith("!--") && tag.EndsWith("--")) return true;
			foreach (var field in type.GetFields())
				if ((string)field.GetValue(type) == tag) return true;

			tag = EA.Resolve.RemoveWhiteSpace(tag);
			foreach (var field in sett.GetFields())
			{
				string nfield = (string)field.GetValue(sett) + Rule.Equal + Rule.Quote;
				if (tag.StartsWith(nfield) && tag.EndsWith(Rule.Quote))
					return true;
			}
			return false;
		}
		public bool IsEndTag(string tag)
		{
			var type = typeof(EndTags);
			foreach (var field in type.GetFields())
			{
				if ((string)field.GetValue(type) == tag) return true;
			}
			return false;
		}
		public string EndTagToStartTag(string tag)
		{
			return FormatX.GetString(tag, "/{X}");
		}
		public string StartTagToEndTag(string tag)
		{
			return $"/{tag}";
		}
	}
}