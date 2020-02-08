using System.Collections.Generic;



namespace GlobalLib.Utils.HTML
{
	public class TagFormatter
	{
		public int StartsLength { get; set; }
		public int SelectLength { get; set; }
		public TexEd.HTMLTagType TagType { get; set; }
		public string SpecialSetting { get; set; }

		public static int FindIndexByEndTag(string tag, List<TagFormatter> tags)
		{
			var find = TexEd.GetTagType(TexEd.EndTagToStartTag(tag));
			for (int a1 = 0; a1 < tags.Count; ++a1)
				if (find == tags[a1].TagType) return a1;
			return -1;
		}
	}
}
