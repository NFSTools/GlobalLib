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
		private FontStyle TagToFontStyle(HTMLTagType tag)
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

		public void AppendFontStyling(TagFormatter tag)
		{
			if (string.IsNullOrEmpty(tag.SpecialSetting)) return;
			char[] delim = new char[] { ' ', ':', ';' };
			var split = tag.SpecialSetting.Split(delim, StringSplitOptions.RemoveEmptyEntries);
			FontStyling styling;
			for (int a = 0; a < split.Length / 2; ++a)
			{
				switch (split[a * 2])
				{
					case "font-size":
						styling = FontStyling.FontSize;
						break;
					case "font-family":
						styling = FontStyling.FontFamily;
						break;
					case "color":
						styling = FontStyling.Color;
						break;
					case "background-color":
						styling = FontStyling.BackgroundColor;
						break;
					case "text-align":
						styling = FontStyling.Align;
						break;
					default:
						continue;
				}
				switch (styling)
				{
					case FontStyling.FontSize:
						if (int.TryParse(split[a * 2 + 1], out int size))
							RTX.SelectionFont = new Font(RTX.SelectionFont.FontFamily, size, RTX.SelectionFont.Style);
						continue;
					case FontStyling.FontFamily:
						FontFamily fontfamily = null;
						foreach (var family in FontFamily.Families)
							if (split[a * 2 + 1] == family.Name) fontfamily = family;
						if (fontfamily != null)
							RTX.SelectionFont = new Font(fontfamily, RTX.SelectionFont.Size, RTX.SelectionFont.Style);
						continue;
					case FontStyling.Color:
						if (split[a * 2 + 1].StartsWith("#") || split[a * 2 + 1].Length == 7)
							RTX.SelectionColor = ColorTranslator.FromHtml(split[a * 2 + 1]);
						continue;
					case FontStyling.BackgroundColor:
						if (split[a * 2 + 1].StartsWith("#") || split[a * 2 + 1].Length == 7)
							RTX.SelectionBackColor = ColorTranslator.FromHtml(split[a * 2 + 1]);
						continue;
					case FontStyling.Align:
						switch (split[a * 2 + 1])
						{
							case "left":
								RTX.SelectionAlignment = HorizontalAlignment.Left;
								goto default;
							case "right":
								RTX.SelectionAlignment = HorizontalAlignment.Right;
								goto default;
							case "center":
								RTX.SelectionAlignment = HorizontalAlignment.Center;
								goto default;
							default:
								continue;
						}
					default:
						continue;
				}
			}
		}

		public void AppendMenuStyling(TagFormatter tag)
		{

		}

		public void AppendTextStyling(TagFormatter tag)
		{
			switch (tag.TagType)
			{
				case HTMLTagType.FontBoldedStyle:
				case HTMLTagType.FontItalicStyle:
				case HTMLTagType.FontULinedStyle:
				case HTMLTagType.FontStrikeStyle:
					var fonttype = TagToFontStyle(tag.TagType);
					this.RTX.Select(tag.StartsLength, tag.SelectLength);
					if (this.RTX.SelectionLength > 0)
						this.RTX.SelectionFont = new Font(this.RTX.SelectionFont, fonttype | this.RTX.SelectionFont.Style);
					return;

				case HTMLTagType.FontStyle:
					this.RTX.Select(tag.StartsLength, tag.SelectLength);
					if (this.RTX.SelectionLength > 0)
						this.AppendFontStyling(tag);
					return;

				case HTMLTagType.ReferenceLink:
					this.RTX.Select(tag.StartsLength, tag.SelectLength);
					if (this.RTX.SelectionLength == 0) return;
					this.RTX.SelectionFont = new Font(this.RTX.SelectionFont, FontStyle.Underline);
					this.RTX.SelectionColor = LinkColor;
					this._linkmap[this.RTX.SelectedText] = tag.SpecialSetting;
					return;


				default:
					return;
			}
		}
	}
}