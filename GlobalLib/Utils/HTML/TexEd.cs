using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLib.Utils.HTML
{
	public static class TexEd
	{
		public enum HTMLTagType : int
		{
			Default = 0,
			FontBoldedStyle = 1,
			FontItalicStyle = 2,
			FontULinedStyle = 3,
			FontStrikeStyle = 4,
			Paragraph = 5,
			Header = 6,
			DottedList = 7,
			NumberedList = 8,
		}
		public static class StartTags
		{
			public const string sbolded = "b";
			public const string sitalic = "i";
			public const string sulined = "u";
			public const string sstrike = "s";

			public const string sparagraph = "p";
			public const string sheader = "header";
			public const string sdotlist = "ul";
			public const string snumlist = "ol";
		}
		public static class EndTags
		{
			public const string ebolded = "/b";
			public const string eitalic = "/i";
			public const string eulined = "/u";
			public const string estrike = "/s";

			public const string eparagraph = "/p";
			public const string eheader = "/header";
			public const string edotlist = "/ul";
			public const string enumlist = "/ol";
		}

		public static bool IsStartTag(string tag)
		{
			var type = typeof(StartTags);
			foreach (var field in type.GetFields())
			{
				if ((string)field.GetValue(type) == tag) return true;
			}
			return false;
		}
		public static bool IsEndTag(string tag)
		{
			var type = typeof(EndTags);
			foreach (var field in type.GetFields())
			{
				if ((string)field.GetValue(type) == tag) return true;
			}
			return false;
		}
		public static string EndTagToStartTag(string tag)
		{
			return FormatX.GetString(tag, "/{X}");
		}
		public static string StartTagToEndTag(string tag)
		{
			return $"/{tag}";
		}

		public static HTMLTagType GetTagType(string tag)
		{
			switch (tag)
			{
				case StartTags.sbolded:
				case EndTags.ebolded:
					return HTMLTagType.FontBoldedStyle;
				case StartTags.sitalic:
				case EndTags.eitalic:
					return HTMLTagType.FontItalicStyle;
				case StartTags.sulined:
				case EndTags.eulined:
					return HTMLTagType.FontULinedStyle;
				case StartTags.sstrike:
				case EndTags.estrike:
					return HTMLTagType.FontStrikeStyle;
				case StartTags.sparagraph:
				case EndTags.eparagraph:
					return HTMLTagType.Paragraph;
				case StartTags.sheader:
				case EndTags.eheader:
					return HTMLTagType.Header;
				case StartTags.sdotlist:
				case EndTags.edotlist:
					return HTMLTagType.DottedList;

				default:
					return HTMLTagType.Default;
			}
		}
		private static FontStyle TagToFontStyle(HTMLTagType tag)
		{
			switch (tag)
			{
				case HTMLTagType.FontBoldedStyle:
					return FontStyle.Bold;
				case HTMLTagType.FontItalicStyle:
					return FontStyle.Italic;
				case HTMLTagType.FontULinedStyle:
					return FontStyle.Underline;
				case HTMLTagType.FontStrikeStyle:
					return FontStyle.Strikeout;
				default:
					return FontStyle.Regular;
			}
		}

		public static void AppendTextStyling(TagFormatter tag, RichTextBox HTMLTextBox)
		{
			switch (tag.TagType)
			{
				case HTMLTagType.FontBoldedStyle:
				case HTMLTagType.FontItalicStyle:
				case HTMLTagType.FontULinedStyle:
				case HTMLTagType.FontStrikeStyle:
					var fonttype = TagToFontStyle(tag.TagType);
					HTMLTextBox.Select(tag.StartsLength, tag.SelectLength);
					if (HTMLTextBox.SelectionLength > 0)
						HTMLTextBox.SelectionFont = new Font(HTMLTextBox.SelectionFont, fonttype | HTMLTextBox.SelectionFont.Style);
					return;

				case HTMLTagType.Paragraph:


				default:
					return;
			}
		}




		public static void LoadHTMLTextBox(string[] lines, RichTextBox HTMLTextBox)
		{
			char[] delim = new char[] { '<', '>' };
			var formatters = new List<TagFormatter>();

			foreach (var line in lines)
			{
				var words = line.Split(delim);
				foreach (var word in words)
				{
					if (string.IsNullOrEmpty(word)) continue;
					if (TexEd.IsEndTag(word))
					{
						int index = TagFormatter.FindIndexByEndTag(word, formatters);
						if (index == -1) { HTMLTextBox.AppendText(word); continue; }
						formatters[index].SelectLength = HTMLTextBox.Text.Length - formatters[index].StartsLength;
						TexEd.AppendTextStyling(formatters[index], HTMLTextBox);
						formatters.RemoveAt(index);
					}
					else if (TexEd.IsStartTag(word))
					{
						var tag = new TagFormatter();
						tag.StartsLength = HTMLTextBox.Text.Length;
						tag.SelectLength = 0;
						tag.TagType = TexEd.GetTagType(word);
						formatters.Add(tag);
					}
					else
						HTMLTextBox.AppendText(word);
				}
				HTMLTextBox.AppendText(Environment.NewLine);
			}
		}
	}
}
