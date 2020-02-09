using System.Drawing;
using System.Windows.Forms;



namespace GlobalLib.Utils.HTML
{
	public class MenuSettings
	{
		public string Title { get; set; } = "Import Endscript";
		public int Width { get; set; } = 800;
		public int Height { get; set; } = 450;
		public Font DefaultFont { get; set; } = Control.DefaultFont;
		public Color DefaultColor { get; set; } = Control.DefaultForeColor;
		public Color DefaultBackground { get; set; } = Control.DefaultBackColor;
		public HorizontalAlignment DefaultAlign { get; set; } = HorizontalAlignment.Left;
	}
}