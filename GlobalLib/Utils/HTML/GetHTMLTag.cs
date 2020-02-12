using System;
using System.Collections.Generic;



namespace GlobalLib.Utils.HTML
{
	public partial class HTMLTextBox : IDisposable
	{
		private HTMLTagType GetSettingTag(string tag, ref string setting)
		{
			string set = tag;
			tag = ScriptX.RemoveWhiteSpace(tag);

			if (tag.StartsWith("!--") && tag.EndsWith("--"))
				return HTMLTagType.Comment;

			string equals = Rule.Equal + Rule.Quote;
			if (tag.StartsWith(SettingTags.Body + equals) && tag.EndsWith(Rule.Quote))
			{
				setting = ScriptX.QuotedString(set);
				this.AppendDefaultStyling(setting);
				return HTMLTagType.Body;
			}
			else if (tag.StartsWith(SettingTags.Paragraph + equals) && tag.EndsWith(Rule.Quote))
			{
				setting = ScriptX.QuotedString(set);
				return HTMLTagType.Paragraph;
			}
			else if (tag.StartsWith(SettingTags.ReferenceLink + equals) && tag.EndsWith(Rule.Quote))
			{
				setting = ScriptX.QuotedString(set);
				return HTMLTagType.ReferenceLink;
			}
			else if (tag.StartsWith(SettingTags.ImageLink + equals) && tag.EndsWith(Rule.Quote))
			{
				this.Menu.ImagePaths.Add(ScriptX.QuotedString(set));
				return HTMLTagType.ImageLink;
			}
			else
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

		public HTMLTagType GetTagType(string tag)
		{
			var start = StartTags.GetFieldName(tag);
			if (start != null)
				return (HTMLTagType)Enum.Parse(typeof(HTMLTagType), start);
			var end = EndTags.GetFieldName(tag);
			if (end != null)
				return (HTMLTagType)Enum.Parse(typeof(HTMLTagType), end);
			return HTMLTagType.Default;
		}

		private int FindIndexByEndTag(string tag, List<TagFormatter> tags)
		{
			var find = this.GetTagType(tag);
			for (int a1 = tags.Count - 1; a1 >= 0; --a1) // start from the end
				if (find == tags[a1].TagType) return a1;
			return -1;
		}
	}
}