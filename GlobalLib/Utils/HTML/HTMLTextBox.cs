using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;



namespace GlobalLib.Utils.HTML
{
	public partial class HTMLTextBox : IDisposable
	{
		public RichTextBox RTX { get; set; }
		public MenuSettings Menu { get; set; }
		private Dictionary<string, string> _linkmap;

		private const char Listable = '\u02E3';
		public static Color LinkColor { get; } = Color.FromArgb(1, 1, 0xEE);

		public void LoadHTMLTextBox(string[] lines)
		{
			char[] delim = new char[] { '<', '>' };
			var formatters = new List<TagFormatter>();
			string variative = null;
			bool controlled = false;
			bool bodyprocess = false;

			foreach (var line in lines)
			{
				var nline = ScriptX.RemoveNewLines(line);
				nline = ScriptX.CleanString(nline, false);
				var words = nline.Split(delim);
				foreach (var word in words)
				{
					if (string.IsNullOrEmpty(word)) continue;
					if (word == StartTags.NewLine && bodyprocess)
					{
						this.RTX.AppendText(Environment.NewLine);
						continue;
					}
					this.DefaultAllFormats();
					if (this.IsEndTag(word))
					{
						if (!controlled && !bodyprocess) continue;

						int index = this.FindIndexByEndTag(word, formatters);
						if (index == -1) { this.RTX.AppendText(word); continue; }
						formatters[index].SelectLength = this.RTX.Text.Length - formatters[index].StartsLength;

						if (controlled)
						{
							formatters[index].SpecialSetting = variative;
							this.AppendMenuStyling(formatters[index]);
							variative = null;
						}
						else if (bodyprocess)
							this.AppendTextStyling(formatters[index]);
						else continue;

						if (formatters[index].TagType == HTMLTagType.Head)
							controlled = false;

						if (formatters[index].TagType == HTMLTagType.Body)
							bodyprocess = false;

						formatters.RemoveAt(index);
					}
					else if (this.IsStartTag(word))
					{
						string setting = null;
						var tag = new TagFormatter();
						tag.StartsLength = this.RTX.Text.Length;
						tag.SelectLength = 0;
						tag.TagType = this.GetTagType(word, ref setting);
						if (setting != null) tag.SpecialSetting = setting;

						if (tag.TagType == HTMLTagType.Head)
							controlled = true;
						else if (tag.TagType == HTMLTagType.Body)
							bodyprocess = true;
						else if (tag.TagType == HTMLTagType.Comment)
							continue;
						else if (tag.TagType == HTMLTagType.ImageLink)
							continue;

						formatters.Add(tag);
					}
					else if (controlled)
						variative += word;
					else if (bodyprocess)
						this.RTX.AppendText(word);
					else
						continue;
				}
			}
		}
	
	
		public HTMLTextBox()
		{
			this.InitializeComponent(null);
		}
		public HTMLTextBox(string[] lines)
		{
			this.InitializeComponent(null);
			this.LoadHTMLTextBox(lines);
		}
		public HTMLTextBox(RichTextBox box)
		{
			this.InitializeComponent(box);
		}
		public HTMLTextBox(RichTextBox box, string[] lines)
		{
			this.InitializeComponent(box);
			this.LoadHTMLTextBox(lines);
		}
	}
}