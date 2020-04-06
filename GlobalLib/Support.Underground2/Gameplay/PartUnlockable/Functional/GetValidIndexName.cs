using GlobalLib.Support.Underground2.Framework;

namespace GlobalLib.Support.Underground2.Gameplay
{
	public partial class PartUnlockable
	{
		private string GetValidCollectionName(int index)
		{
			if (index > PartCNames.PartUnlockablesList.Count)
				return $"UnknownPart{index}";
			else
				return PartCNames.PartUnlockablesList[index - 1];
		}

		private int GetValidCollectionIndex()
		{
			if (PartCNames.PartUnlockablesList.Contains(this._collection_name))
				return PartCNames.PartUnlockablesList.FindIndex(c => c == this._collection_name) + 1;
			else
				return PartCNames.PartUnlockablesList.Count + 1;
		}
	}
}