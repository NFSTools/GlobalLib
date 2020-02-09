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
		public RichTextBox RTX { get; set; }
		public MenuSettings Menu { get; set; }
		private Dictionary<string, string> _linkmap;
		private bool controlled = false;

		public static Color LinkColor { get; } = Color.FromArgb(1, 1, 0xEE);




		public void LoadHTMLTextBox(string[] lines)
		{
			char[] delim = new char[] { '<', '>' };
			var formatters = new List<TagFormatter>();
			string variative = null;

			foreach (var line in lines)
			{
				var nline = EA.Resolve.RemoveNewLines(line);
				var words = nline.Split(delim);
				foreach (var word in words)
				{
					if (string.IsNullOrEmpty(word)) continue;
					if (word == StartTags.NewLine)
					{
						this.RTX.AppendText(Environment.NewLine);
						continue;
					}
					this.DefaultAllFormats();
					if (this.IsEndTag(word))
					{
						int index = this.FindIndexByEndTag(word, formatters);
						if (index == -1) { this.RTX.AppendText(word); continue; }
						formatters[index].SelectLength = this.RTX.Text.Length - formatters[index].StartsLength;

						if (this.controlled)
							this.AppendMenuStyling(formatters[index]);
						else
							this.AppendTextStyling(formatters[index]);

						if (formatters[index].TagType == HTMLTagType.Head)
							this.controlled = false;

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
						{
							this.controlled = true;
							continue;
						}

						if (tag.TagType == HTMLTagType.Comment)
							continue;

						formatters.Add(tag);
					}
					else if (this.controlled)
						variative += word;
					else
						this.RTX.AppendText(word);
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
