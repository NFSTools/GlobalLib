using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;



namespace GlobalLib.Utils.HTML
{
	public class MenuSettings
	{
		public string Title { get; set; } = "Import Endscript";
		public int Width { get; set; } = 800;
		public int Height { get; set; } = 480;
		public Font DefaultFont { get; set; } = Control.DefaultFont;
		public Color DefaultColor { get; set; } = Control.DefaultForeColor;
		public Color DefaultBackground { get; set; } = Control.DefaultBackColor;
		public Color WFColor { get; set; } = Color.FromArgb(45, 45, 45);
		public Color WBColor { get; set; } = Color.FromArgb(30, 30, 30);
		public HorizontalAlignment DefaultAlign { get; set; } = HorizontalAlignment.Left;
		public bool UseDefaultBackgound { get; set; } = false;
		public List<string> ImagePaths { get; set; }
	}
}