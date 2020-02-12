namespace GlobalLib.Utils.HTML
{
	public static class StartTags
	{
		public const string Head = "head";
		public const string Body = "body";
		public const string Title = "title";
		public const string WWidth = "wwidth";
		public const string WHeight = "wheight";
		public const string WFColor = "wfcolor";
		public const string WBColor = "wbcolor";

		public const string FontBoldedStyle = "b";
		public const string FontItalicStyle = "i";
		public const string FontULinedStyle = "u";
		public const string FontStrikeStyle = "s";

		public const string DottedList = "ul";
		public const string NumberedList = "ol";
		public const string ListItem = "li";

		public const string NewLine = "br/";


		public static string GetFieldName(string tag)
		{
			var type = typeof(StartTags);
			foreach (var field in type.GetFields())
			{
				if ((string)field.GetValue(type) == tag)
					return field.Name;
			}
			return null;
		}
	}
}
