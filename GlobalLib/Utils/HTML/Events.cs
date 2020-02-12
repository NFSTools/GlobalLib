using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;



namespace GlobalLib.Utils.HTML
{
	public partial class HTMLTextBox
	{
		public void Dispose()
		{
			if (this.RTX != null) return;
			if (this.RTX.Disposing) return;
			if (this.RTX.IsDisposed) return;
			this.RTX.Dispose();
		}

		private void InitializeComponent(RichTextBox box)
		{
			if (box == null) this.RTX = new RichTextBox();
			else this.RTX = box;
			this.Menu = new MenuSettings();
			this.RTX.DetectUrls = false;
			this.RTX.MouseClick += new MouseEventHandler(this.RichTextBox_MouseClickEvent);
			this._linkmap = new Dictionary<string, string>();
			this.Menu.ImagePaths = new List<string>();
		}

		private void DefaultAllFormats()
		{
			this.RTX.SelectionStart = this.RTX.Text.Length;
			this.RTX.SelectionFont = this.Menu.DefaultFont;
			this.RTX.SelectionColor = this.Menu.DefaultColor;
			this.RTX.SelectionAlignment = this.Menu.DefaultAlign;
			if (this.Menu.UseDefaultBackgound)
				this.RTX.SelectionBackColor = this.Menu.DefaultBackground;
			else
				this.RTX.SelectionBackColor = this.Menu.WFColor;
		}

		private void SendToLink(RichTextBox box, int index)
		{
			if (box.SelectionColor != LinkColor) return;
			var linkfont = new Font(box.SelectionFont, FontStyle.Underline);
			if (!EA.Resolve.EqualFonts(box.SelectionFont, linkfont)) return;

			int selectionstart = index;
			int selectionend = index;

			for (int c = index - 1; c >= 0; --c)
			{
				box.SelectionStart = c;
				if (!EA.Resolve.EqualFonts(box.SelectionFont, linkfont) || box.SelectionColor != LinkColor)
				{
					selectionstart = c;
					break;
				}
				if (c == 0) selectionstart = 0;
			}
			for (int c = index + 1; c < box.Text.Length; ++c)
			{
				box.SelectionStart = c;
				if (!EA.Resolve.EqualFonts(box.SelectionFont, linkfont) || box.SelectionColor != LinkColor)
				{
					selectionend = c - 1;
					break;
				}
			}
			box.SelectionStart = index;
			if (selectionstart == selectionend) return;
			var key = box.Text.Substring(selectionstart, selectionend - selectionstart);
			key = ScriptX.RemoveNewLines(key);
			if (!_linkmap.TryGetValue(key, out string result)) return;
			var e = new LinkClickedEventArgs(result);
			RichTextBox_LinkClickedEvent(box, e);
		}

		private void RichTextBox_LinkClickedEvent(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}

		public void RichTextBox_MouseClickEvent(object sender, MouseEventArgs e)
		{
			var HTMLTextBox = (RichTextBox)sender;
			if (HTMLTextBox.SelectionStart == HTMLTextBox.Text.Length) return;
			SendToLink(HTMLTextBox, HTMLTextBox.SelectionStart);
		}
	}
}